using Realms;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChuurasTrinca.Models.RealmDto
{
    public class ChurrascoItensDto: RealmObject
    {
        [PrimaryKey]
        public int Id { get; set; }

        public int Linguiça { get; set; } //KG

        public int AsaFrango { get; set; } //KG

        public int Carne { get; set; } //KG
    }
}
