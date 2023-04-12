using System.Text.Json.Serialization;

namespace Hali.Shared.DTOs
{
    public class ResponseDto<T>
    {
        public T Data { get; set; }
        public int StatusCode { get; set; } 
        public ErrorDto Error { get; set; }
        [JsonIgnore]
        public bool IsSuccessful { get; set; }
        public static ResponseDto<T> Succes(T data, int statusCode)
        {
            return new ResponseDto<T> { Data = data, StatusCode = statusCode, IsSuccessful = true };
        }
        public static ResponseDto<T> Succes(int statusCode)
        {
            return new ResponseDto<T> { StatusCode = statusCode, IsSuccessful = true };
        }
        public static ResponseDto<T> Fail(ErrorDto errorDto, int statusCode)
        {
            return new ResponseDto<T> { Error = errorDto, StatusCode = statusCode, IsSuccessful = false };
        }
        public static ResponseDto<T> Fail(string error, int statusCode, bool isShow)
        {
            var errorDto = new ErrorDto(error, isShow);

            return new ResponseDto<T> { Error = errorDto, StatusCode = statusCode, IsSuccessful = false };
        }
    }
}
