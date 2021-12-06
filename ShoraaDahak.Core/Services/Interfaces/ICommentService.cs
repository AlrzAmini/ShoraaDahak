using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShoraaDahak.DataLayer.Models.Blog;

namespace ShoraaDahak.Core.Services.Interfaces
{
    public interface ICommentService
    {
        #region Comment Answer

        List<CommentAnswer> GetAnswersByCommentId(int commentId);

        int AddAnswer(CommentAnswer answer);

        int GetBlogIdByCommentAnswerId(int commentAnswerId);

        void DeleteAnswerById(int answerId);

        CommentAnswer GetCommentAnswerById(int cAnswerId);

        void UpdateCommentAnswer(CommentAnswer answer);

        #endregion

        #region Comment

        Tuple<List<Comment>,int> GetCommentsByBlogId(int blogId,int pageNum = 1);

        void AddComment(Comment comment);

        Comment GetCommentById(int commentId);

        void UpdateComment(Comment comment);

        void DeleteCommentById(int commentId);

        #endregion
    }
}
