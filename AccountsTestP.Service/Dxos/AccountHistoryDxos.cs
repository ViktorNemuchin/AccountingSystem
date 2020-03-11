using AccountsTestP.Domain.Dtos;
using AccountsTestP.Domain.Models;
using AutoMapper;
using System.Collections.Generic;

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
               .ForMember(dst => dst.SourceBalance, opt => opt.MapFrom(src => src.SourceAccountBalance))
               .ForMember(dst => dst.DestinationBalance, opt => opt.MapFrom(src => src.DestinationAccountBalance))
               .ForMember(dst => dst.ChangedAt, opt => opt.MapFrom(src => src.CreationDate))
               .ForMember(dst => dst.DueDateTime, opt => opt.MapFrom(src => src.DueDate))
               .ForMember(dst => dst.Description, opt => opt.MapFrom(src => src.Description))
               .ForMember(dst => dst.OperationId, opt => opt.MapFrom(src => src.OperationId));
           });

            _mapper = configuration.CreateMapper();
        }

        public List<AccountHistoryDto> MapAccountHistoryDto(List<AccountHistoryModel> entry)
        {
            return _mapper.Map<List<AccountHistoryDto>>(entry);
        }
    }
}
