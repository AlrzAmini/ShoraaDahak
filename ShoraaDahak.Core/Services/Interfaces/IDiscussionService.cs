using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShoraaDahak.Core.DTOs;
using ShoraaDahak.DataLayer.Models.Discussion;

namespace ShoraaDahak.Core.Services.Interfaces
{
    public interface IDiscussionService
    {
        #region Discussions

        int AddDiscussion(Discussion discussion);

        List<SelectListItem> GetImpLevels();

        ShowDiscussionViewModel ShowDiscussion(int discussionId);

        List<Discussion> GetDiscussionsByServiceId(int serviceId);

        #endregion

        #region Answers

        void AddAnswer(Answer answer);

        #endregion
    }
}
