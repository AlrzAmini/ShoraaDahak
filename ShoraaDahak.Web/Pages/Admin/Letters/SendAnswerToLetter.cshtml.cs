using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShoraaDahak.Core.Services.Interfaces;
using ShoraaDahak.DataLayer.Models.Letter;

namespace ShoraaDahak.Web.Pages.Admin.Letters
{
    public class SendAnswerToLetterModel : PageModel
    {
        private readonly ILetterService _letterService;

        public SendAnswerToLetterModel(ILetterService letterService)
        {
            _letterService = letterService;
        }

        [BindProperty]
        public LetterAnswer LetterAnswer { get; set; }

        public IActionResult OnGet(int id) // id = letterId
        {
            LetterAnswer = new LetterAnswer
            {
                LetterId = id
            };
            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            LetterAnswer.SenderId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));

            _letterService.AddLetterAnswer(LetterAnswer);

            return RedirectToPage("Index");
        }
    }
}
