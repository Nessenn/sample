namespace CustomerManager.Models
{
    public class ErrorApiResponse: BaseApiResponse
    {
        public string Message { get; set; }

        public ErrorApiResponse(string message)
        {
            this.Message = message;
            this.Status = "error";
        }
    }
}