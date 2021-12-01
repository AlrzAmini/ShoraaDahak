using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShoraaDahak.Core.DTOs;
using ShoraaDahak.DataLayer.Models.Letter;

namespace ShoraaDahak.Core.Services.Interfaces
{
    public interface ILetterService
    {
        #region Letter To ?

        List<LetterTo> GetAllLetterTos();

        void AddLetterTo(LetterTo letterTo);

        LetterTo GetLetterToById(int id);

        void UpdateLetterTo(LetterTo letterTo);

        void DeleteLetterTo(LetterTo letterTo);

        List<SelectListItem> GetLetterTosForSendLetter();

        #endregion

        #region letter

        void AddLetter(Letter letter,IFormFile letterFileUp);

        Letter GetLetterById(int letterId);

        void UpdateLetter(Letter letter);

        FilteredLisLettersInAdmin GetLettersByFilterForAdmin(int pageNum=1,string filterTitle="",string filterSenderName = "");

        //void IsLetterReaded();


        #endregion
    }
}
