using System;

namespace API.Entities;

public class AddUser
{
    public int Id { get; set; }
    public required string Username { get; set; } = "";
}
