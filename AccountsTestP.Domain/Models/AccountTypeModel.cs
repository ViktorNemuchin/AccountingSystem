using System;
using System.Collections.Generic;
using System.Text;

namespace AccountsTestP.Domain.Models
{
    /// <summary>
    /// Модель описания таблицы типов счетов 
    /// </summary>
    public class AccountTypeModel:BaseModel
    {   
        /// <summary>
        /// Номер типа счета
        /// </summary>
        public int AccountTypeNumber { get; private set; }
        /// <summary>
        /// Название типа счета
        /// </summary>
        public string AccountTypeName { get; private set; }
        /// <summary>
        /// Флаг автивного/пассивного счета
        /// </summary>
        public bool IsActive { get; private set; }
        /// <summary>
        /// Конструктор модели описания таблицы типов счетов
        /// </summary>
        /// <param name="accountTypeNumber">Id типа счета</param>
        /// <param name="accountTypeName">Название типа счета</param>
        /// <param name="isActive">Флаг активного /пассивного счета</param>
        public AccountTypeModel(int accountTypeNumber, string accountTypeName, bool isActive) 
        {
            AccountTypeNumber = accountTypeNumber;
            AccountTypeName = accountTypeName;
            IsActive = isActive;
        }
      

    }
}
