using Hotel_API.Interface;
using System;
using System.Threading.Tasks;

namespace Hotel_API
{
    class Program {
        static void Main(string[] args)
        {
            try {
                HotelDBApi hotelDBApi = new();
                MainMenu mainMenu = new(hotelDBApi);
                mainMenu.DisplayMainMenu();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
            }
    }             
}
