﻿using System;
using System.Collections.Generic;
using System.Text;

namespace RulesForOperationProceeding.Domain.DTOS
{
    public class OperationTypeDTO
    {
        public string OperationName { get; set; }
        public List<RuleDto> Rules{get;set;}
    }
}
