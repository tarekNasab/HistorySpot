using System.ComponentModel.DataAnnotations;

namespace HistorySpot.Models.ViewModels
{
    public class AddCommentRequest
    {
        [Required(ErrorMessage = "Namn är obligatoriskt.")]
        [StringLength(100, ErrorMessage = "Namn får inte vara längre än 100 tecken.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Beskrivning är obligatoriskt.")]
        [StringLength(1000, ErrorMessage = "Beskrivning får inte vara längre än 1000 tecken.")]
        public string Description { get; set; }
    }
}
