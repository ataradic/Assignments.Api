﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssignmentsAPI.DTOs
{
    public class UserParamsDto
    {
       
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
        
    }
}
