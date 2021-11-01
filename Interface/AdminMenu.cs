using Hotel_API.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_API
{
    class AdminMenu
    {
        private HotelDBApi _hotelDBApi;
        private static readonly string[] _sections = { "Категории", "Комнаты", "Постояльцы", "Поселения", "Вернуться в главное меню" };
        private const string _title = "Для работы с программой выберите раздел с помощью стрелок клавиатуры";
        private Menu _menu;
        private MainMenu _mainmenu;
        private SubmenuCategories _submenuCategories;
        private SubmenuRooms _submenuRooms;
        private SubmenuGuests _submenuGuests;
        private SubmenuCheckins _submenuCheckins;

        public AdminMenu(HotelDBApi hotelDBApi, MainMenu mainMenu)
        {
            _mainmenu = mainMenu;
            _hotelDBApi = hotelDBApi;
            _menu = new(_sections, _title);
            _submenuCategories = new(this, hotelDBApi);
            _submenuRooms = new(this, hotelDBApi);
            _submenuGuests = new(this, hotelDBApi);
            _submenuCheckins = new(this, hotelDBApi);
        }
        public void DisplayAdminMenu ()
        {
            switch (_menu.Enter())
            {
                case 0:
                    {
                        _submenuCategories.DisplaySubmenuCategories();
                    } break;
                case 1:
                    {
                        _submenuRooms.DisplaySubmenuRooms();
                    } break;
                case 2:
                    {
                        _submenuGuests.DisplaySubmenuGuests();
                    }break;
                case 3:
                    {
                        _submenuCheckins.DisplaySubmenuCheckins();
                    }break;
                case 4:
                    {
                        _mainmenu.DisplayMainMenu();
                    }break;
            }
        }
    }
}
