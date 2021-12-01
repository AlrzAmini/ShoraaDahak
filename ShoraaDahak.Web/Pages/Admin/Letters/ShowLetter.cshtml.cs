using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShoraaDahak.Core.Services.Interfaces;
using ShoraaDahak.DataLayer.Models.Letter;

namespace ShoraaDahak.Web.Pages.Admin.Letters
{
    public class ShowLetterModel : PageModel
    {
        private readonly ILetterService _letterService;

        public ShowLetterModel(ILetterService letterService)
        {
            _letterService = letterService;
        }

        [BindProperty]
        public Letter Letter { get; set; }

        public IActionResult OnGet(int id) // id = letter Id
        {
            Letter = _letterService.GetLetterById(id);

            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _letterService.UpdateLetter(Letter);

            return RedirectToPage("Index");
        }
    }
}
