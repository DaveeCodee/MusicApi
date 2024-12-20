using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MusicApi.Models
{
    public class Song
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Duration { get; set; }
        public DateTime UploadedDate { get; set; }
        public bool isFeatured { get; set; }
        [NotMapped]
        public IFormFile? Image { get; set; }
        public string? ImageURL { get; set; }
        [NotMapped]
        public IFormFile? AudioFile { get; set; }
        public string? AudioUrl { get; set; }
        public int ArtistId { get; set; }
        public int? AlbumId { get; set; }
    }
}
