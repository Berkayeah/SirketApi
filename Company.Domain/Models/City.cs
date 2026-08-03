using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Company.Domain.Models
{
    [Table("city")]
    public class City : CoreEntity
    {
        [Column("citycode")]
        public string CityCode { get; set; } = string.Empty;

        [Column("cityname")]
        public string CityName { get; set; } = string.Empty;
    }
}

