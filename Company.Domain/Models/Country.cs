using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Company.Domain.Models
{
    [Table("country")]
    public class Country : CoreEntity
    {
        [Column("countrycode")]
        public string CountryCode { get; set; }
        [Column("countryname")]
        public string CountryName { get; set; }
    }
}

