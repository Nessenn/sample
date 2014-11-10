namespace CustomerManager.Models
{
    public class OkApiResponseWithData<T>: BaseApiResponse
    {
        public T Data { get; set; }

        public OkApiResponseWithData(T data)
        {
            this.Data = data;
            this.Status = "ok";
        }
    }
}