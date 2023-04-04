using Final_exam1.Controllers;
using Final_exam1.Models;

namespace Final_exam1.Views
{
    class Menu : MainUtils
    {
        private static AnimeController controller = new AnimeController();
        public static int Home() {
            Println("===== Anime Database =====\n");
            PrintMenu(new string[] {
                "Search anime",
                "Add anime",
                "Update anime",
                "Delete anime",
                "Exit"
            });
            Print("Input : ");
            int inputCommand = ValidateMenu(Console.ReadLine(), 5);
            return inputCommand;
        }
        public static void Menu1()
        {
            Console.Clear();
            List<Anime> animeData = controller.GetAll();
            if (animeData.Count > 0 )
            {
                foreach (Anime anime in animeData)
                {
                    Println("========================================");
                    Println($"ID : {anime.Id}");
                    Println($"Title : {anime.Title}");
                    Println($"Release Date : {anime.Release_date}");
                    Println($"Rating : {anime.Rating}");
                    Println($"Status : {anime.Status_id}");
                    Println($"Duration (minutes) : {anime.Duration_minutes}");
                    Println($"Type : {anime.Type_id}\n");
                }
            } else
            {
                Println("Anime database is empty. Please add an anime data first");
            }
            

            Console.ReadKey();
        }

        public static void Menu2()
        {
            Console.Clear();
            Println("===== Add Anime =====\n");
            Print("Title : ");
            string inputTitle = ValidateString(Console.ReadLine());
            Print("\nRelease Date (YYYY-MM-DD, not required) : \n");
            DateOnly? inputDate = ValidateDate(Console.ReadLine());
            Print("\nRating (not required): ");
            float? inputRating = ValidateFloat(Console.ReadLine(), 10);
            Print("\nStatus (1-3, 1. Upcoming, 2. Ongoing, 3. Completed) : \n");
            int inputStatus = ValidateMenu(Console.ReadLine(), 3);
            Print("\nDuration (minutes, not required) : ");
            int? inputDuration = ValidateInt(Console.ReadLine());
            Print("\nType (1-4, 1. Movie, 2. Series, 3. OVA, 4. ONA) : \n");
            int inputType = ValidateMenu(Console.ReadLine(), 4);

            
            controller.Add(inputTitle, inputDate, inputRating, inputStatus, inputDuration, inputType);

            Console.ReadKey();
        }
    }
}
