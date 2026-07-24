using System;
namespace SirketApp.Business.DTOs.DtoResponses
{
	public class DtoResponse
	{
		public int ReqCode { get; set; } = 200;
		public string ReqMessage { get; set; } = string.Empty;

		public string ErrCode { get; set; } = "0";
		public string ErrMessage { get; set; } = string.Empty;

		public object? Data { get; set; }
	}
}

