using System.ComponentModel.DataAnnotations.Schema;

namespace API.Data;
// Dependent (child)
[Table("Photos")]
public class Photo
{
    public int Id { get; set; }
    public required string Url { get; set; }
    public bool IsMain { get; set; }
    public string? PublicId { get; set; }

    // Navigation properties
    public int AppUserId { get; set; } // required foreign key property
    public AppUser AppUser { get; set; }  = null!;// required refrence navigation to princle
}