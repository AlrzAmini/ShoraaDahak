using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ShoraaDahak.Core.Consts;
using ShoraaDahak.Core.Convertors;
using ShoraaDahak.Core.DTOs;
using ShoraaDahak.Core.Generators;
using ShoraaDahak.Core.Security;
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
            if (letterFileUp != null && letterFileUp.IsImage())
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

        public void AddLetterAnswer(LetterAnswer letterAnswer)
        {
            letterAnswer.CreateDate = DateTime.Now;
            _context.LetterAnswers.Add(letterAnswer);
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

        public List<LetterAnswer> GetLetterAnswersForLetterSender(int recieverId)
        {
            return _context.LetterAnswers
                .Include(a=>a.User)
                .Include(a => a.Letter)
                .ThenInclude(l => l.User)
                .Where(a => a.Letter.SenderId == recieverId).ToList();
        }

        public Letter GetLetterById(int letterId)
        {
            return _context.Letters.Include(l => l.LetterTo).Include(l => l.User).SingleOrDefault(l => l.LetterId == letterId);
        }

        public FilteredLisLettersInAdmin GetLettersByFilterForAdmin(int pageNum = 1, string filterTitle = "", string filterSenderName = "")
        {
            IQueryable<ShowListedLettersInAdmin> result = _context.Letters.Select(l => new ShowListedLettersInAdmin()
            {
                UserId = l.SenderId,
                IsRead = l.IsRead,
                LetterId = l.LetterId,
                SendDate = l.LetterSendDate,
                SenderName = l.User.Name,
                Title = l.LetterTitle
            });

            if (!string.IsNullOrEmpty(filterTitle))
            {
                result = result.Where(r => r.Title.Contains(filterTitle));
            }

            if (!string.IsNullOrEmpty(filterSenderName))
            {
                result = result.Where(r => r.SenderName.Contains(filterSenderName));
            }

            int take = Pagings.TakeLetterInIndexAdmin;
            int skip = (pageNum - 1) * take;

            FilteredLisLettersInAdmin list = new FilteredLisLettersInAdmin()
            {
                Letters = result.OrderByDescending(l => l.IsRead).Skip(skip).Take(take).ToList(),
                CurrentPage = pageNum,
                TotalPages = (int)Math.Ceiling((decimal)result.Count() / take)
            };

            return list;
        }

        public List<Letter> GetLettersForSender(int senderId)
        {
            return _context.Letters
                .Include(l=>l.User)
                .Include(l=>l.LetterTo)
                .Where(l => l.SenderId == senderId).ToList();
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

        public void UpdateLetter(Letter letter)
        {
            _context.Letters.Update(letter);
            _context.SaveChanges();
        }

        public void UpdateLetterTo(LetterTo letterTo)
        {
            _context.LetterTos.Update(letterTo);
            _context.SaveChanges();
        }
    }
}
