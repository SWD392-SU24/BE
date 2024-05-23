namespace Backend.BO.Commons
{
    public record ResponseModel<T> (int statusCode, string message, T? response);
}
