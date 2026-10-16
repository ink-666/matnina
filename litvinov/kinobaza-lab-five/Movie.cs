namespace MovieBase
{
    // Класс данных «Фильм» (таблица 3)
    public class Movie
    {
        public const int MinYear = 1895;
        public const int MaxYear = 2025;
        public const int MinMark = 1;
        public const int MaxMark = 10;

        public static readonly string[] Genres =
        {
            "боевик", "детектив", "драма", "комедия", "мелодрама",
            "триллер", "ужасы", "фантастика", "фэнтези", "анимация"
        };

        public string Title { get; set; } = "";
        public int Year { get; set; }
        public string Genre { get; set; } = "";
        public string Country { get; set; } = "";
        public string Director { get; set; } = "";
        public int Mark { get; set; }
        public bool Watched { get; set; }
    }
}