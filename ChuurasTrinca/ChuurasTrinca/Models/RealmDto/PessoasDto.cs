using Realms;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChuurasTrinca.Models.RealmDto
{
    public class PessoasDto: RealmObject
    {

        [PrimaryKey]
        public int Id { get; set; }

        public string Nome { get; set; }

        public decimal Valor { get; set; }

        public bool IsPago { get; set; }
    }
}
