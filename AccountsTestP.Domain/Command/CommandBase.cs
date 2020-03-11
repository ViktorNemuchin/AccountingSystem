using MediatR;

namespace AccountsTestP.Domain.Command
{
    /// <summary>
    /// Абстрактный базовый класс для всех команд
    /// </summary>
    /// <typeparam name="T">Тип ответа после выполнения команды</typeparam>
    public abstract class CommandBase<T> : IRequest<T> where T : class
    {

    }

}
