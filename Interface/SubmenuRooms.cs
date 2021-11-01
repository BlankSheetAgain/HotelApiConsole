using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_API
{
    class SubmenuRooms
    {
        private AdminMenu _adminmenu;
        private static readonly string[] sections = { "Добавить комнату", "Отобразить комнату", "Отобразить все комнаты", "Изменить комнату", "Удалить комнату", "Вернуться в меню админ панели" };
        private const string title = "Выберите операцию над комнатой";
        private Menu _menu;
        private HotelDBApi _hotelDBApi;
        private Room _room;
        public SubmenuRooms(AdminMenu adminMenu, HotelDBApi hotelDBApi)
        {
            _adminmenu = adminMenu;
            _menu = new(sections, title);
            _hotelDBApi = hotelDBApi;
            _room = new() { ID = Guid.NewGuid() };
        }
        public void DisplaySubmenuRooms()
        {
            switch (_menu.Enter())
            {
                case 0:
                    {
                        if (_hotelDBApi.ValidateRoom(_room))
                        {
                            _hotelDBApi.AddRoom(_room).ConfigureAwait(false);
                        }
                    }
                    break;
                case 1:

                    {

                    }
                    break;
                case 2:
                    {

                    }
                    break;
                case 3:
                    {

                    }
                    break;
                case 4:
                    {

                    }
                    break;
                case 5:
                    {
                        _adminmenu.DisplayAdminMenu();
                    }
                    break;
            }
            if (Console.ReadKey().Key != ConsoleKey.End)
            {
                DisplaySubmenuRooms();
            }
        }
    }
}
