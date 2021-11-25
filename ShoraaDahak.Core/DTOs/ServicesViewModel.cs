using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoraaDahak.Core.DTOs
{
    public class ShowServicesInAdminViewModel
    {
        public int ServiceId { get; set; }

        public string ServiceTitle { get; set; }

        public DateTime ServiceStartDate { get; set; }

        public int ServiceBudget { get; set; }
    }

    public class ServicesForAdminViewModel
    {
        public List<ShowServicesInAdminViewModel> Services { get; set; }

        public int CurrentPage { get; set; }

        public int TotalPages { get; set; }
    }
}
