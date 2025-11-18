namespace PdfWatermarkWebApi.Common
{
    public class ApiResponse<T>
    {
        public bool Success { get; set; }
        public string Message { get; set; } = "";
        public T? Data { get; set; }
        public object? Errors { get; set; }
        public object? Meta { get; set; } = null;

        public static ApiResponse<T> Ok(T data, string message = "Success", object? meta = null)
        => new() { Success = true, Message = message, Data = data, Meta = meta };

        public static ApiResponse<T> Fail(string message, object? errors = null, object? meta = null)
            => new() { Success = false, Message = message, Errors = errors, Meta = meta };
    }
}
