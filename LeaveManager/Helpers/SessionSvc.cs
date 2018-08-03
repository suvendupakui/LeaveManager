using LeaveManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LeaveManager.Helpers
{
    public class SessionSvc : LeaveMgr.Common.Contracts.ISessionSvc
    {
        public static string _sessionIdentifier = "USER_SESSION";
        public void SetUserSession(LeaveMgr.Common.DTOs.SessionDTO session)
        {
            System.Web.HttpContext.Current.Session[_sessionIdentifier] = session;
        }

        public LeaveMgr.Common.DTOs.SessionDTO GetUserSession()
        {
            return System.Web.HttpContext.Current.Session[_sessionIdentifier] as LeaveMgr.Common.DTOs.SessionDTO;
        }

        public void Logout()
        {
            System.Web.HttpContext.Current.Session.Abandon();
            System.Web.HttpContext.Current.Session.RemoveAll();
            System.Web.HttpContext.Current.Session[_sessionIdentifier] = null;
        }
    }
}