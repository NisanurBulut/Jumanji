using JAPI.Models.Dtos;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static JAPI.Models.Trail;

namespace JAPI.Models.DTOs
{
    public class TrailUpsertDto
    {
        
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public double Distance { get; set; }
        public DifficultyType Difficulty { get; set; }
        [Required]
        public int NationalParkId { get; set; }
       
        public NationalParkDto NationalPark { get; set; }
    }
}
