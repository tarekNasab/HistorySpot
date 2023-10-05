using System.ComponentModel.DataAnnotations;

namespace HistorySpot.Models.ViewModels
{
    public class AddHistoricalPointRequest
    {
        public string? ImageUrl{ get; set; }
        [Required(ErrorMessage = "Namn är obligatoriskt.")]
        [StringLength(100, ErrorMessage = "Namn får inte vara längre än 100 tecken.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Beskrivning är obligatoriskt.")]
        [StringLength(10000, ErrorMessage = "Beskrivning får inte vara längre än 10000 tecken.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Latitude är obligatoriskt.")]
        [Range(-90, 90, ErrorMessage = "Ogiltigt värde för Latitude. Måste vara mellan -90 och 90.")]
        public double Latitude { get; set; }

        [Required(ErrorMessage = "Longitude är obligatoriskt.")]
        [Range(-180, 180, ErrorMessage = "Ogiltigt värde för Longitude. Måste vara mellan -180 och 180.")]
        public double Longitude { get; set; }

        [Required(ErrorMessage = "Datum är obligatoriskt.")]
        public DateTime Date { get; set; }
    }
}
