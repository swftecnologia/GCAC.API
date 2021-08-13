using System;

namespace GCAC.API.Areas.Usuarios.Contas.DataTransferObjects
{
    public record ContaDTORead
    {
        public int Id { get; init; }

        public bool Ativo { get; init; }

        public DateTime DataAtualizacao { get; init; }

        public DateTime DataCriacao { get; init; }

        public DateTime? DataExpiracaoAlteracaoSenha { get; init; }

        public DateTime DataExpiracaoTokenAtivacao { get; init; }

        public string Email { get; init; }

        public bool EmailConfirmado { get; init; }

        public string Nome { get; init; }

        public string Senha { get; init; }

        public string Sobrenome { get; init; }

        public Guid TokenAtivacao { get; init; }

        public Guid? TokenAlteracaoSenha { get; init; }

        public string Usuario { get; init; }
    }
}