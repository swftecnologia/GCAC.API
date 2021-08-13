﻿using System.Collections.Generic;
using System.Threading.Tasks;
using GCAC.Core.Entidades.InstrumentoColetivo;
using GCAC.Core.Interfaces.Repositorios.InstrumentoColetivo;
using GCAC.Core.Interfaces.Servicos.InstrumentoColetivo;

namespace GCAC.Core.Servicos.InstrumentoColetivo
{
    /// <summary>
    /// Serviços para a entidade ClausulaSubGrupo
    /// </summary>
    public class ClausulaSubGrupoServico : IClausulaSubGrupoServico
    {
        /// <summary>
        /// Repositório da entidade ClausulaSubGrupo
        /// </summary>
        private readonly IClausulaSubGrupoRepositorio _clausulaSubGrupoRepositorio;

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="clausulaSubGrupoRepositorio">Repositório da entidade ClausulaSubGrupo</param>
        public ClausulaSubGrupoServico(IClausulaSubGrupoRepositorio clausulaSubGrupoRepositorio)
        {
            _clausulaSubGrupoRepositorio = clausulaSubGrupoRepositorio;
        }

        /// <summary>
        /// Seleciona todos os sub-grupos do grupo da claúsula
        /// </summary>
        /// <returns>Lista de sub-grupos do grupo da claúsula</returns>
        public async Task<IEnumerable<ClausulaSubGrupo>> SelecionarTodos()
        {
            return await _clausulaSubGrupoRepositorio.SelecionarTodos();
        }

        /// <summary>
        /// Seleciona um sub-grupo do grupo da claúsula pelo seu identificador
        /// </summary>
        /// <param name="id">Identificador único do sub-grupo do grupo da claúsula</param>
        /// <returns>Registro do sub-grupo do grupo da claúsula solicitada</returns>
        public async Task<ClausulaSubGrupo> SelecionarPorId(long id)
        {
            return await _clausulaSubGrupoRepositorio.SelecionarPorId(id);
        }

        /// <summary>
        /// Cria um novo sub-grupo do grupo da claúsula
        /// </summary>
        /// <param name="item">Novo sub-grupo do grupo da claúsula a ser criado</param>
        /// <returns>Quantidade de registros afetados pela operação solicitada</returns>
        public async Task<int> Inserir(ClausulaSubGrupo item)
        {
            return await _clausulaSubGrupoRepositorio.Inserir(item);
        }

        /// <summary>
        /// Atualiza um sub-grupo do grupo da claúsula
        /// </summary>
        /// <param name="item">Sub-Grupo do grupo da claúsula a ser atualizado</param>
        /// <returns>Quantidade de registros afetados pela operação solicitada</returns>
        public async Task<int> Atualizar(ClausulaSubGrupo item)
        {
            return await _clausulaSubGrupoRepositorio.Atualizar(item);
        }

        /// <summary>
        /// Exclui um sub-grupo do grupo da claúsula
        /// </summary>
        /// <param name="item">Sub-Grupo do grupo da claúsula a ser excluído</param>
        /// <returns>Quantidade de registros afetados pela operação solicitada</returns>
        public async Task<int> Excluir(ClausulaSubGrupo item)
        {
            return await _clausulaSubGrupoRepositorio.Excluir(item);
        }

        /// <summary>
        /// Verifica se o sub-grupo do grupo da claúsula existe por descrição
        /// </summary>
        /// <param name="descricao">Descrição do sub-grupo do grupo da claúsula</param>
        /// <returns>Valor indicando se o sub-grupo do grupo da claúsula existe ou não</returns>
        public async Task<bool> ExistePorDescricao(string descricao)
        {
            return await _clausulaSubGrupoRepositorio.ExistePorDescricao(descricao);
        }

        /// <summary>
        /// Verifica se o sub-grupo do grupo da claúsula existe por descrição para um identificador diferente do sub-grupo do grupo da claúsula a ser alterado
        /// </summary>
        /// <param name="id">Identificador único do sub-grupo do grupo da claúsula</param>
        /// <param name="descricao">Descrição do sub-grupo do grupo da claúsula</param>
        /// <returns>Valor indicando se o sub-grupo do grupo da claúsula existe ou não</returns>
        public async Task<bool> ExistePorDescricao(string descricao, long id)
        {
            return await _clausulaSubGrupoRepositorio.ExistePorDescricao(descricao, id);
        }
    }
}