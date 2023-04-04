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
                    Println($"Title : {anime.Title}");
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
            Print("Release Date (YYYY-MM-DD, not required) : \n");
            DateOnly inputDate = ValidateDate(Console.ReadLine());
            Print("Rating (not required): ");
            float inputRating = ValidateFloat(Console.ReadLine());
            Print("Status (1-3, 1. Upcoming, 2. Ongoing, 3. Completed) : \n");
            int inputStatus = ValidateMenu(Console.ReadLine(), 3);
            Print("Duration (minutes, not required) : ");
            int inputDuration = int.Parse(Console.ReadLine());
            Print("Type (1-4, 1. Movie, 2. Series, 3. OVA, 4. ONA) : \n");
            int inputType = ValidateMenu(Console.ReadLine(), 4);

            
            controller.Add(inputTitle, inputDate, inputRating, inputStatus, inputDuration, inputType);

            Console.ReadKey();
        }
    }
}
