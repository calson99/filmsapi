using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmsUi.Models
{
    internal class Genres
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Films> Films { get; set; }
        public List<Series> Series { get; set; }
        public List<FilmsDto> FilmsDto { get; set; }
        public List<FilmsGenres> FilmsGenres { get; set; }
        public List<SeriesDto> SeriesDto { get; set; }
        public List<GenresSeries> SeriesGenres { get; set; }
    }
    internal class GenresDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<SeriesDto> SeriesDto { get; set; }
        public List<FilmsDto> FilmsDto { get; set; }
    }
}
