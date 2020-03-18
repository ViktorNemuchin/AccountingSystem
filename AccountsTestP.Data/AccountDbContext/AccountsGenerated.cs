using AccountsTestP.Domain.Models;
using System.Collections.Generic;

namespace AccountsTestP.Data.AccountDbContext
{
    /// <summary>
    /// Класс генератор стандартных знаяений необходимых для работы сервиса
    /// </summary>
    public class AccountEntityGenerator
    {
        /// <summary>
        /// Конструктор генераторв стандартных знаяений необходимых для работы сервиса
        /// </summary>
        public AccountEntityGenerator()
        { }
        /// <summary>
        /// Добавление стандартных значений для таблицы типов счетов
        /// </summary>
        /// <returns></returns>
        public List<AccountTypeModel> SetAccountTypes() 
        {
            return new List<AccountTypeModel>
            {
                new AccountTypeModel(1,"Плановый платеж",true),
                new AccountTypeModel(2 ,"Касса",true),
                new AccountTypeModel(3, "Просроченный ОД Физическим лицам",true),
                new AccountTypeModel(4,"Просроченные % Физическим лицам",true),
                new AccountTypeModel(5,"Переплата", false),
                new AccountTypeModel(6,"ОД", true),
                new AccountTypeModel(7, "Начисление %", true),
                new AccountTypeModel(8, "Уплата %", false),
                new AccountTypeModel(9, "Пени", true),
                new AccountTypeModel(10, "Доходы",false),
                new AccountTypeModel(11, "Просроченный ОД Физическим лицам - нерезидентам", true),
                new AccountTypeModel(12, "Просроченные % Физическим лицам - нерезидентам",true),
                new AccountTypeModel(13, "Требования по прочим операциям",true),
                new AccountTypeModel(14, "Резервы на возможные потери", false),
                new AccountTypeModel(15, "Обязательства по уплате процентов", false),
                new AccountTypeModel(16, "Начисленные проценты по предоставленным (размещенным) денежным средствам", true),
                new AccountTypeModel(17, "Начисленные прочие доходы по микрозаймам (в том числе по целевым микрозаймам), выданным физическим лицам", true),
                new AccountTypeModel(18, "Расчеты по прочим доходам по микрозаймам (в том числе по целевым микрозаймам), выданным физическим лицам", false),
                new AccountTypeModel(19, "Начисленные расходы, связанные с выдачей микрозаймов (в том числе целевых микрозаймов) физическим лицам", false),
                new AccountTypeModel(20, "Расчеты по расходам, связанным с выдачей микрозаймов (в том числе целевых микрозаймов) физическим лицам",true),
                new AccountTypeModel(21, "Корректировки, увеличивающие стоимость средств, предоставленных по микрозаймам (в том числе целевым микрозаймам), выданным физическим лицам",true),
                new AccountTypeModel(22, "Корректировки, уменьшающие стоимость средств, предоставленных по микрозаймам (в том числе целевым микрозаймам), выданным физическим лицам", false),
                new AccountTypeModel(23, "Резервы под обесценение по микрозаймам (в том числе по целевым микрозаймам), выданным физическим лицам", false),
                new AccountTypeModel(24, "Переоценка, увеличивающая стоимость микрозаймов (в том числе целевых микрозаймов), выданных физическим лицам", true),
                new AccountTypeModel(25, "Переоценка, уменьшающая стоимость микрозаймов (в том числе целевых микрозаймов), выданных физическим лицам", false)
            };
        }

    }
}
