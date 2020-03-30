using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using RulesForOperationProceeding.Data.RulesForOperationProceedingDbContext;
using RulesForOperationProceeding.Domain.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using RulesForOperationProceeding.Data.IRepositories;

namespace RulesForOperationProceeding.Data.Repositories
{
    public class RulesRepository: BaseRepository, IRuleRepository
    {
       
        public RulesRepository(RulesForOperationProceedingDataDbContext context) : base(context: context)
        {
            
        }
        public async Task AddRule(RulesModel rule) => await _context.Rules.AddAsync(rule);
        public async Task AddRules(List<RulesModel> rules) => await _context.Rules.AddRangeAsync(rules);
        public async Task<RulesModel> GetRuleEntry(Guid ruleId) => await _context.Rules.AsNoTracking().Where(x => x.Id == ruleId).FirstOrDefaultAsync();
        public IAsyncEnumerable<RulesModel> GetRulesForoperationTypeList(Guid operationId) => _context.Rules.AsNoTracking().Where(x => x.OperationTypeId == operationId).AsAsyncEnumerable();
        public void DeleteRule(RulesModel rule) => _context.Rules.Remove(rule);
        public void DeleteAlloperationrules(List<RulesModel> rules) => _context.Rules.RemoveRange(rules);
        public void UpdateRule(RulesModel rule) => _context.Rules.Update(rule);
        public void UpdateRules(List<RulesModel> rules) => _context.Rules.UpdateRange(rules);


    }
}
