namespace Jazani.Api.Exceptions
{
    public class ErrorResponse
    {
        public string Message { get; set; }
        public List<ErrorValidationModel> Errors { get; set; }
    }
}
