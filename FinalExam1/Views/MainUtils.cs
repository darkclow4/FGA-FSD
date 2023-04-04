using Microsoft.VisualBasic;

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
        protected static DateOnly? ValidateDate(string input)
        {
            DateOnly outDate;
            if(input == "")
            {
                return null;
            }
            bool valid = DateOnly.TryParse(input, out outDate);
            while(!valid) {
                Println($"\nInvalid input. Date format is YYYY-MM-DD");
                Print("Input : ");
                input = Console.ReadLine();
                if (input == "")
                {
                    return null;
                }
                valid = DateOnly.TryParse(input, out outDate);
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
        protected static int? ValidateInt(string input)
        {
            int outInt;
            if(input == "")
            {
                return null;
            }
            bool valid = int.TryParse(input, out outInt);
            while(!valid)
            {
                Println($"\nInvalid input. Input must be a number");
                Print("Input : ");
                valid = int.TryParse(Console.ReadLine(), out outInt);
            }
            
            return outInt;
        }
        protected static float? ValidateFloat(string input, int maxNumber = 0)
        {
            float outNumber;
            bool valid;
            if (input == "")
            {
                return null;
            }
            valid = maxNumber > 0? float.TryParse(input, out outNumber) && outNumber < maxNumber : float.TryParse(input, out outNumber);
            string errorMessage = maxNumber > 0 ? $" and less than {maxNumber}" : "";
            
            while (!valid)
            {
                Println($"\nInvalid input. Input must be a number{errorMessage}.");
                Print("Input : ");
                valid = maxNumber > 0 ? float.TryParse(Console.ReadLine(), out outNumber) && outNumber < maxNumber : float.TryParse(Console.ReadLine(), out outNumber);
            }
            return outNumber;
        }
    }
}
