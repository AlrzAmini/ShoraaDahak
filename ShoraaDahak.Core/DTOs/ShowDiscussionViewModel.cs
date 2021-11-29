using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShoraaDahak.DataLayer.Models.Discussion;

namespace ShoraaDahak.Core.DTOs
{
    public class ShowDiscussionViewModel
    {
        public Discussion Discussion { get; set; }

        public List<Answer> Answers { get; set; }
    }
}
