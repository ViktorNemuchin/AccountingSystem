using RulesForOperationProceeding.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RulesForOperationProceeding.Data.IRepositories
{
    public interface  IRuleRepository
    {
        public Task AddRule(RulesModel rule);
        public Task AddRules(List<RulesModel> rules); 
        public Task<RulesModel> GetRuleEntry(Guid ruleId);
        public IAsyncEnumerable<RulesModel> GetRulesForoperationTypeList(Guid operationId);
        public void DeleteRule(RulesModel rule);
        public void DeleteAlloperationrules(List<RulesModel> rules);
        public void UpdateRule(RulesModel rule);
        public void UpdateRules(List<RulesModel> rules);
    }
}
