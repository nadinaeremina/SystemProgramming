using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Home.Model;
using Home.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace Home
{
    // модель взаимодействия с БД
    internal class UserRepository
    {
        // метод получения всех пользоватлеей
        public async Task<List<User>> GetUsersAsync() // 'Task' для прменения 'await'
        {
            var userContext = new UserContext();
            // дожидаемся получения наших пользователей
            return await userContext.Users.ToListAsync();             
        }

        // добавление пользователя
        public async Task AddUserAsync(User user)
        {
            var userContext = new UserContext();
            // дожидаемся пользователя
            await userContext.Users.AddAsync(user);
            userContext.SaveChangesAsync();
        }

        // редактирование пользователя
        public async Task EditUserAsync(int id, User user)
        {
            var userContext = new UserContext();

            // ниже будет краткая запись
            var editableUser = await userContext.Users.FirstAsync(user => user.Id == id);
            if (editableUser == null)
            {
                throw new Exception("Не найден пользователь!");
            }

            // краткая запись
            // var editableUser = await userContext.Users.FirstAsync(user => user.Id == id) ?? throw new Exception("Не найден пользователь!");

            editableUser.Name = user.Name;
            editableUser.Surname = user.Surname;
            editableUser.Email = user.Email;

            await userContext.Users.AddAsync(user);//???????????????
            // ожидание обновления
            await userContext.SaveChangesAsync();
        }
        public async Task RemoveUserAsync(int id)
        {
            var userContext = new UserContext();

            // краткая запись
            var removingUser = await userContext.Users.FirstAsync(user => user.Id == id) ?? throw new Exception("Не найден пользователь!");

            // 'await' не нужен - тк это синхронно происходит
            userContext.Users.Remove(removingUser);
            // сохраняем изменения в БД
            await userContext.SaveChangesAsync();
        }
    }
}
