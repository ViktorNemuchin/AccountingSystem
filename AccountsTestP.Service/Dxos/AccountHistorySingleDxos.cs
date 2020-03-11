using System;
using System.Collections.Generic;
using System.Text;
using AccountsTestP.Domain.Command;
using AccountsTestP.Domain.Dtos;
using AccountsTestP.Domain.Models;
using AutoMapper;

namespace AccountsTestP.Service.Dxos
{
    public class AccountHistorySingleDxos: IAccountHistorySingleDxos
    {
        private readonly IMapper _mapper;

        public AccountHistorySingleDxos() 
        {
            var configuration = new MapperConfiguration(config =>
            {
                config.CreateMap<AccountHistoryModel, AccountHistoryDto>()
               .ForMember(dst => dst.Id, opt => opt.MapFrom(src => src.Id))
               .ForMember(dst => dst.SourceAccountId, opt => opt.MapFrom(src => src.SourceAccountId))
               .ForMember(dst => dst.DestinationAccounId, opt => opt.MapFrom(src => src.DestinationAccountId))
               .ForMember(dst => dst.Amount, opt => opt.MapFrom(src => src.Amount))
               .ForMember(dst => dst.SourceBalance, opt => opt.MapFrom(src => src.SourceAccountBalance))
               .ForMember(dst => dst.DestinationBalance, opt => opt.MapFrom(src => src.DestinationAccountBalance))
               .ForMember(dst => dst.ChangedAt, opt => opt.MapFrom(src => src.CreationDate))
               .ForMember(dst => dst.DueDateTime, opt => opt.MapFrom(src => src.DueDate))
               .ForMember(dst => dst.Description, opt => opt.MapFrom(src => src.Description))
               .ForMember(dst => dst.OperationId, opt => opt.MapFrom(src => src.OperationId));
            });

            _mapper = configuration.CreateMapper();
        }

        public AccountHistoryDto MapAccountHistoryModel(AccountHistoryModel entry)
        {
            return _mapper.Map<AccountHistoryDto>(entry);
        }
    }
}
