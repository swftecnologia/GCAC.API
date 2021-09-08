using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using GCAC.Core.Entidades.InstrumentoColetivo;
using GCAC.Core.Interfaces.Repositorios.InstrumentoColetivo;
using GCAC.Core.Interfaces.Servicos;
using GCAC.Core.Interfaces.Servicos.InstrumentoColetivo;

namespace GCAC.Core.Servicos.InstrumentoColetivo
{
    /// <summary>
    /// Serviços para a entidade Documento
    /// </summary>
    public class DocumentoServico : IBaseServico<Documento>, IDocumentoServico
    {
        /// <summary>
        /// Repositório da entidade Documento
        /// </summary>
        private readonly IDocumentoRepositorio _documentoRepositorio;

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="documentoRepositorio">Repositório da entidade Documento</param>
        public DocumentoServico(IDocumentoRepositorio documentoRepositorio)
        {
            _documentoRepositorio = documentoRepositorio;
        }

        /// <summary>
        /// Seleciona todos os documentos
        /// </summary>
        /// <returns>Lista de documentos</returns>
        public async Task<IEnumerable<Documento>> SelecionarTodos()
        {
            return await _documentoRepositorio.SelecionarTodos();
        }

        /// <summary>
        /// Seleciona um documento pelo seu identificador
        /// </summary>
        /// <param name="id">Identificador único do documento</param>
        /// <returns>Registro do documento solicitada</returns>
        public async Task<Documento> SelecionarPorId(long id)
        {
            return await _documentoRepositorio.SelecionarPorId(id);
        }

        /// <summary>
        /// Seleciona documento(s) pelo(s) critério(s) estabelecido(s)
        /// </summary>
        /// <param name="predicate">Critério(s) de pesquisa</param>
        public async Task<IEnumerable<Documento>> SelecionarPorCriterio(Expression<Func<Documento, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Cria um novo documento
        /// </summary>
        /// <param name="item">Novo documento a ser criado</param>
        /// <returns>Quantidade de registros afetados pela operação solicitada</returns>
        public async Task<int> Inserir(Documento item)
        {
            return await _documentoRepositorio.Inserir(item);
        }

        /// <summary>
        /// Atualiza um documento
        /// </summary>
        /// <param name="item">Documento a ser atualizado</param>
        /// <returns>Quantidade de registros afetados pela operação solicitada</returns>
        public async Task<int> Atualizar(Documento item)
        {
            return await _documentoRepositorio.Atualizar(item);
        }

        /// <summary>
        /// Exclui um documento
        /// </summary>
        /// <param name="item">Documento a ser excluído</param>
        /// <returns>Quantidade de registros afetados pela operação solicitada</returns>
        public async Task<int> Excluir(Documento item)
        {
            return await _documentoRepositorio.Excluir(item);
        }
    }
}