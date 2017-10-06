using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BudgetManager.Models
{
    public class Budgets
    {
        public int Id { get; set; }

        [Display(Name = "Budget Navn")]
        [Required(ErrorMessage = "Du skal anføre et budget navn")]
        [StringLength(100, ErrorMessage = "Navnet på budgettet må max være på 100 tegn")]
        public string BudgetName { get; set; }

        [Display(Name = "Formål")]
        [Required(ErrorMessage = "Du skal anføre et formål")]
        [StringLength(400, ErrorMessage = "Formålsbeskrivelsen må max være på 400 tegn")]
        public string Purpose { get; set; }

        [Display(Name = "Regnskabsår")]
        [Required(ErrorMessage = "Du skal anføre et regnskabsår")]
        [Range(1000, 9999)]
        public int FiscalYear { get; set; }

        [Display(Name = "Offentlig")]
        public bool Visibility { get; set; }

        [Display(Name = "Interval")]
        public int Interval { get; set; }

    }
}