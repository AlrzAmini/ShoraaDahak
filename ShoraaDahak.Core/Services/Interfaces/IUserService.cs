using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShoraaDahak.Core.DTOs;
using ShoraaDahak.DataLayer.Models.User;

namespace ShoraaDahak.Core.Services.Interfaces
{
    public interface IUserService
    {

        #region Register

        bool IsEmailExist(string email);

        bool IsNCodeExist(int nCode);

        int AddUser(User user);

        #endregion

        #region Login

        User IsUserValid(LoginViewModel login);

        #endregion

        #region Active User

        bool ActiveUser(string activeCode);

        #endregion

    }
}
