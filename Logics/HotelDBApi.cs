using Hotel_API.Logics;
using System;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel_API
{
    class HotelDBApi
    {
        private CRUD<Category> _crudcategory;
        private CRUD<Room> _crudroom;
        private CRUD<Guest> _crudguest;
        private CRUD<Checkin> _crudcheckin;
        private Validator _validator;
        public HotelDBApi()
        {
            _crudcategory = new("database/categories.json");
            _crudroom = new("database/rooms.json");
            _crudguest = new("database/guests.json");
            _crudcheckin = new("database/checkins.json");
            _validator = new();
        }

        public bool CheckAdmin ()
        {
            Console.Clear();
            Console.WriteLine("Введите пароль для доступа в админ панель (admin)");
            if (Console.ReadLine() == "admin") return true;
            Console.WriteLine("В доступе отказано");
            return false;
        }
        
        public BookRoom()
        {
            Console.WriteLine("Введите количество необходимых кроватей");

        }


        public async Task AddCategory(Category category)
        {
            await _crudcategory.AddAsync(category).ConfigureAwait(false);
        }

       public async Task AddRoom(Room room)
        {
            await _crudroom.AddAsync(room).ConfigureAwait(false);
        }

        public async Task AddGuest (Guest guest)
        {
            await _crudguest.AddAsync(guest).ConfigureAwait(false);
        }

        public async Task AddCheckin(Checkin checkin)
        {
            await _crudcheckin.AddAsync(checkin);
        }

        public bool ValidateCategory(Category category)
        {
            Console.Clear();
            Console.WriteLine("Введите название категории");
            string temp = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(temp)||!temp.All(Char.IsLetter)) {
                Console.WriteLine("Имя категории может состоять только из букв");
                return false; }
            var check = _crudcategory.Collection.Result.SingleOrDefault(s => s.Name == temp);
            if (check != null)
            {
                Console.WriteLine("Категория с таким названием уже существует");
                return false;
            }
            category.Name = temp;
            temp = Console.ReadLine();
            if (!decimal.TryParse(temp, out decimal price))
            {
                Console.WriteLine("Цена номеров данной категории задана неверно");
                return false;
            }
            category.Price = price;
            temp = Console.ReadLine();
            if (!int.TryParse(temp, out int beds))
            {
                Console.WriteLine("Количество кроватей в номерах данной категории задано неверно");
                return false;
            }
            category.Beds = beds;
            return true;
         } 

        public bool ValidateRoom (Room room)
        {
            Console.Clear();
            Console.WriteLine("Введите номер комнаты");
            string temp = Console.ReadLine();
            if (!int.TryParse(temp, out int number))
            {
                Console.WriteLine("Номер комнаты указан неверно");
                return false;
            }
            //var check = _crudroom.Collection.Result.SingleOrDefault(s => s.Number == number);
            //if (check != null)
            //{
            //    Console.WriteLine("Комната с таким номером уже существует");
            //    return false;
            //}
            room.Number = number;
            Console.WriteLine("Выберите категорию для комнаты:");
            for (int i=0; i<_crudcategory.Collection.Result.Count; i++)
            {
                Console.WriteLine($"{i+1}\t\t{_crudcategory.Collection.Result[i].Name}");
            }
            temp = Console.ReadLine();
            if(!int.TryParse(temp, out int index))
            {
                Console.WriteLine("Неверно задан номер категории");
                return false;
            }
            if (index>_crudcategory.Collection.Result.Count||index<0)
            {
                Console.WriteLine("Категории с таким номером не существует");
                return false;
            }
            room.CategoryID = _crudcategory.Collection.Result[index-1].ID;
            return true;
        }

        public bool ValidateGuest(Guest guest)
        {
            Console.Clear();
            Console.WriteLine("Введите фамилию постояльца");
            string temp = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(temp) || !temp.All(Char.IsLetter))
            {
                Console.WriteLine("Фамилия может состоять только из букв");
                return false;
            }
            guest.Lastname = temp;
            Console.WriteLine("Введите имя постояльца");
            temp = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(temp) || !temp.All(Char.IsLetter))
            {
                Console.WriteLine("Имя может состоять только из букв");
                return false;
            }
            guest.Firstname = temp;
            Console.WriteLine("ВВедите отчество постояльца");
            temp = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(temp) || !temp.All(Char.IsLetter))
            {
                Console.WriteLine("Отчество может состоять только из букв");
                return false;
            }
            guest.Middlename = temp;
            Console.WriteLine("Введите дату рождения постояльца (Напр. 16.10.2021)");
            temp = Console.ReadLine();
            if (!DateTime.TryParseExact(temp, "d.MM.yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime birth))
            {
                Console.WriteLine("Неверно введена дата рождения");
                return false;
            }
            guest.Birth = birth;
            Console.WriteLine("Введите паспортные данные");
            temp = Console.ReadLine();
            guest.Passport = temp;
            return true;
        }

       public bool ValidateCheckin(Checkin checkin)
        {
            Console.Clear();
            Console.WriteLine("Выберите постояльца которого вы хотите заселить");
            for (int i = 0; i < _crudguest.Collection.Result.Count; i++)
            {
                Console.WriteLine($"{i + 1}\t\t{_crudguest.Collection.Result[i].Lastname}\t\t" +
                    $"{_crudguest.Collection.Result[i].Firstname}\t\t" +
                    $"{_crudguest.Collection.Result[i].Middlename}");
            }
            string temp = Console.ReadLine();
            if (!int.TryParse(temp, out int index))
            {
                Console.WriteLine("Неверно задан номер постояльца");
                return false;
            }
            if (index > _crudguest.Collection.Result.Count || index < 0)
            {
                Console.WriteLine("Постояльца с таким номером не существует");
                return false;
            }
            checkin.GuestID = _crudguest.Collection.Result[index - 1].ID;
            Console.WriteLine("Выберите комнату для заселения");
            for (int i = 0; i < _crudroom.Collection.Result.Count; i++)
            {
                Console.WriteLine($"{i + 1}\t\t{_crudroom.Collection.Result[i].Number}");
            }
            temp = Console.ReadLine();
            if (!int.TryParse(temp, out int index_room))
            {
                Console.WriteLine("Неверно задан номер комнаты");
                return false;
            }
            if (index_room > _crudroom.Collection.Result.Count || index_room < 0) { 
                Console.WriteLine("Комнаты с таким номером не существует");
                return false;
            }
            checkin.RoomID = _crudroom.Collection.Result[index_room - 1].ID;
            temp = Console.ReadLine();
            if (!DateTime.TryParseExact(temp, "d.MM.yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime check_in))
            {
                Console.WriteLine("Неверно введенная дата вьезда (Напр. 16.10.2021)");
                return false;
            }
            checkin.Check_in = check_in;
            temp = Console.ReadLine();
            if (!DateTime.TryParseExact(temp, "d.MM.yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime check_out))
            {
                Console.WriteLine("Неверно введенная дата отьезда (Напр. 16.10.2021)");
                return false;
            }
            if (check_out<check_in)
            {
                Console.WriteLine("Дата отьезда не может быть раньше чем дата вьезда");
                return false;
            }
            checkin.Check_out = check_out;
            return true;
        }
    }
}
