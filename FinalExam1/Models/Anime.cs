namespace Final_exam1.Models
{
    internal class Anime
    {
        public int? Id { get; set; }
        public string Title { get; set; }
        public DateOnly Release_date { get; set; }
        public float Rating { get; set; }
        public int Status_id { get; set; }
        public int Duration_minutes { get; set; }
        public int Type_id { get; set; }

        public Anime(string title, DateOnly release_date, float rating, int status_id, int duration_minutes, int type_id, int? id = null)
        {
            Id = id;
            Title = title;
            Release_date = release_date;
            Rating = rating;
            Status_id = status_id;
            Duration_minutes = duration_minutes;
            Type_id = type_id;
        }
    }
}
