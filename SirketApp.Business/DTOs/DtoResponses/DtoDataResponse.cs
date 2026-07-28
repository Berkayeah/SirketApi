using System;
namespace SirketApp.Business.DTOs.DtoResponses
{
	public class DtoDataResponse<T> : DtoResponse
	{
		public T? Data { get; set; }
	}
}

