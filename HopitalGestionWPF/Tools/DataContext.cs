using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HopitalGestionWPF.Tools
{
    public class DataContext: DbContext
    {
        private static readonly string connectionString = @"Data Source=(LocalDB)\entity;Integrated Security=True";

        public DataContext() : base(connectionString)
        {

        }
    }
}
