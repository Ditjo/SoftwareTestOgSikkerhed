using System.ComponentModel.DataAnnotations;

namespace SoftwareTestOgSikkerhed.Models
{
    public class Cpr
    {
        [Key] 
        public int Id { get; set; }
        public string? UserName { get; set; }
        public string? CprId {  get; set; }
        public List<Todolist>? Todolist { get; set; }

    }
}
