namespace Final_exam1.Views
{
    class MainUtils
    {
        protected static void Print(string content)
        {
            Console.Write(content);
        }
        protected static void Println(string content)
        {
            Console.WriteLine(content);
        }
        protected static void PrintMenu(string[] list)
        {
            for (int i = 0; i < list.Length; i++)
            {
                Println($"{i + 1}. {list[i]}");
            }
        }
        protected static int ValidateMenu(string inputNumber, int maxNumber)
        {
            bool valid;
            int outNumber;
            valid = int.TryParse(inputNumber, out outNumber) && outNumber <= maxNumber && outNumber > 0;
            while(!valid)
            {
                Println($"\nInvalid input. Only accept number 1 - {maxNumber}");
                Print("Input : ");
                valid = int.TryParse(Console.ReadLine(), out outNumber) && outNumber <= maxNumber && outNumber > 0;
            }
            return outNumber;
        }
        protected static DateOnly ValidateDate(string input)
        {
            DateOnly outDate;
            bool valid = DateOnly.TryParse(input, out outDate);
            while(!valid) {
                Println($"\nInvalid input. Date format is YYYY-MM-DD");
                Print("Input : ");
                valid = DateOnly.TryParse(Console.ReadLine(), out outDate);
            }
            return outDate;
        }
        protected static string ValidateString(string input)
        {
            string outString = input;
            while(outString == "")
            {
                Println($"\nInput can't be empty.");
                Print("Input : ");
                outString = Console.ReadLine();
            }
            return outString;
        }
        protected static float ValidateFloat(string input)
        {
            float outNumber;
            bool valid = float.TryParse(input, out outNumber);
            while (!valid)
            {
                Println($"\nInvalid input. Input must be number.");
                Print("Input : ");
                valid = float.TryParse(Console.ReadLine(), out outNumber);
            }
            return outNumber;
        }
    }
}
