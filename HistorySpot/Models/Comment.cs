using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HistorySpot.Models
{
    public class Comment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid CommentId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime DatePosted { get; set; }


    }
}
