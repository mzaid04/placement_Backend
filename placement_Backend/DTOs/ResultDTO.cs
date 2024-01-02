namespace placement_Backend.DTOs
{
    public class ResultDTO<T>
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }

        public T? Result { get; set; }

    }

    public class ResultDTO
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }

    }
}
