namespace RulesForOperationProceeding.Domain.DTOS
{
    /// <summary>
    /// DTO ответа системы при возникновении ошибок
    /// </summary>
    public class ResponseMessageDto : ResponseBaseDto
    {
       /// <summary>
       /// Текст сообщения
       /// </summary>
        public string Message { get; set; }
    }
}
