using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_API.Interface
{
    
    class SubmenuReservation
    {
        private MainMenu _mainmenu;
        private static readonly string[] sections = { "Все номера", "Поиск", "Вернуться в главное меню"};
        private const string title = "Выберите предпочтительный для вас вариант";
        private Menu _menu;
        private HotelDBApi _hotelDBApi;
        public SubmenuReservation(MainMenu mainMenu, HotelDBApi hotelDBApi)
        {
            _mainmenu = mainMenu;
            _menu = new(sections, title);
            _hotelDBApi = hotelDBApi;
        }
    }
}
