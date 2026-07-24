using System;
namespace SirketApp.Business.DTOs.DtoRequests
{
	public class DtoPersonelRequest
	{
		public string Ad { get; set; } = string.Empty;
		public string Soyad { get; set; } = string.Empty;
		public int BirimId { get; set; }
		public string SehirKodu { get; set; }
		public string Tcno { get; set; } = string.Empty;
	}
}

