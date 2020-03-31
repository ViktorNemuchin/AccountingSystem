﻿using System;
using System.Collections.Generic;
using System.Text;

namespace RulesForOperationProceeding.Domain.DTOS
{
    public class RuleDto
    {
        public Guid RuleId { get; set; }
        public string SourceAccount { get; set; }
        public string DestinationAccount { get; set; }
        public int RuleOrderNumber { get; set; }
        public string Formula { get; set; }
        public string Description { get; set; }
        public DateTimeOffset DateFrom { get; set; }
        public Guid OperationTypeId { get; set; }
    }
}
