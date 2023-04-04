using Final_exam1.Models;

namespace Final_exam1.Interfaces
{
    interface IAnime
    {
        void Create(Anime animeRecord);
        void Update();
        void Delete();
        List<Anime> ReadAll();
        void ReadById(int id);
    }
}
