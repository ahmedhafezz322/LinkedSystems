
using Microsoft.AspNetCore.Identity;

namespace LinkedSystems.DAL.Data.Models;

public class User : IdentityUser
{
    public string FirstName { get; set; }
    public string LastName { get; set; }

}

