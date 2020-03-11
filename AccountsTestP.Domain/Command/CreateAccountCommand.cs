using AccountsTestP.Domain.Dtos;
using System;

namespace AccountsTestP.Domain.Command
{
    /// <summary>
    /// Класс команды для создания счета в таблице счетов
    /// </summary>
    public class CreateAccountCommand : CommandBase<ResponseBaseDto>
    {
        /// <summary>
        /// Конструтор команды для создания счета в таблице счета
        /// </summary>
        /// <param name="initialBalance">Изначальный баланс</param>
        /// <param name="accountType">Тип счета</param>
        /// <param name="accountNumber">Номер счета</param>
        public CreateAccountCommand(decimal initialBalance, 
                                    int accountType, 
                                    string accountNumber)
        {
            InitialBalance = initialBalance;
            AccountNumber = accountNumber;
            AccountType = accountType;
        }
        /// <summary>
        /// Изначальный баланс
        /// </summary>
        public decimal InitialBalance { get; private set; }
        /// <summary>
        /// Номер счета
        /// </summary>
        public string AccountNumber { get; private set; }
        /// <summary>
        /// Тип счета
        /// </summary>
        public int AccountType { get; private set; }


    }
}
