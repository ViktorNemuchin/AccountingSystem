using RulesForOperationProceeding.Domain.DTOS;
using System;
using System.Collections.Generic;
using System.Text;

namespace RulesForOperationProceeding.Domain.Queries
{
    public class GetOperationTypeByOperationTypeNameQuery:BaseQuery<ResponseBaseDto>
    {
        public string OperationTypeName { get; private set; }
        public GetOperationTypeByOperationTypeNameQuery(string operationTypeName) => (OperationTypeName) = (operationTypeName);
    }
}
