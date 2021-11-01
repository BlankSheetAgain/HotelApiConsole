using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_API
{
    class SubmenuGuests
    {
        private AdminMenu _adminmenu;
        private static readonly string[] sections = { "Добавить постояльца", "Отобразить постояльца", "Отобразить всех постояльцев", "Изменить постояльца", "Удалить постояльца", "Вернуться в меню админ панели" };
        private const string title = "Выберите операцию над постояльцев";
        private Menu _menu;
        private HotelDBApi _hotelDBApi;
        private Guest _guest;
        public SubmenuGuests(AdminMenu adminmenu, HotelDBApi hotelDBApi)
        {
            _adminmenu = adminmenu;
            _menu = new(sections, title);
            _hotelDBApi = hotelDBApi;
            _guest = new() { ID = Guid.NewGuid() };
        }
        public void DisplaySubmenuGuests()
        {
            switch (_menu.Enter())
            {
                case 0:
                    {
                        if (_hotelDBApi.ValidateGuest(_guest))
                        {
                            _hotelDBApi.AddGuest(_guest).ConfigureAwait(false);
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
                DisplaySubmenuGuests();
            }
        }
    }
}
