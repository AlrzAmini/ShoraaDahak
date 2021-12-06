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

        public int AddAnswer(CommentAnswer answer)
        {
            _context.CommentAnswers.Add(answer);
            _context.SaveChanges();

            return answer.CAnswerId;
        }

        public void AddComment(Comment comment)
        {
            _context.Comments.Add(comment);
            _context.SaveChanges();
        }

        public void DeleteAnswerById(int answerId)
        {
            var answer = GetCommentAnswerById(answerId);

            answer.IsDelete = true;

            UpdateCommentAnswer(answer);
        }

        public void DeleteCommentById(int commentId)
        {
            var comment = GetCommentById(commentId);

            comment.IsDelete = true;

            UpdateComment(comment);
        }

        public List<CommentAnswer> GetAnswersByCommentId(int commentId)
        {
            return _context.CommentAnswers.Include(a=>a.User).Where(a => a.CommentId == commentId).ToList();
        }

        public int GetBlogIdByCommentAnswerId(int commentAnswerId)
        {
            var cA = _context.CommentAnswers
                .Include(a => a.Comment)
                .SingleOrDefault(a => a.CAnswerId == commentAnswerId);

            return cA.Comment.BlogId;
        }

        public CommentAnswer GetCommentAnswerById(int cAnswerId)
        {
            return _context.CommentAnswers.SingleOrDefault(a => a.CAnswerId == cAnswerId);
        }

        public Comment GetCommentById(int commentId)
        {
            return _context.Comments.SingleOrDefault(c => c.CommentId == commentId);
        }

        public Tuple<List<Comment>, int> GetCommentsByBlogId(int blogId, int pageNum = 1)
        {
            int take = Pagings.TakeCommentPerPage;
            int skip = (pageNum - 1) * take;

            var res = _context.Comments.Include(c=>c.Answers).Include(c=>c.User).Where(c => c.BlogId == blogId).OrderByDescending(c=>c.CommentCreateDate).ToList();

            int totalPage = (int)Math.Ceiling((decimal)res.Count() / take);

            return Tuple.Create(res.Skip(skip).Take(take).ToList(), totalPage);
        }

        public void UpdateComment(Comment comment)
        {
            _context.Comments.Update(comment);
            _context.SaveChanges();
        }

        public void UpdateCommentAnswer(CommentAnswer answer)
        {
            _context.CommentAnswers.Update(answer);
            _context.SaveChanges();
        }
    }
}
