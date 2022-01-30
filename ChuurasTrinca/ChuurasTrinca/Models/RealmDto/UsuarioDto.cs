using Realms;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChuurasTrinca.Models.RealmDto
{
    public class UsuarioDto: RealmObject
    {
        [PrimaryKey]
        public int Id { get; set; }

        public string Nome { get; set; }
        public string Login { get; set; }
        public String Senha { get; set; }
    }
}
