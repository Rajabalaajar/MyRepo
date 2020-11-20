using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _2c2pAssignment.Models
{
    public class DataViewModel
    {
        public DateFilter dateFilter { get; set; }
        public CurrencyFilter currencyFilter { get; set; }
        public StatusFilter statusFilter { get; set; }
        public List<StatusFilter> statusFilters { get; set; }
        public List<OutputModel> outputModel { get; set; }

    }
    public class OutputModel
    {
        public string Id { get; set; }
        public string Payment { get; set; }
        public string Status { get; set; }
    }
    public class DateFilter
    {
        public string StartDate { get; set; }
        public string EndDate
        {
            get; set;
        }
    }
    public class CurrencyFilter
    {
        public string Currency { get; set; }

        public string SelectedCurrency { get; set; }
        public List<SelectListItem> Currencies { get; set; }
    }
    public class StatusFilter
    {
        public string Status { get; set; }

        public string SelectedStatus { get; set; }
        public List<SelectListItem> StatusList { get; set; }
    }
}
