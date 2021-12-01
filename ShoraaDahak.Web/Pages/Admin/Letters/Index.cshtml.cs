using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShoraaDahak.Core.DTOs;
using ShoraaDahak.Core.Services.Interfaces;

namespace ShoraaDahak.Web.Pages.Admin.Letters
{
    public class IndexModel : PageModel
    {
        private readonly ILetterService _letterService;

        public IndexModel(ILetterService letterService)
        {
            _letterService = letterService;
        }

        public FilteredLisLettersInAdmin Letters { get; set; }

        public IActionResult OnGet(int pageNum = 1, string filterTitle = "",string filterSenderName="")
        {
            Letters = _letterService.GetLettersByFilterForAdmin(pageNum,filterTitle,filterSenderName);

            ViewData["TotalLetters"] = Letters.Letters.Count;
            ViewData["TotalIsntReaded"] = Letters.Letters.Count(l => l.IsRead == false);

            return Page();
        }
    }
}
