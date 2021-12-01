using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoraaDahak.Core.DTOs
{
    public class ShowListedLettersInAdmin
    {
        public int LetterId { get; set; }

        public int UserId { get; set; }

        public string Title { get; set; }

        public DateTime SendDate { get; set; }

        public bool IsRead { get; set; }

        public string SenderName { get; set; }
    }

    public class FilteredLisLettersInAdmin
    {
        public List<ShowListedLettersInAdmin> Letters { get; set; }

        public int CurrentPage { get; set; }

        public int TotalPages { get; set; }
    }
}
