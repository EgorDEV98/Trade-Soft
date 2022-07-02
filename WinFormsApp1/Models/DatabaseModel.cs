using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WinFormsApp1.Model
{
    public class DatabaseModel
    {
        [Key]
        [Required]
        [DisplayName("ID")]
        public int ID { get; set; }

        [Required]
        [DisplayName("Артикул1")]
        public string? Vendor { get; set; }

        [Required]
        [DisplayName("Производитель1")]
        public string? Manufacturer { get; set; }

        [DisplayName("Артикул2")]
        public string? Vendor2 { get; set; }

        [DisplayName("Производитель2")]
        public string? Manufacturer2 { get; set; }

        [DisplayName("Доверие")]
        public int Trust { get; set; }
    }
}
