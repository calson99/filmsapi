using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmsUi.Models
{
    internal class Films
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Platform { get; set; }
        public string Date { get; set; }
        public List<Genres> Genres { get; set; }
        public List<GenresDto> GenresDto { get; set; }
        public List<FilmsGenres> FilmsGenres { get; set; }
        public int Rating { get; set; }
    }

    internal class FilmsDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Platform { get; set; }
        public string Date { get; set; }
        public int Rating { get; set; }
    } 
}
