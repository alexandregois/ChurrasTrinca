using Realms;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChuurasTrinca.Models.RealmDto
{
    public class ChurrascoDto: RealmObject
    {
        [PrimaryKey]
        public int Id { get; set; }

        public DateTime Data { get; set; }

        public decimal ValorPessoa { get; set; }

        public decimal ValorArrecadado { get; set; }

        public string Descricao { get; set; }

        public ChurrascoItensDto Itens { get; set; }

        public List<PessoasDto> ListaPessoas { get; set; }

    }
}
