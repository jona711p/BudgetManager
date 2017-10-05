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
        public string BudgetName { get; set; }

        [Display(Name = "Formål")]
        [Required(ErrorMessage = "Du skal anføre et formål")]
        public string Purpose { get; set; }

        [Display(Name = "Regnskabsår")]
        [Required(ErrorMessage = "Du skal anføre et regnskabsår")]
        public int FiscalYear { get; set; }

        [Display(Name = "Synlighed")]
        [Required(ErrorMessage = "Du skal anføre Synlighed")]
        public bool Visibility { get; set; }

        [Display(Name = "Interval")]
        [Required(ErrorMessage = "Du skal anføre interval")]
        public int Interval { get; set; }
    }
}