using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using AccountsTestP.Domain.Models;
using AccountsTestP.Domain.Dtos;

namespace AccountsTestP.Service.Dxos
{
    public class AccountHistoryDxos: IAccountHistoryDxos
    {
        private readonly IMapper _mapper;

        public AccountHistoryDxos() 
        {
            var configuration = new MapperConfiguration(config =>
           {
               config.CreateMap<AccountHistoryModel, AccountHistoryDto>()
               .ForMember(dst => dst.Id, opt => opt.MapFrom(src => src.Id))
               .ForMember(dst => dst.AccountId, opt => opt.MapFrom(src => src.AccountId))
               .ForMember(dst => dst.Amount, opt => opt.MapFrom(src => src.Amount))
               .ForMember(dst => dst.ChangedAt, opt => opt.MapFrom(src => src.ChangedAt));
           });
           
            _mapper = configuration.CreateMapper();
        }

        public AccountHistoryDto MapAccountHistoryDto(AccountHistoryModel entry)
        {
            return _mapper.Map<AccountHistoryModel, AccountHistoryDto>(entry);
        }
    }
}
