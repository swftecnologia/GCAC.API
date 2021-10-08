using GCAC.Core.DTOs.Usuario;
using GCAC.Core.Entidades.Usuario;

namespace GCAC.Core.Extensions.Usuario
{
    /// <summary>
    /// Métodos extensivos da entidade Conta
    /// </summary>
    public static class ContaExtension
    {
        /// <summary>
        /// Converte o DTO ContaDTO na entidade Conta
        /// </summary>
        /// <param name="item">Participante a ser convertida</param>
        /// <returns></returns>
        public static Conta AsEntitie(this ContaDTO item)
        {
            return new Conta
            {
                Id = item.Id == null ? 0 : (long)item.Id,
                Ativo = item.Ativo,
                DataExpiracaoAlteracaoSenha = item.DataExpiracaoAlteracaoSenha,
                DataExpiracaoTokenAtivacao = item.DataExpiracaoTokenAtivacao,
                Email = item.Email,
                EmailConfirmado = item.EmailConfirmado,
                Nome = item.Nome,
                Senha = item.Senha,
                Sobrenome = item.Sobrenome,
                TokenAtivacao = item.TokenAtivacao,
                TokenAlteracaoSenha = item.TokenAlteracaoSenha
            };
        }

        /// <summary>
        /// Converte a entidade Conta no DTO ContaDTO
        /// </summary>
        /// <param name="item">Conta a ser convertida</param>
        /// <returns></returns>
        public static ContaDTO AsDTO(this Conta item)
        {
            return new ContaDTO
            {
                Id = item.Id,
                Ativo = item.Ativo,
                DataExpiracaoAlteracaoSenha = item.DataExpiracaoAlteracaoSenha,
                DataExpiracaoTokenAtivacao = item.DataExpiracaoTokenAtivacao,
                Email = item.Email,
                EmailConfirmado = item.EmailConfirmado,
                Nome = item.Nome,
                Senha = item.Senha,
                Sobrenome = item.Sobrenome,
                TokenAtivacao = item.TokenAtivacao,
                TokenAlteracaoSenha = item.TokenAlteracaoSenha
            };
        }
    }
}
