using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public void UpdateLetterTo(LetterTo letterTo)
        {
            _context.LetterTos.Update(letterTo);
            _context.SaveChanges();
        }
    }
}
