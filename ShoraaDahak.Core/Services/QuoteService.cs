using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using ShoraaDahak.Core.Convertors;
using ShoraaDahak.Core.Generators;
using ShoraaDahak.Core.Security;
using ShoraaDahak.Core.Services.Interfaces;
using ShoraaDahak.DataLayer.Context;
using ShoraaDahak.DataLayer.Models.quote;

namespace ShoraaDahak.Core.Services
{
    public class QuoteService : IQuoteService
    {
        private readonly ShooraDahakContext _context;

        public QuoteService(ShooraDahakContext context)
        {
            _context = context;
        }

        public void AddQuote(Quote quote, IFormFile imgQuote)
        {
            #region Add And Check Image

            quote.QuoteImageName = "DefualtQ.jpg";
            if (imgQuote != null && imgQuote.IsImage())
            {
                quote.QuoteImageName = CodeGenerator.GenerateUniqCode() + Path.GetExtension(imgQuote.FileName);
                string imgPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Quote/image", quote.QuoteImageName);

                using (var stream = new FileStream(imgPath, FileMode.Create))
                {
                    imgQuote.CopyTo(stream);
                }

                ImageConvertor imgResizer = new ImageConvertor();
                string thumbPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Quote/thumb", quote.QuoteImageName);
                imgResizer.Image_resize(imgPath, thumbPath, 125);
            }

            #endregion

            _context.Quotes.Add(quote);
            _context.SaveChanges();
        }

        public void DeleteQuoteById(int quoteId)
        {
            Quote quote = GetQuoteById(quoteId);

            // Delete Image & Thumb
            if (quote.QuoteImageName != null)
            {
                if (quote.QuoteImageName != "DefualtQ.jpg")
                {
                    string imgDeletePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Quote/image",
                        quote.QuoteImageName);
                    if (File.Exists(imgDeletePath))
                    {
                        File.Delete(imgDeletePath);
                    }

                    string thumbDeletePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Service/thumb",
                        quote.QuoteImageName);
                    if (File.Exists(thumbDeletePath))
                    {
                        File.Delete(thumbDeletePath);
                    }
                }
            }

            _context.Quotes.Remove(quote);
            _context.SaveChanges();
        }

        public List<Quote> GetAllQuotesForAdmin()
        {
            return _context.Quotes.ToList();
        }

        public Quote GetQuoteById(int quoteId)
        {
            return _context.Quotes.Find(quoteId);
        }

        public void UpdateQuote(Quote quote, IFormFile imgQuote)
        {
            #region Add And Check Image

            if (imgQuote != null && imgQuote.IsImage())
            {
                // if had image : Delete it
                if (quote.QuoteImageName != "DefualtQ.jpg")
                {
                    string imgDeletePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Quote/image",
                        quote.QuoteImageName);
                    if (File.Exists(imgDeletePath))
                    {
                        File.Delete(imgDeletePath);
                    }

                    string thumbDeletePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Quote/thumb",
                        quote.QuoteImageName);
                    if (File.Exists(thumbDeletePath))
                    {
                        File.Delete(thumbDeletePath);
                    }
                }
                quote.QuoteImageName = CodeGenerator.GenerateUniqCode() + Path.GetExtension(imgQuote.FileName);
                string imgPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Quote/image", quote.QuoteImageName);

                using (var stream = new FileStream(imgPath, FileMode.Create))
                {
                    imgQuote.CopyTo(stream);
                }

                ImageConvertor imgResizer = new ImageConvertor();
                string thumbPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Quote/thumb", quote.QuoteImageName);
                imgResizer.Image_resize(imgPath, thumbPath, 125);
            }

            #endregion

            _context.Quotes.Update(quote);
            _context.SaveChanges();
        }
    }
}
