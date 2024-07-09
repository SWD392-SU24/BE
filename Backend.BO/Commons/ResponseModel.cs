namespace Backend.BO.Commons
{
    public record ResponseModel<T>
    {
        public int StatusCode { get; set; }

        public string Message { get; set; } = null!;
        
        public T? Response { get; set; }
    }
}
