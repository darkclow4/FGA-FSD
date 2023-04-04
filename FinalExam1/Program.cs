using Final_exam1.Views;
using System.Globalization;

namespace Final_exam1
{
    internal class Program
    {
        
        static void Main(string[] args)
        {
            CultureInfo culture = new CultureInfo("en-US");
            CultureInfo.DefaultThreadCurrentCulture = culture;
            CultureInfo.DefaultThreadCurrentUICulture = culture;

            while (true)
            {
                Console.Clear();
                int inputInstruction = Menu.Home();
                switch (inputInstruction)
                {
                    case 1:
                        Menu.Menu1();
                        break;
                    case 2:
                        Menu.Menu2();
                        break;
                    case 3:
                        break;
                    case 4:
                        break;
                    case 5:
                        Environment.Exit(0);
                        break;
                }
            }
        }
    }
}