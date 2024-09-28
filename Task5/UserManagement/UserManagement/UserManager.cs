using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserManagement
{
  public class UserManager
  {
    List<User> users = new List<User>();

    public void AddUser(User user)
    {
      foreach (var item in users) 
      { 
        if(item.Id == user.Id)
        {
          throw new UserAlreadyExistsException("Пользователь с таким ID уже добавлен");
        }
      }
      users.Add(user);
    }

    public void RemoveUser(int id)
    {
      User user = null;
      foreach (var item in users) 
      { 
        if(item.Id == id)
        {
          user = item;
          break;
        }
      }
      if (user is null)
      {
        throw new UserNotFoundException("Пользователь не найден");
      }
      users.Remove(user);
    }

    public User GetUser(int id)
    {
      foreach (var item in users)
      {
        if (item.Id == id)
        {
          return item;
        }
      }
      throw new UserNotFoundException("Пользователь не найден");
    }

    public List<User> ListUsers() 
    { 
      return users;
    }
   }
}
