
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace BibliotekaAPI.Models
{

    public class Knjiga{

        [Key]
        [Column("ID")]
        public int ID { get; set; }
        
        [Column("Ime")]
        public string Ime { get; set; }

        [Column("BrStrana")]
        public int BrStrana { get; set; }

        [JsonIgnore]
        public Polica Polica { get; set; }

    }

}
