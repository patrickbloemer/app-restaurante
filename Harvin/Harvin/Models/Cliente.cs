using System.ComponentModel.DataAnnotations.Schema;

namespace Harvin.Models
{
    [Table("Cliente")]
    public class Cliente : Pessoa
    {
        public bool Newsletter { get; set; }
    }
}