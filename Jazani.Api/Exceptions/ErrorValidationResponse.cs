namespace Jazani.Api.Exceptions
{
    public class ErrorValidationResponse:ErrorModel
    {
        public List<ErrorValidationModel> Errors { get; set; }
    }
}
