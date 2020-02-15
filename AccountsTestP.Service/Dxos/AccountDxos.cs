using AccountsTestP.Domain.Dtos;
using AccountsTestP.Domain.Models;
using AutoMapper;
namespace AccountsTestP.Service.Dxos
{
    public class AccountDxos : IAccountDxos
    {
        private readonly IMapper _mapper;
        public AccountDxos()
        {
            var configuration = new MapperConfiguration(config =>
            {
                config.CreateMap<AccountModel, AccountDto>()
                .ForMember(dst => dst.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dst => dst.AccountNumber, opt => opt.MapFrom(src => src.AccountNumber))
                .ForMember(dst => dst.Balance, opt => opt.MapFrom(src => src.Balance))
                .ForMember(dst => dst.AccountType, opt => opt.MapFrom(src => src.AccountType))
                .ForMember(dst => dst.OperationId, opt => opt.MapFrom(src => src.OperationId));
            });

            _mapper = configuration.CreateMapper();

        }
        public AccountDto MapAccountDto(AccountModel entry)
        {

            return _mapper.Map<AccountModel, AccountDto>(entry);
        }
    }
}
