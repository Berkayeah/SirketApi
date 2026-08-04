using System;
namespace Company.Application.DTOs.DtoResponses
{
    public class DtoResponse
    {
        public int ReqCode { get; set; } = 200;
        public string ReqMessage { get; set; } = string.Empty;
    }
}

