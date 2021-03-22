
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace BibliotekaAPI.Models
{
    public class Polica{

        [Key]
        [Column("ID")]
        public int ID { get; set; } 

        [Column("Zanr")]
        public string Zanr{ get; set; }

        [Column("BrKnjiga")]
        public int BrKnjiga { get; set; }

        public virtual List<Knjiga> Knjige  { get; set; }


        [JsonIgnore]
        public Biblioteka Biblioteka { get; set; }

        
       
       

        


    }

}