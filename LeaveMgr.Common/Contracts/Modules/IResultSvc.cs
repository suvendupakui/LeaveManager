using LeaveMgr.Common.DTOs;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaveMgr.Common.Contracts.Modules
{
    public interface IResultSvc
    {
        List<ResultCardDTO> GetResult(int locationId, int standardSectionId, string resultType, DateTime academicSessionStartDate, DateTime academicSessionEndDate);
    }
}
