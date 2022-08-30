using System.ComponentModel.DataAnnotations;

namespace CfAPI.Models
{
    public class CF
    {
        [Key]
        public int Id { get; set; }
        [StringLength(50)]
        public string Nom { get; set; } = string.Empty;

        [StringLength(2)]
        public string Code { get; set; } = string.Empty;

        public static implicit operator CF(string v)
        {
            throw new NotImplementedException();
        }
    }
}
