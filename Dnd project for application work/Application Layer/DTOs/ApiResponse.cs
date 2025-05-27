using System.ComponentModel.DataAnnotations;
using Dnd_project_for_application_work.Domain_Layer;

namespace Dnd_project_for_application_work.Application_Layer.DTOs
{
    public class ApiResponse<T>
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public T? Data { get; set; }

        public ApiResponse(bool success, string message, T data)
        {
            Success = success;
            Message = message;
            Data = data;
        }

        public ApiResponse(T data)
        {
            Success = true;
            Message = "Success";
            Data = data;
        }

        public ApiResponse(string message)
        {
            Success = false;
            Message = message;
            Data = default(T)!;
        }
    }
}
