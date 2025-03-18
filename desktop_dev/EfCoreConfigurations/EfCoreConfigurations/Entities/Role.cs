using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfCoreConfigurations.Entities;
public class Role
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }

    public Role() { }
    public Role(string title, string description) { Title = title; Description = description; }
}
