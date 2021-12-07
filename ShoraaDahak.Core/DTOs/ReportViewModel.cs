using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoraaDahak.Core.DTOs
{
    public class ReportsInAdminViewModel
    {
        public string Subject { get; set; }

        public string Address { get; set; }

        public string SenderName { get; set; }

        public int ReportId { get; set; }

        public bool IsRead { get; set; }

        public DateTime CreateDate { get; set; }
    }
}
