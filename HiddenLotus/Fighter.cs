using System.ComponentModel.DataAnnotations;

namespace HiddenLotus
{
    public class Fighter
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Range(18, 100)]
        public int Age { get; set; }
        
        public int PowerLevel { get; set; }
    }
}
