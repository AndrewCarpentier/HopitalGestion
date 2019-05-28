﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalGestion.bdd
{
    public class Connection
    {
        private static SqlConnection _instance = null;
        private static object _lock = new object();

        public static SqlConnection Instance
        {
            get
            {
                lock (_lock)
                {
                    if (_instance == null)
                        _instance = new SqlConnection(@"Data Source=(localdb)\hopital;Integrated Security=True");

                    return _instance;
                }
            }
        }

        private Connection() { }
    }
}
