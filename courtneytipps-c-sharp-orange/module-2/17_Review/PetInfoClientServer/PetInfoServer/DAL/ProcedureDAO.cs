using PetInfoServer.DAL.Interfaces;
using PetInfoServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetInfoServer.DAL
{
    public class ProcedureDAO : IProcedureDAO
    {
        private string connectionString;

        public ProcedureDAO(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public List<Procedures> GetProcedures()
        {
            Procedures procedure = new Procedures
            {
                Name = "TestName"
            };
            //todo fix dao method
            return new List<Procedures>();
        }
    }
}
