using System.ComponentModel.DataAnnotations;
using BlazorApp.Data;

namespace BlazorApp.Models
{
    public class Blog
    {
        [Key]
        public long Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Author { get; set; }
        public string? UserId { get; set; } 
        public ApplicationUser? User { get; set; }
    }
}
