using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfCoreRelations.Entities;
public class Note
{
    public int Id { get; set; }
    public int Userid { get; set; }
    public string Title { get; set; }
    public string? Description { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }

    public User User { get; set; }
    public Note(int userid, string title, string? description, DateTime createdAt, DateTime? updatedAt) { Userid = userid; Title = title; Description = description; CreatedAt = createdAt; UpdatedAt = updatedAt; }
}
