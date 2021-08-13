﻿using System.Collections.Generic;
using System.Threading.Tasks;
using GCAC.Core.Entidades.InstrumentoColetivo;
using GCAC.Core.Interfaces.Repositorios.InstrumentoColetivo;
using GCAC.Core.Interfaces.Servicos.InstrumentoColetivo;

namespace GCAC.Core.Servicos.InstrumentoColetivo
{
    /// <summary>
    /// Serviços para a entidade Clausula
    /// </summary>
    public class ClausulaServico : IClausulaServico
    {
        /// <summary>
        /// Repositório da entidade Clausula
        /// </summary>
        private readonly IClausulaRepositorio _clausulaRepositorio;

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="clausulaRepositorio">Repositório da entidade Clausula</param>
        public ClausulaServico(IClausulaRepositorio clausulaRepositorio)
        {
            _clausulaRepositorio = clausulaRepositorio;
        }

        /// <summary>
        /// Seleciona todas as claúsulas
        /// </summary>
        /// <returns>Lista de claúsulas</returns>
        public async Task<IEnumerable<Clausula>> SelecionarTodos()
        {
            return await _clausulaRepositorio.SelecionarTodos();
        }

        /// <summary>
        /// Seleciona uma claúsula pelo seu identificador
        /// </summary>
        /// <param name="id">Identificador único da claúsula</param>
        /// <returns>Registro da claúsula solicitada</returns>
        public async Task<Clausula> SelecionarPorId(long id)
        {
            return await _clausulaRepositorio.SelecionarPorId(id);
        }

        /// <summary>
        /// Cria uma nova claúsula
        /// </summary>
        /// <param name="item">Nova claúsula a ser criada</param>
        /// <returns>Quantidade de registros afetados pela operação solicitada</returns>
        public async Task<int> Inserir(Clausula item)
        {
            return await _clausulaRepositorio.Inserir(item);
        }

        /// <summary>
        /// Atualiza uma claúsula
        /// </summary>
        /// <param name="item">Claúsula a ser atualizada</param>
        /// <returns>Quantidade de registros afetados pela operação solicitada</returns>
        public async Task<int> Atualizar(Clausula item)
        {
            return await _clausulaRepositorio.Atualizar(item);
        }

        /// <summary>
        /// Exclui uma claúsula
        /// </summary>
        /// <param name="item">Claúsula a ser excluída</param>
        /// <returns>Quantidade de registros afetados pela operação solicitada</returns>
        public async Task<int> Excluir(Clausula item)
        {
            return await _clausulaRepositorio.Excluir(item);
        }

        /// <summary>
        /// Verifica se a claúsula existe por título
        /// </summary>
        /// <param name="titulo">Título da claúsula</param>
        /// <returns>Valor indicando se a claúsula existe ou não</returns>
        public async Task<bool> ExistePorTitulo(string titulo)
        {
            return await _clausulaRepositorio.ExistePorTitulo(titulo);
        }

        /// <summary>
        /// Verifica se a claúsula existe por título para um identificador diferente da claúsula a ser alterada
        /// </summary>
        /// <param name="id">Identificador único da claúsula</param>
        /// <param name="titulo">Título da claúsula</param>
        /// <returns>Valor indicando se a claúsula existe ou não</returns>
        public async Task<bool> ExistePorTitulo(string titulo, long id)
        {
            return await _clausulaRepositorio.ExistePorTitulo(titulo, id);
        }
    }
}