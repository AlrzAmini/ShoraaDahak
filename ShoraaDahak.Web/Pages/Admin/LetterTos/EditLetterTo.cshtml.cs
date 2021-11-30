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
    public class EditLetterToModel : PageModel
    {
        private readonly ILetterService _letterService;

        public EditLetterToModel(ILetterService letterService)
        {
            _letterService = letterService;
        }

        [BindProperty]
        public LetterTo LetterTo { get; set; }

        public IActionResult OnGet(int id)
        {
            LetterTo = _letterService.GetLetterToById(id);
            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _letterService.UpdateLetterTo(LetterTo);

            return RedirectToPage("Index");
        }
    }
}
