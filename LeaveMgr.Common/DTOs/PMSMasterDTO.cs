﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaveMgr.Common.DTOs
{
    public class PMSMasterDTO : EmployeeAppraisalMasterDTO
    {
        public int  PMSMasterId{get;set;}

        public string PMSAppraisalType { get; set; }   

    }
}
