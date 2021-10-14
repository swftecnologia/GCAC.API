using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GCAC.Infrastructure.Contextos;
using GCAC.Core.Contratos.Repositorios;
using GCAC.Core.Entidades.InstrumentoColetivo;
using GCAC.Core.Interfaces.Repositorios.InstrumentoColetivo;
using GCAC.Core.DTOs.Pesquisa;

namespace GCAC.Infrastructure.Repositorios.InstrumentoColetivo
{
    /// <summary>
    /// Repositório para a entidade Documento
    /// </summary>
    public class DocumentoRepositorio : IBaseRepositorio<Documento>, IDocumentoRepositorio
    {
        /// <summary>
        /// Contexto da aplicação
        /// </summary>
        private readonly Context _context;

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="context">Contexto da aplicação</param>
        public DocumentoRepositorio(Context context)
        {
            _context = context;
        }

        /// <summary>
        /// Seleciona todos os documentos
        /// </summary>
        /// <returns>Lista de documentos</returns>
        public async Task<IEnumerable<Documento>> SelecionarTodos()
        {
            return await _context.Documento.ToListAsync();
        }

        /// <summary>
        /// Seleciona um documento pelo seu identificador
        /// </summary>
        /// <param name="id">Identificador único do documento</param>
        /// <returns>Registro do documento solicitada</returns>
        public async Task<Documento> SelecionarPorId(long id)
        {
            return await _context.Documento.FindAsync(id);
        }

        /// <summary>
        /// Seleciona documento(s) pelo(s) critério(s) estabelecido(s)
        /// </summary>
        /// <param name="predicate">Critério(s) de pesquisa</param>
        /// <returns>Lista de documentos</returns>
        public Task<IEnumerable<Documento>> SelecionarPorCriterio(Expression<Func<Documento, bool>> predicate)
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
            _context.ChangeTracker.Clear();
            _context.Documento.Add(item);
            return await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Atualiza um documento
        /// </summary>
        /// <param name="item">Documento a ser atualizado</param>
        /// <returns>Quantidade de registros afetados pela operação solicitada</returns>
        public async Task<int> Atualizar(Documento item)
        {
            _context.ChangeTracker.Clear();
            _context.Documento.Attach(item);
            _context.Entry(item).State = EntityState.Modified;
            return await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Exclui um documento
        /// </summary>
        /// <param name="item">Documento a ser excluído</param>
        /// <returns>Quantidade de registros afetados pela operação solicitada</returns>
        public async Task<int> Excluir(Documento item)
        {
            _context.ChangeTracker.Clear();
            _context.Documento.Remove(item);
            return await _context.SaveChangesAsync();
        }
    }
}