using System;
namespace Company.Application.DTOs.DtoResponses
{
    public class DtoErrorResponse : DtoResponse
    {
        public string ErrCode { get; set; } = "SYS_ERR";
        public string ErrMessage { get; set; } = string.Empty;
    }
}

