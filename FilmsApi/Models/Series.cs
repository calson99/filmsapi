namespace FilmsApi.Models
{
    public class Series
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Platform { get; set; }
        public string Date { get; set; }
        public List<Genres> Genres { get; set; }
        public List<GenresDto> GenresDto { get; set; }
        public List<GenresSeries> SeriesGenres { get; set; }
        public int Rating { get; set; }
    }

    public class SeriesDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Platform { get; set; }
        public string Date { get; set; }
        public int Rating { get; set; }
    }
}
