using AccountsTestP.Domain.Dtos;
using AccountsTestP.Domain.Models;

namespace AccountsTestP.Service.Dxos
{
    /// <summary>
    /// Класс методов для преобразования сущности модели счета в с DTO счета для передачи
    /// </summary>
    public interface IAccountDxos
    {
        /// <summary>
        /// Преобразования сущности модели счета в с DTO счета для передачи
        /// </summary>
        /// <param name="entry">Объект типа модели счета </param>
        /// <returns>Объект типа DTO счета </returns>
        AccountDto MapAccountDto(AccountModel entry);
    }
}
