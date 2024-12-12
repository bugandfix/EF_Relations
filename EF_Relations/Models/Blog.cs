using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

public class Blog
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)] 
    public int Id { get; set; }
    public string? Title { get; set; }

    //[INVERSEPROPERTY("BLOG")]
    public ICollection<Post> Posts { get; set; } = new List<Post>();
}

public class Post
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public string? Content { get; set; }

    //[ForeignKey("BlogId")]
    public int BlogId { get; set; }

    [JsonIgnore]    
    public Blog? Blog { get; set; }
}
