using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTask.Service.Response
{
    public interface IBaseResponse<T>
    {
        T Data { get; set; }
        StatusCode StatusCode { get; }
    }

    public class BaseResponse<T> : IBaseResponse<T>
    {
        public string Description { get; set; }
        public StatusCode StatusCode { get; set; }
        public T Data { get; set; }
    }

    public enum StatusCode
    {
        Success = 200,
        NotFound = 404,
        InternalServerError = 500
    }
}
