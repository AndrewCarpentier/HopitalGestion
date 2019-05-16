using HospitalGestion.bdd;
using HospitalGestion.classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalGestion
{
    class Program
    {
        static void Main(string[] args)
        {
           
            Hopital h = DBCommand.GetHopital("toto");
            Console.WriteLine(" ");
        }
    }
}
