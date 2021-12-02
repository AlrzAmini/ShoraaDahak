using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using ShoraaDahak.DataLayer.Models.quote;

namespace ShoraaDahak.Core.Services.Interfaces
{
    public interface IQuoteService
    {
        void AddQuote(Quote quote , IFormFile imgQuote);

        List<Quote> GetAllQuotesForAdmin();

        Quote GetQuoteById(int quoteId);

        void UpdateQuote(Quote quote, IFormFile imgQuote);

        void DeleteQuoteById(int quoteId);
    }
}
