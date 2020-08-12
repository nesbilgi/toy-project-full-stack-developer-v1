namespace Data.Models
{
    public class Response<T>
    {
        public Response(){
        }

        public Response(T data)
        {
            Succeded = true;
            Message = string.Empty;
            Data = data;
        }

        public T Data {get;set;}
        public bool Succeded { get; set; }

        public string Message { get; set; }
    }
}