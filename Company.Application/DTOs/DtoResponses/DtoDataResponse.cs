using System;
namespace Company.Application.DTOs.DtoResponses
{
    public class DtoDataResponse<T> : DtoResponse
    {
        public T? Data { get; set; }
    }
}

