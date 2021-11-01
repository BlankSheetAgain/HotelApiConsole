using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_API
{
    class SubmenuCheckins
    {
        private AdminMenu _adminmenu;
        private static readonly string[] sections = { "Добавить заселение", "Отобразить информацию о заселении", "Отобразить все заселения", "Изменить информацию о заселении", "Удалить заселение", "Вернуться в меню админ панели" };
        private const string title = "Выберите операцию над заселением";
        private Menu _menu;
        private HotelDBApi _hotelDBApi;
        private Checkin _checkin;
        public SubmenuCheckins(AdminMenu adminMenu, HotelDBApi hotelDBApi)
        {
            _adminmenu = adminMenu;
            _menu = new(sections, title);
            _hotelDBApi = hotelDBApi;
            _checkin = new() { ID = Guid.NewGuid() };
        }
        public void DisplaySubmenuCheckins()
        {
            switch (_menu.Enter())
            {
                case 0:
                    {
                        if (_hotelDBApi.ValidateCheckin(_checkin))
                        {
                            _hotelDBApi.AddCheckin(_checkin).ConfigureAwait(false);
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
                DisplaySubmenuCheckins();
            }
        }
    }
}
