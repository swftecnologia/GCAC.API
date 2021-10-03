using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using GCAC.Infrastructure.Contextos;
using GCAC.Core.Entidades.Integracao;
using GCAC.Core.Interfaces.Repositorios.Integracao;

namespace GCAC.Infrastructure.Repositorios.Integracao
{
    /// <summary>
    /// Repositório para a entidade EntidadeSindicalListaGeralCNES
    /// </summary>
    public class EntidadeSindicalCNESRepositorio : IEntidadeSindicalCNESRepositorio
    {
        /// <summary>
        /// Contexto da aplicação
        /// </summary>
        private readonly Context _context;

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="context">Contexto da aplicação</param>
        public EntidadeSindicalCNESRepositorio(Context context)
        {
            _context = context;
        }

        /// <summary>
        /// Cria uma nova entidade sindical do CNES e/ou atualiza uma entidade sindical do CNES existente
        /// </summary>
        /// <param name="itens">Lista de novas entidades sindicais do CNES a serem criadas e/ou atualizadas</param>
        /// <returns>Quantidade de registros afetados pela operação solicitada</returns>
        public async Task<int> InserirOuAtualizar(List<EntidadeSindicalListaGeralCNES> itens)
        {
            _context.ChangeTracker.Clear();

            foreach (var item in itens)
            {
                EntidadeSindicalListaGeralCNES entidadeSindicalListaGeralCNES = await _context.EntidadeSindicalListaGeralCNES.Where(x => x.CNPJ == item.CNPJ).SingleOrDefaultAsync();

                if (entidadeSindicalListaGeralCNES != null)
                {
                    entidadeSindicalListaGeralCNES.RazaoSocial = item.RazaoSocial;
                    entidadeSindicalListaGeralCNES.CNPJ = item.CNPJ;
                    entidadeSindicalListaGeralCNES.Grau = item.Grau;
                    entidadeSindicalListaGeralCNES.Grupo = item.Grupo;
                    entidadeSindicalListaGeralCNES.AreaGeoeconomica = item.AreaGeoeconomica;
                    entidadeSindicalListaGeralCNES.Abrangencia = item.Abrangencia;
                    entidadeSindicalListaGeralCNES.UFSede = item.UFSede;
                    entidadeSindicalListaGeralCNES.LocalidadeSede = item.LocalidadeSede;
                    entidadeSindicalListaGeralCNES.Bairro = item.Bairro;
                    entidadeSindicalListaGeralCNES.Logradouro = item.Logradouro;
                    entidadeSindicalListaGeralCNES.Numero = item.Numero;
                    entidadeSindicalListaGeralCNES.DataAtualizacao = DateTime.Now;

                    _context.EntidadeSindicalListaGeralCNES.Attach(entidadeSindicalListaGeralCNES);
                    _context.Entry(entidadeSindicalListaGeralCNES).State = EntityState.Modified;
                }
                else
                {
                    item.DataCriacao = DateTime.Now;
                    item.DataAtualizacao = DateTime.Now;

                    _context.EntidadeSindicalListaGeralCNES.Add(item);
                }
            }

            return await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Cria uma nova entidade sindical do CNES e/ou atualiza uma entidade sindical do CNES existente
        /// </summary>
        /// <param name="itens">Lista de novas entidades sindicais do CNES a serem criadas e/ou atualizadas</param>
        /// <returns>Quantidade de registros afetados pela operação solicitada</returns>
        public async Task<int> InserirOuAtualizar(List<EntidadeSindicalListaBaseTerritorialCNES> itens)
        {
            _context.ChangeTracker.Clear();

            foreach (var item in itens)
            {
                EntidadeSindicalListaBaseTerritorialCNES entidadeSindicalListaBaseTerritorialCNES = await _context.EntidadeSindicalListaBaseTerritorialCNES.Where(x => x.CNPJ == item.CNPJ).SingleOrDefaultAsync();

                if (entidadeSindicalListaBaseTerritorialCNES != null)
                {
                    entidadeSindicalListaBaseTerritorialCNES.CNPJ = item.CNPJ;
                    entidadeSindicalListaBaseTerritorialCNES.BaseTerritorial = item.BaseTerritorial;
                    entidadeSindicalListaBaseTerritorialCNES.DataAtualizacao = DateTime.Now;

                    string[] localidades = item.BaseTerritorial.Split(',');

                    foreach (var local in localidades)
                    {
                        local.Split('*');
                    }


                    //_context.EntidadeSindicalListaBaseTerritorialCNES.Attach(entidadeSindicalListaBaseTerritorialCNES);
                    //_context.Entry(entidadeSindicalListaBaseTerritorialCNES).State = EntityState.Modified;
                }
                else
                {
                    item.DataCriacao = DateTime.Now;
                    item.DataAtualizacao = DateTime.Now;

                    //_context.EntidadeSindicalListaBaseTerritorialCNES.Add(item);
                }
            }

            return await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Cria uma nova entidade sindical do CNES e/ou atualiza uma entidade sindical do CNES existente
        /// </summary>
        /// <param name="itens">Lista de novas entidades sindicais do CNES a serem criadas e/ou atualizadas</param>
        /// <returns>Quantidade de registros afetados pela operação solicitada</returns>
        public async Task<int> InserirOuAtualizar(List<EntidadeSindicalListaCategoriaCNES> itens)
        {
            _context.ChangeTracker.Clear();

            foreach (var item in itens)
            {
                EntidadeSindicalListaCategoriaCNES entidadeSindicalListaCategoriaCNES = await _context.EntidadeSindicalListaCategoriaCNES.Where(x => x.CNPJ == item.CNPJ).SingleOrDefaultAsync();

                if (entidadeSindicalListaCategoriaCNES != null)
                {
                    entidadeSindicalListaCategoriaCNES.CNPJ = item.CNPJ;
                    entidadeSindicalListaCategoriaCNES.Categoria = item.Categoria;
                    entidadeSindicalListaCategoriaCNES.DataAtualizacao = DateTime.Now;

                    _context.EntidadeSindicalListaCategoriaCNES.Attach(entidadeSindicalListaCategoriaCNES);
                    _context.Entry(entidadeSindicalListaCategoriaCNES).State = EntityState.Modified;
                }
                else
                {
                    item.DataCriacao = DateTime.Now;
                    item.DataAtualizacao = DateTime.Now;

                    _context.EntidadeSindicalListaCategoriaCNES.Add(item);
                }
            }

            return await _context.SaveChangesAsync();
        }
    }
}