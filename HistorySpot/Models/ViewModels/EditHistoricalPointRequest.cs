using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HistorySpot.Models.ViewModels
{
    public class EditHistoricalPointRequest
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string? ImageUrl { get; set; }
        public DateTime Date { get; set; } // Historisk datum för händelsen
    }
}

