using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Sauric.Domain;

public class AuthUserDbContext : IdentityDbContext<AuthUser>
{
    public AuthUserDbContext(DbContextOptions<AuthUserDbContext> options): base(options) 
    {

    }
}
