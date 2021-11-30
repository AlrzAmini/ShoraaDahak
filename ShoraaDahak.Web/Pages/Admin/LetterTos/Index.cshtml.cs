using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShoraaDahak.Core.Services.Interfaces;
using ShoraaDahak.DataLayer.Models.Letter;

namespace ShoraaDahak.Web.Pages.Admin.LetterTos
{
    public class IndexModel : PageModel
    {
        private readonly ILetterService _letterService;

        public IndexModel(ILetterService letterService)
        {
            _letterService = letterService;
        }

        public List<LetterTo> LetterTos { get; set; }

        public IActionResult OnGet()
        {
            LetterTos = _letterService.GetAllLetterTos();
            return Page();
        }
    }
}
