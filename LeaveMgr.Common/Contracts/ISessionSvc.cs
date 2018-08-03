using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaveMgr.Common.Contracts
{
    public interface ISessionSvc
    {
        void SetUserSession(DTOs.SessionDTO session);

        DTOs.SessionDTO GetUserSession();

        void Logout();
    }
}
