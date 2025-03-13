using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace BowlingLeague.Data; // Adjust namespace based on your project structure

public class Team
{
    [Key]
    public int TeamId { get; set; }
    
    [Required]
    public string TeamName { get; set; }
    
    public int CaptainId { get; set; }

}