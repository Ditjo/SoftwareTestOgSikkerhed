using System.ComponentModel.DataAnnotations;

namespace SoftwareTestOgSikkerhed.Models
{
    public class Cpr
    {
        [Key] 
        public int Id { get; set; }
        public string? UserName { get; set; }
        public string? CprNumber {  get; set; }
        public List<Todolist>? Todolist { get; set; }

    }
}
