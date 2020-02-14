using AccountsTestP.Domain.Dtos;
using AccountsTestP.Domain.Models;
using AutoMapper;

namespace AccountsTestP.Service.Dxos
{
    public class AccountHistoryDxos : IAccountHistoryDxos
    {
        private readonly IMapper _mapper;

        public AccountHistoryDxos()
        {
            var configuration = new MapperConfiguration(config =>
           {
               config.CreateMap<AccountHistoryModel, AccountHistoryDto>()
               .ForMember(dst => dst.Id, opt => opt.MapFrom(src => src.Id))
               .ForMember(dst => dst.SourceAccountId, opt => opt.MapFrom(src => src.SourceAccountId))
               .ForMember(dst => dst.DestinationAccounId, opt => opt.MapFrom(src => src.DestinationAccountId))
               .ForMember(dst => dst.Amount, opt => opt.MapFrom(src => src.Amount))
               .ForMember(dst => dst.ChangedAt, opt => opt.MapFrom(src => src.ChangedAt))
               .ForMember(dst => dst.ActualDateTime, opt => opt.MapFrom(src => src.ActualDate));
           });

            _mapper = configuration.CreateMapper();
        }

        public AccountHistoryDto MapAccountHistoryDto(AccountHistoryModel entry)
        {
            return _mapper.Map<AccountHistoryModel, AccountHistoryDto>(entry);
        }
    }
}
