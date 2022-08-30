using System.ComponentModel.DataAnnotations;

namespace CfAPI.Models
{
    public class TitreFoncier
    {
        [Key]
        public int Id { get; set; }
        public int Numero { get; set; }
        [StringLength(1)]
        public string Type { get; set; } = string.Empty;
        [StringLength(2)]
        public string Indice { get; set; } = string.Empty;
        [StringLength(3)]
        public string IndiceSpecial { get; set; } = string.Empty;

        public CF Cf { get; set; }
    }
}
