using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using BudgetManager.Models;

namespace BudgetManager.DB
{
    public class DB
    {
        private SqlConnection ConnectToDB(SqlConnection connection)
        {
            try
            {
                if (connection == null)
                    connection = new SqlConnection(ConfigurationManager.ConnectionStrings["BudgetManager"].ConnectionString);
                connection.Open();
            }

            catch (Exception)
            {
                //MessageBox.Show("Der Kunne ikke Oprettes Forbindelse til Databaseserveren!");
            }

            return connection;
        }

        private SqlConnection DisconnectFromDB(SqlConnection connection)
        {
            try
            {
                if (connection != null)
                {
                    if (connection.State == ConnectionState.Open)
                        connection.Close();
                }
            }

            catch (Exception)
            {
                //MessageBox.Show("Der Kunne ikke Oprettes Forbindelse til Databaseserveren!");
            }

            return connection;
        }

        public List<Budgets> GetBudgets()
        {
            SqlConnection connection = null;
            connection = ConnectToDB(connection);

            DataTable budgetTable = new DataTable();
            List<Budgets> budgets = new List<Budgets>();

            SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Budgets", connection);

            connection.Open();
            adapter.Fill(budgetTable);
            connection.Close();

            foreach (DataRow budget in budgetTable.Rows)
            {
                budgets.Add(
                    new Budgets
                    {
                        Id = int.Parse(budget["Id"].ToString()),
                        BudgetName = budget["BudgetName"].ToString(),
                        Purpose = budget["Purpose"].ToString(),
                        FiscalYear = int.Parse(budget["FiscalYear"].ToString()),
                        Visibility = bool.Parse(budget["Visibility"].ToString()),
                        Interval = int.Parse(budget["Interval"].ToString())
                    });
            }

            return budgets;
        }

        public void Create(Budgets inputBudget)
        {
            SqlConnection connection = null;
            connection = ConnectToDB(connection);
            
            SqlCommand command = new SqlCommand("spCreateBudget", connection);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.Add("@BudgetName", SqlDbType.NVarChar).Value = inputBudget.BudgetName;
            command.Parameters.Add("@Visibility", SqlDbType.Bit).Value = inputBudget.Visibility;
            command.Parameters.Add("@Purpose", SqlDbType.NVarChar).Value = inputBudget.Purpose;
            command.Parameters.Add("@FiscalYear", SqlDbType.Int).Value = inputBudget.FiscalYear;
            command.Parameters.Add("@Interval", SqlDbType.Int).Value = inputBudget.Interval;

            command.ExecuteNonQuery();

            connection = DisconnectFromDB(connection);
        }
    }
}