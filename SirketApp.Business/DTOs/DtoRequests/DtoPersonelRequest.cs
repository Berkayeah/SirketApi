using System;
using SirketApp.Business.DTOs.DtoResponses;

namespace SirketApp.Business.DTOs.DtoRequests
{
	public class DtoPersonelRequest
	{
		public string Ad { get; set; } = string.Empty;
		public string Soyad { get; set; } = string.Empty;
		public int BirimId { get; set; }
		public int SehirId { get; set; } 
		public string Tcno { get; set; } = string.Empty;
	}
}

