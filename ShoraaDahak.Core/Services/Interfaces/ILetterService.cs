using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
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


        #endregion
    }
}
