namespace Services.NetCore.Crosscutting.Core
{
    public class ResponseBase
    {
        public string Message { get; set; }
        public string ValidationErrorMessage { get; set; }
        public bool Success { get; set; }
    }

    public class Response : ResponseBase
    {

    }
}