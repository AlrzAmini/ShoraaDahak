using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShoraaDahak.Core.Convertors;
using ShoraaDahak.Core.Generators;
using ShoraaDahak.Core.Services.Interfaces;
using ShoraaDahak.DataLayer.Context;
using ShoraaDahak.DataLayer.Models.Letter;

namespace ShoraaDahak.Core.Services
{
    public class LetterService : ILetterService
    {
        private readonly ShooraDahakContext _context;

        public LetterService(ShooraDahakContext context)
        {
            _context = context;
        }

        public void AddLetter(Letter letter, IFormFile letterFileUp)
        {
            letter.LetterSendDate = DateTime.Now;
            letter.IsRead = false;

            // Save File
            if (letterFileUp != null)
            {
                letter.LetterFileName = CodeGenerator.GenerateUniqCode() + Path.GetExtension(letterFileUp.FileName);
                string filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Letter", letter.LetterFileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    letterFileUp.CopyTo(stream);
                }
            }

            _context.Letters.Add(letter);
            _context.SaveChanges();
        }

        public void AddLetterTo(LetterTo letterTo)
        {
            _context.LetterTos.Add(letterTo);
            _context.SaveChanges();
        }

        public void DeleteLetterTo(LetterTo letterTo)
        {
            _context.LetterTos.Remove(letterTo);
            _context.SaveChanges();
        }

        public List<LetterTo> GetAllLetterTos()
        {
            return _context.LetterTos.ToList();
        }

        public LetterTo GetLetterToById(int id)
        {
            return _context.LetterTos.SingleOrDefault(l => l.LetterToId == id);
        }

        public List<SelectListItem> GetLetterTosForSendLetter()
        {
            return _context.LetterTos
                .Select(s => new SelectListItem()
                {
                    Value = s.LetterToId.ToString(),
                    Text = s.LetterToTitle
                }).ToList();
        }

        public void UpdateLetterTo(LetterTo letterTo)
        {
            _context.LetterTos.Update(letterTo);
            _context.SaveChanges();
        }
    }
}
