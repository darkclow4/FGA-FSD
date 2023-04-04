using Final_exam1.Models;
using Final_exam1.Repositories;

namespace Final_exam1.Controllers
{
    class AnimeController
    {
        private NativeAnimeRepository repository = new NativeAnimeRepository();
        public void Add(string title, DateOnly release_date, float rating, int status_id, int duration_minutes, int type_id)
        {
            
            Anime animeRecord = new Anime(title, release_date, rating, status_id, duration_minutes, type_id);

            repository.Create(animeRecord);
        }

        public List<Anime> GetAll()
        {
            List<Anime> data = repository.ReadAll();
            return data;
        }
    }
}
