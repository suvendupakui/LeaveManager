using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaveMgr.Common.Contracts
{
   public  interface IResetPasswordSvc
    {
        bool ResetPassword(string newPassword,int UserMasterId);

        string GetPasswordForUser(int UserMasterId);
    }
}
