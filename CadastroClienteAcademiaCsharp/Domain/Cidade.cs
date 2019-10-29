using System;

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