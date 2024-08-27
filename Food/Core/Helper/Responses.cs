using Core.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Core.Helper
{
    public class Responses
    {
        public ActionResult ResponseSuccess<T>(string message, T data)
        {
            var responseSuccess = new Response<T>
            {
                Status = "Success",
                Code = 200,
                Message = message,
                Data = data
            };
            return new ObjectResult(responseSuccess) { StatusCode = 200 };
        }
        public ActionResult ResponseSuccess(string message)
        {
            var responseSuccess = new Response<string>
            {
                Status = "Success",
                Code = 200,
                Message = message,
            };
            return new ObjectResult(responseSuccess) { StatusCode = 200 };
        }
        public ActionResult ResponseNotFound(string message)
        {
            var responseNotFound = new Response<string>
            {
                Status = "Not Found",
                Code = 404,
                Message = message,
                Data = null
            };
            return new ObjectResult(responseNotFound) { StatusCode = 404 };
        }
        public ActionResult ResponseBadRequest(string message)
        {
            var responseBadRequest = new Response<string>
            {
                Status = "Bad Request",
                Code = 400,
                Message = message,
                Data = null
            };
            return new ObjectResult(responseBadRequest) { StatusCode = 400 };
        }
        public ActionResult ResponseConflict(string message)
        {
            var responseConflict = new Response<string>
            {
                Status = "Conflict",
                Code = 409,
                Message = message,
                Data = null
            };
            return new ObjectResult(responseConflict) { StatusCode = 409 };
        }
        public ActionResult ResponseUnauthorized(string message)
        {
            var responseUnauthorized = new Response<string>
            {
                Status = "Unauthorized",
                Code = 401,
                Message = message,
                Data = null
            };
            return new ObjectResult(responseUnauthorized) { StatusCode = 401 };
        }
        public ActionResult ResponseUnavailable(string message)
        {
            var ResponseUnavailable = new Response<string>
            {
                Status = "Unavailable",
                Code = 503,
                Message = message,
                Data = null
            };
            return new ObjectResult(ResponseUnavailable) { StatusCode = 503 };
        }
        public ActionResult ResponseForbidden(string message)
        {
            var responseForbidden = new Response<string>
            {
                Status = "Forbidden",
                Code = 403,
                Message = message,
                Data = null
            };
            return new ObjectResult(responseForbidden) { StatusCode = 403 };
        }
        public ActionResult HandleException(Exception ex)
        {
            var errorResponse = new Response<ExError>
            {
                Status = "Error",
                Code = 500,
                Message = "حدث خطأ ما!",
                Data = new ExError
                {
                    Message = ex.Message,
                    InnerException = ex.InnerException!.Message
                }
            };
            return new ObjectResult(errorResponse) { StatusCode = 500 };
        }
        public ActionResult DatebaseExaption(DbUpdateException ex)
        {
            var errorResponse = new Response<ExError>
            {
                Status = "Error",
                Code = 500,
                Message = "حدث خطأ ما اثناء الاتصال بقاعدة البيانات!",
                Data = new ExError
                {
                    Message = ex.Message,
                    InnerException = ex.InnerException!.Message
                }
            };
            return new ObjectResult(errorResponse) { StatusCode = 500 };
        }
        public class ExError
        {
            public string? Message { get; set; }
            public string? InnerException { get; set; } = null;
        }
    }
}

