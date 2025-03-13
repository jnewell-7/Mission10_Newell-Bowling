using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BowlingLeague.Data;

public class Bowling
{
    [Key]
    public int BowlerId { get; set; }
    
    [Required]
    public string BowlerLastName { get; set; }
    
    [Required]
    public string BowlerFirstName { get; set; }
    
    public char? BowlerMiddleInit { get; set; } 

    
    [ForeignKey("TeamId")]
    public int? TeamId { get; set; }
    public Team? Team { get; set; }
    
    [Required]
    public string BowlerAddress { get; set; }
    
    [Required]
    public string BowlerCity { get; set; }
    
    [Required]
    public string BowlerState { get; set; }
    
    [Required]
    public string BowlerZip { get; set; }
    
    [Required]
    public string BowlerPhoneNumber { get; set; }
}

