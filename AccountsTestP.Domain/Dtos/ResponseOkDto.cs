namespace AccountsTestP.Domain.Dtos
{
    public class ResponseOkDto<T> : ResponseBaseDto
    {

        public T Result { get; set; }

    }
}
