﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaveMgr.Common.DTOs
{
    public class ExamSubTypeDTO
    {
        public int ExamSubTypeId { get; set; }

        public UserMasterDTO CreatedBy { get; set; }

        public DateTime? CreatedDate { get; set; }

        public UserMasterDTO UpdatedBy { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public bool Active { get; set; }

        public string ExamSubTypeDescription { get; set; }
    }
}
