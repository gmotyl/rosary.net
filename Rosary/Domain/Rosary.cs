using System.ComponentModel.DataAnnotations;

namespace Rosary.Domain
{
    public class Rosary
    {
        [Key]
        public int Id { get; set; }

        public Intention Intention { get; set; }

    }
}