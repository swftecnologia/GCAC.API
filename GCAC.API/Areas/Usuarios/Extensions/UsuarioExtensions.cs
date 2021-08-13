using System;
using GCAC.API.Areas.Usuarios.Contas.DataTransferObjects;
using GCAC.API.Areas.Usuarios.Contas.Entities;
using GCAC.API.Utils;

namespace GCAC.API.Areas.Usuarios.Extensions
{
    public static class UsuarioExtensions
    {
        public static ContaDTORead AsDTO(this Conta item)
        {
            return new ContaDTORead
            {
                Id = item.Id,
                Ativo = item.Ativo,
                DataAtualizacao = item.DataAtualizacao,
                DataCriacao = item.DataCriacao,
                DataExpiracaoAlteracaoSenha = item.DataExpiracaoAlteracaoSenha,
                DataExpiracaoTokenAtivacao = item.DataExpiracaoTokenAtivacao,
                Email = item.Email,
                EmailConfirmado = item.EmailConfirmado,
                Nome = item.Nome,
                Senha = item.Senha,
                Sobrenome = item.Sobrenome,
                TokenAtivacao = item.TokenAtivacao,
                TokenAlteracaoSenha = item.TokenAlteracaoSenha,
                Usuario = item.Usuario
            };
        }

        public static Conta AsEntitie(this ContaDTORead item)
        {
            return new Conta
            {
                Id = item.Id,
                Ativo = item.Ativo,
                DataAtualizacao = item.DataAtualizacao,
                DataCriacao = item.DataCriacao,
                DataExpiracaoAlteracaoSenha = item.DataExpiracaoAlteracaoSenha,
                DataExpiracaoTokenAtivacao = item.DataExpiracaoTokenAtivacao,
                Email = item.Email,
                EmailConfirmado = item.EmailConfirmado,
                Nome = item.Nome,
                Senha = item.Senha,
                Sobrenome = item.Sobrenome,
                TokenAtivacao = item.TokenAtivacao,
                TokenAlteracaoSenha = item.TokenAlteracaoSenha,
                Usuario = item.Usuario
            };
        }

        public static Conta AsEntitie(this ContaDTOCreate item)
        {
            return new Conta
            {
                Ativo = false,
                DataAtualizacao = DateTime.Now,
                DataCriacao = DateTime.Now,
                DataExpiracaoAlteracaoSenha = null,
                DataExpiracaoTokenAtivacao = DateTime.MaxValue,
                Email = item.Email,
                EmailConfirmado = false,
                Nome = item.Nome,
                Senha = Seguranca.CriptografarSenha(item.Senha),
                Sobrenome = item.Sobrenome,
                TokenAtivacao = Guid.NewGuid(),
                TokenAlteracaoSenha = null,
                Usuario = Environment.UserName
            };
        }

        public static Conta AsEntitie(this ContaDTOUpdate item)
        {
            return new Conta
            {
                Id = item.Id,
                Ativo = false,
                DataAtualizacao = DateTime.Now,
                DataCriacao = DateTime.Now,
                DataExpiracaoAlteracaoSenha = null,
                DataExpiracaoTokenAtivacao = DateTime.MaxValue,
                Email = item.Email,
                EmailConfirmado = false,
                Nome = item.Nome,
                Senha = Seguranca.CriptografarSenha(item.Senha),
                Sobrenome = item.Sobrenome,
                TokenAtivacao = Guid.NewGuid(),
                TokenAlteracaoSenha = null,
                Usuario = Environment.UserName
            };
        }
    }
}