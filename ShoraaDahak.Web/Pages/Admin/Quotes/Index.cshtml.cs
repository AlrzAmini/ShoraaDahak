using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShoraaDahak.Core.Services.Interfaces;
using ShoraaDahak.DataLayer.Models.quote;

namespace ShoraaDahak.Web.Pages.Admin.Quotes
{
    public class IndexModel : PageModel
    {
        private readonly IQuoteService _quoteService;

        public IndexModel(IQuoteService quoteService)
        {
            _quoteService = quoteService;
        }

        public List<Quote> Quotes { get; set; }

        public IActionResult OnGet()
        {
            Quotes = _quoteService.GetAllQuotesForAdmin();

            ViewData["TotalQuotes"] = Quotes.Count;
            return Page();
        }

        public IActionResult OnGetDelete(int Id)
        {
            _quoteService.DeleteQuoteById(Id);

            return RedirectToPage("Index");
        }
    }
}
