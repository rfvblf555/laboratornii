using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace desktop5lab.Entities;

public class NoteEntity
{
    public int Id { get; set; }

    public int UserId { get; set; }
    public string Name { get; set; }
    public string Content { get; set; }
    public string Category { get; set; }
    public DateTime CreatedAt { get; set; }

    public PersonEntity Person { get; set; } = null!;

    public NoteEntity(
        int userId,
        string name,
        string content,
        string category,
        DateTime createdAt
        )
    {
        UserId = userId;
        Name = name;
        Content = content;
        Category = category;

        CreatedAt = DateTime.Now;
    }
}
