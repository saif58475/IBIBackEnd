using IBIBackEnd.Responce;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Service.Implementation
{

    public class Response<T> : IResponse<T> where T : class
    {
        public string Message { get; set; } = "Sucess";

        public int MessageCode { get; set; } = StatusCodes.Status200OK;

        public T Data { get; set; }
        public bool Success { get; set; } = true;
    }
    public class SucessCreate
    {
    }
    public class SucessUpdate
    {
    }
    public class SucessDelete
    {
    }
}
