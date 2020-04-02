

namespace ConvertOperationToTransfer.Domain.Dtos
{
    /// <summary>
    /// DTO результата успешно выполненного запроса или команды
    /// </summary>
    /// <typeparam name="T">Тип объекта выводимой информации</typeparam>
    public class ResponseOkDto<T> : ResponseBaseDto
    {
        /// <summary>
        /// Результат запроса или команды
        /// </summary>
        public T Result { get; set; }

    }
}
