using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ShoraaDahak.Core.Consts;
using ShoraaDahak.Core.Services.Interfaces;
using ShoraaDahak.DataLayer.Context;
using ShoraaDahak.DataLayer.Models.Blog;

namespace ShoraaDahak.Core.Services
{
    public class CommentService : ICommentService
    {
        private readonly ShooraDahakContext _context;

        public CommentService(ShooraDahakContext context)
        {
            _context = context;
        }

        public void AddComment(Comment comment)
        {
            _context.Comments.Add(comment);
            _context.SaveChanges();
        }

        public List<CommentAnswer> GetAnswersByCommentId(int commentId)
        {
            return _context.CommentAnswers.Include(a=>a.User).Where(a => a.CommentId == commentId).ToList();
        }

        public Tuple<List<Comment>, int> GetCommentsByBlogId(int blogId, int pageNum = 1)
        {
            int take = Pagings.TakeCommentPerPage;
            int skip = (pageNum - 1) * take;

            var res = _context.Comments.Include(c=>c.Answers).Include(c=>c.User).Where(c => c.BlogId == blogId).OrderByDescending(c=>c.CommentCreateDate).ToList();

            int totalPage = (int)Math.Ceiling((decimal)res.Count() / take);

            return Tuple.Create(res.Skip(skip).Take(take).ToList(), totalPage);
        }
    }
}
