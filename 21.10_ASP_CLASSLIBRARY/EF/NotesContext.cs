using _21._10_ASP_CLASSLIBRARY.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace _21._10_ASP_CLASSLIBRARY.EF
{
    public class NotesContext : DbContext
    {
        public DbSet<Note> Notes { get; set; }
        public NotesContext(DbContextOptions<NotesContext> options) : base(options) { }
    }
}
