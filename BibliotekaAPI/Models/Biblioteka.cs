using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace BibliotekaAPI.Models
{
public class Biblioteka{

    [Key]
    [Column("ID")]
    public int ID { get; set; }

    [Column("Ime")]
    public string Ime { get; set; }

    public virtual List<Polica> Police { get; set; }
    
}

}