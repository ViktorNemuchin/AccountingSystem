using System;
using System.Collections.Generic;
using System.Text;
using AccountsTestP.Domain.Command;
using AccountsTestP.Domain.Dtos;
using AccountsTestP.Domain.Models;
using AutoMapper;

namespace AccountsTestP.Service.Dxos
{
    public class AccountCommandDxos: IAccountCommandDxos
    {
        private readonly IMapper _mapper;

        AccountCommandDxos() 
        {
            var configuration = new MapperConfiguration(config =>
            {
                config.CreateMap<CreateAccountCommand, AccountModel>()
                .ForMember(dst => dst.AccountNumber, opt => opt.MapFrom(src => src.AccountNumber))
                .ForMember(dst => dst.Balance, opt => opt.MapFrom(src => src.InitialBalance))
                .ForMember(dst => dst.AccountNumber, opt => opt.MapFrom(src => src.AccountNumber))
                .ForMember(dst => dst.AccountType, opt => opt.MapFrom(src => src.AccountType));
            });

            _mapper = configuration.CreateMapper();
        }

        public AccountModel MapAccountModel(CreateAccountCommand entry)
        {
            return _mapper.Map<CreateAccountCommand, AccountModel>(entry);
        }
    }
}
