using FundooNotes.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Context
{
    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions<UserContext> options) : base(options)
        {

        }

        public DbSet<RegisterModel> Users { get; set; }
    }
}
