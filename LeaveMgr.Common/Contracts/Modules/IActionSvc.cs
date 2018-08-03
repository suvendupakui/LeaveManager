using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LeaveMgr.Common.DTOs;

namespace LeaveMgr.Common.Contracts.Modules
{
    public interface IActionSvc : ICRUDSvc<ActionDTO, ActionDTO>
    {
    }
}
