using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ShoraaDahak.Core.DTOs;
using ShoraaDahak.Core.Services.Interfaces;
using ShoraaDahak.DataLayer.Context;
using ShoraaDahak.DataLayer.Models.Discussion;

namespace ShoraaDahak.Core.Services
{
    public class DiscussionService : IDiscussionService
    {
        private readonly ShooraDahakContext _context;

        public DiscussionService(ShooraDahakContext context)
        {
            _context = context;
        }

        public void AddAnswer(Answer answer)
        {
            _context.Answers.Add(answer);
            _context.SaveChanges();
        }

        public int AddDiscussion(Discussion discussion)
        {
            discussion.DiscussionCreateDate = DateTime.Now;

            _context.Discussions.Add(discussion);
            _context.SaveChanges();

            return discussion.DiscussionId;
        }

        public List<Discussion> GetDiscussionsByServiceId(int serviceId)
        {
            return _context.Discussions.Where(d => d.ServiceId == serviceId)
                .Include(d=>d.User)
                .Include(d=>d.Answers)
                .Include(d=>d.DiscussionImpLevel)
                .Include(d=>d.Service)
                .ToList();
        }

        public List<SelectListItem> GetImpLevels()
        {
            return _context.DiscussionImpLevels
                .Select(s => new SelectListItem()
                {
                    Value = s.ImpLevelId.ToString(),
                    Text = s.ImpLevelTitle
                }).ToList();
        }

        public ShowDiscussionViewModel ShowDiscussion(int discussionId)
        {
            var discussion = new ShowDiscussionViewModel()
            {
                Discussion = _context.Discussions.Include(d => d.DiscussionImpLevel).Include(d => d.Answers).Include(d => d.User)
                    .FirstOrDefault(d => d.DiscussionId == discussionId),
                Answers = _context.Answers.Where(a => a.DiscussionId == discussionId).Include(a => a.User).ToList()
            };

            return discussion;
        }
    }
}
