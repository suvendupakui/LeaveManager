using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LeaveMgr.Common.DTOs;

namespace LeaveMgr.Common.Contracts
{
    public interface ICRUDSvc<I,O>
    {
        StatusDTO<O> Insert(I data);

        StatusDTO<O> Update(I data);

        StatusDTO<O> Delete(I data);

        StatusDTO<List<O>> Select(I data);

        StatusDTO<O> Select(int rowId);

    }
}
