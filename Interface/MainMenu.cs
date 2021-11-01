using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_API.Interface
{
    class MainMenu
    {
        private HotelDBApi _hotelDBApi;
        private static readonly string[] _sections = { "Забронировать комнату", "Админ панель", "Завершить работу с программой" };
        private const string _title = "Для работы с программой выберите раздел с помощью стрелок клавиатуры";
        private Menu _menu;
        private AdminMenu _adminMenu;
        public MainMenu(HotelDBApi hotelDBApi)
        {
            _hotelDBApi = hotelDBApi;
            _menu = new(_sections, _title);
            _adminMenu = new (hotelDBApi, this);
        }
        public void DisplayMainMenu()
        {
            switch (_menu.Enter())
            {
                case 0:
                    {
                        
                    }
                    break;
                case 1:
                    {
                        if (_hotelDBApi.CheckAdmin())
                        _adminMenu.DisplayAdminMenu();
                    }
                    break;
                case 2:
                    {
                        Console.Clear();
                        Console.WriteLine("Спасибо что пользуетесь нашим продуктом");
                        Environment.Exit(0);
                    }
                    break;
            }
            Console.WriteLine("Нажмите любую клавишу для продолжения работы с программой");
            if (Console.ReadKey().Key != ConsoleKey.End)
            {
                DisplayMainMenu();
            }
        }
    }
}
