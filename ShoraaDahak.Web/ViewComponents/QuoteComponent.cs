using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ShoraaDahak.Core.Services.Interfaces;

namespace ShoraaDahak.Web.ViewComponents
{
    public class QuoteComponent : ViewComponent
    {
        private readonly IQuoteService _quoteService;

        public QuoteComponent(IQuoteService quoteService)
        {
            _quoteService = quoteService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return await Task.FromResult((IViewComponentResult)View("Quotes", _quoteService.GetAllQuotesForAdmin()));
        }
    }
}
