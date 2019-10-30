using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CadastroClienteAcademiaCsharp.Domain
{
    public class Cidade
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Estado { get; set; }

        public override string ToString()
        {
            return Nome;
        }
    }
}