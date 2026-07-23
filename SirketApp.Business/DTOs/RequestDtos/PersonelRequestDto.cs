using System;
namespace SirketApp.Business.DTOs.RequestDtos
{
	public class PersonelRequestDto
	{
		public string Ad { get; set; } = string.Empty;
		public string Soyad { get; set; } = string.Empty;
		public int BirimId { get; set; }
		public int SehirKodu { get; set; }
		public string Tcno { get; set; } = string.Empty;
	}
}

