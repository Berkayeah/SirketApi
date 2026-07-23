using System;
namespace SirketApp.Business.DTOs.ResponseDtos
{
	public class PersonelResponseDto
	{
		public string Ad { get; set; } = string.Empty;
		public string Soyad { get; set; } = string.Empty;
        public string BirimAdi { get; set; } = string.Empty;
        public string SehirAdi { get; set; } = string.Empty;
    }
}

