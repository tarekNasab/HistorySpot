using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HistorySpot.Models
{
    public class Like
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public Guid HistoricalPointId { get; set; }
        public Guid UserId { get; set; }

    }
}
