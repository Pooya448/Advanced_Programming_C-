using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Model;

namespace Repository
{
    public class Context : DbContext
    {
        public Context() : base ("Connection")
        {

        }

        public virtual DbSet <Note> Notes { get; set; }
    }
}
