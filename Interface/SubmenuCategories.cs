using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_API
{
    class SubmenuCategories
    {
        private AdminMenu _adminmenu;
        private static readonly string[] sections = { "Добавить категорию", "Отобразить категорию", "Отобразить все категории", "Изменить категорию", "Удалить категорию", "Вернуться в меню админ панели" };
        private const string title = "Выберите операцию над категорией";
        private Menu _menu;
        private HotelDBApi _hotelDBApi;
        private Category _category;
        public SubmenuCategories(AdminMenu adminMenu, HotelDBApi hotelDBApi)
        {
            _adminmenu = adminMenu;
            _menu = new(sections, title);
            _hotelDBApi = hotelDBApi;
            _category = new() { ID = Guid.NewGuid() };
        }
       public void DisplaySubmenuCategories()
        {
            switch (_menu.Enter())
            {
                case 0:
                    {
                        if(_hotelDBApi.ValidateCategory(_category))
                        {
                            _hotelDBApi.AddCategory(_category).ConfigureAwait(false);
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

                    }break;
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
                DisplaySubmenuCategories();
            }
        }
    }
}
