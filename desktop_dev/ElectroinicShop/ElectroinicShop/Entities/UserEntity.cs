using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ElectroinicShop.Entities;


public class UserEntity
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Password { get; set; }

    public UserEntity() { }

    public UserEntity(string name, string password) { Name = name; Password = password; }
}
