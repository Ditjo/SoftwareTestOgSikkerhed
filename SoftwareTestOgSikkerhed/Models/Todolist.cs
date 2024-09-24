using System.ComponentModel.DataAnnotations;

namespace SoftwareTestOgSikkerhed.Models
{
    public class Todolist
    {
        [Key]
        public int Id { get; set; }
        public string? TodoTitle { get; set; }
        public string? TodoDescription { get; set; }
    }
}
