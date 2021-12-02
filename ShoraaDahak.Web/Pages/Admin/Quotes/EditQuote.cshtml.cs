using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShoraaDahak.Core.Services.Interfaces;
using ShoraaDahak.DataLayer.Models.quote;

namespace ShoraaDahak.Web.Pages.Admin.Quotes
{
    public class EditQuoteModel : PageModel
    {
        private readonly IQuoteService _quoteService;

        public EditQuoteModel(IQuoteService quoteService)
        {
            _quoteService = quoteService;
        }

        [BindProperty]
        public Quote Quote { get; set; }

        public IActionResult OnGet(int id)
        {
            Quote = _quoteService.GetQuoteById(id);

            return Page();
        }

        public IActionResult OnPost(IFormFile imgQuoteUp)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _quoteService.UpdateQuote(Quote, imgQuoteUp);

            return RedirectToPage("Index");
        }
    }
}
