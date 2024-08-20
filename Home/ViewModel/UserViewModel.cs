using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Home.Model;


namespace Home.ViewModel
{

    //    public string? Name { get; set; }
    //    public string? Surname { get; set; }
    //    public string? Patronymic { get; set; }
    //    public string? Email { get; set; }

    //    public RelayCommand AddUserCommand { get; }
    //    public RelayCommand CancelAddUserCommand { get; }

    //    // обьявляем класс токена
    //    private CancellationTokenSource cancelTokenSource = new CancellationTokenSource();
    //    // обьявляем сам токен
    //    private CancellationToken token;

    //    //public override string ToString()
    //    //{
    //    //    return $"Имя: {Name} Фамилия: {Surname} Отчество: {Patronymic} Email: {Email}";
    //    //}
    //    public UserViewModel()
    //    {
    //        //token.IsCancellationRequested = true;
    //        token = cancelTokenSource.Token;
    //        AddUserCommand = new RelayCommand(AddUserAsync, obj => tue);
    //        CancelAddUserCommand = new RelayCommand(CancelAddUserCommand, objt => true);
    //    }

    //    public async void AddUserAsync(object obj)
    //    {
    //        // круг крутится
    //        IsUserBeingAdded = true;

    //        // создается экземпляр класса
    //        var user = new User()
    //        {
    //            Name = Name,
    //            Surname = Surname,
    //            Patronymic = Patronymic,
    //            Email = Email
    //        };

    //        // определяем контекст БД
    //        // класс, благодаря которому мы можем обращаться к сущностям БД
    //        using var db = new ApplicationContext();

    //        try
    //        {
    //            await Task.Delay(2000, token);
    //            // добавление ассинхронно
    //            await db.Users.AddAsync(user, token);
    //            // сохранение ассинхронно
    //            await db.SaveChanges(token);

    //            // удаление
    //            //db.Remove(user);
    //            //await db.SaveChanges(token);
    //        }
    //        catch (Exception)
    //        {
    //            MessageBox.Show("Вы завершили");
    //        }

    //        // круг прекращает крутиться
    //        IsUserBeingAdded = false;
    //    }

    //    // событие нажатия
    //    private void CancelAddUser(object obj)
    //    {
    //        cancelTokenSource.Cancel();
    //    }

    public class UserViewModel:INotifyPropertyChanged
    // интерфейс нужен для того, чтобы сообщить внешнему визуальному
    // представлению, что наше состояние обновилось
    {
        public ObservableCollection<User>? users;
        // получаем список модельных представлений // св-во // nullable-тип
        public ObservableCollection<User>? Users 
        { 
            get => users;
            set
            {
                users = value;
                OnPropertyChanged(); // обнови пожалуйста
            }
        } 
        // для работы с данными
        private readonly UserRepository userRepository = new UserRepository();
        public UserViewModel()
        {
            // получаем всех пользователей асинхронно
            SetUser();
        }

        public async void SetUser()
        {
            // получаем users
            var users = await userRepository.GetUsersAsync();

            // передаем users // инициализируем нашу кол-цию
            Users = new (users);
        }
        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string propertyName = "") =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
