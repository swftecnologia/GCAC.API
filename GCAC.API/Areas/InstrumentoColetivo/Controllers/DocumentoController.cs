using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GCAC.API.Areas.InstrumentoColetivo.Entities;
using GCAC.API.Data;
using System.Net;
using HtmlAgilityPack;
using System;
using System.Data;

namespace GCAC.API.Areas.InstrumentoColetivo.Controllers
{
    [Route("api/instrumento-coletivo/[controller]")]
    [ApiController]
    public class DocumentoController : ControllerBase
    {
        private readonly GCACContext _context;

        public DocumentoController(GCACContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Documento>>> GetDocumento()
        {
            //return await _context.Documento.Include(d => d.Cadastro).Include(d => d.Abrangencia).Include(d => d.Classificacao).ToListAsync();
            return await _context.Documento.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Documento>> GetDocumento(long id)
        {
            var documento = await _context.Documento.FindAsync(id);

            if (documento == null)
            {
                return NotFound();
            }

            return documento;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutDocumento(long id, Documento documento)
        {
            if (id != documento.Id)
            {
                return BadRequest();
            }

            _context.Entry(documento).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DocumentoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        private void PopulaDocumento(int ano, int i)
        {
            try
            {
                WebClient wc = new WebClient();

                while (ano < 2021)
                {
                    string numeroSolicitacaoMTE = string.Format("{0:000000}", i);
                    string html = wc.DownloadString("http://www3.mte.gov.br/sistemas/mediador/Resumo/ResumoVisualizar?NrSolicitacao=MR" + numeroSolicitacaoMTE + "/" + ano.ToString());
                    var htmlDoc = new HtmlDocument();
                    htmlDoc.LoadHtml(html);

                    _context.DocumentoMediadorHTML.Add(new DocumentoMediadorHTML() { Conteudo = "<html><head><style>" + htmlDoc.DocumentNode.ChildNodes["html"].ChildNodes["head"].ChildNodes["style"].InnerHtml + "</style></head><body><center>" + htmlDoc.DocumentNode.ChildNodes["html"].ChildNodes["body"].ChildNodes["div"].ChildNodes["center"].InnerHtml + "</center></body></html>" });
                    i += 1;
                }
            }
            catch
            {
                throw;
            }
        }

        [HttpPost]
        public async Task<ActionResult<Documento>> PostDocumento(Documento documento)
        {
            //var entidadesSindicais = _context.EntidadeSindical.ToList();
            //var instrumentosColetivos = _context.DocumentoMediadorHTML.Where(x => x.Ano == "2008").ToList();

            //foreach (var instrumentoColetivo in instrumentosColetivos)
            //{
            //    foreach (var entidadeSindical in entidadesSindicais)
            //    {
            //        if (instrumentoColetivo.Conteudo.Contains(entidadeSindical.CNPJ))
            //        {
            //            _context.DocumentoEntidadeSindical.Add(new DocumentoEntidadeSindical { DocumentoId = instrumentoColetivo.Id, EntidadeSindicalId = entidadeSindical.Id });
            //            await _context.SaveChangesAsync();
            //        }
            //    }
            //}

            //WebClient wc = new WebClient();

            //for (int ano = 2020; ano <= 2020; ano++)
            //{
            //    int naoEncontrado = 0;

            //    for (int i = 62053; i <= 199999; i++)
            //    {
            //        try
            //        {
            //            if (naoEncontrado > 100)
            //            {
            //                i = 200000;
            //            }

            //            string numeroSolicitacao = "MR" + string.Format("{0:000000}", i) + "/" + ano.ToString();
            //            string html = wc.DownloadString("http://www3.mte.gov.br/sistemas/mediador/Resumo/ResumoVisualizar?NrSolicitacao=" + numeroSolicitacao);
            //            var htmlDoc = new HtmlDocument();
            //            htmlDoc.LoadHtml(html);

            //            _context.DocumentoMediadorHTML.Add(new DocumentoMediadorHTML() { NumeroSolicitacao = numeroSolicitacao, Conteudo = "<html><head><style>" + htmlDoc.DocumentNode.ChildNodes["html"].ChildNodes["head"].ChildNodes["style"].InnerHtml + "</style></head><body><center>" + htmlDoc.DocumentNode.ChildNodes["html"].ChildNodes["body"].ChildNodes["div"].ChildNodes["center"].InnerHtml + "</center></body></html>" });
            //            await _context.SaveChangesAsync();

            //            naoEncontrado = 0;
            //        }
            //        catch (Exception ex)
            //        {
            //            naoEncontrado += 1;
            //        }
            //    }
            //}

            return CreatedAtAction("GetDocumento", new { id = documento.Id }, documento);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Documento>> DeleteDocumento(long id)
        {
            var documento = await _context.Documento.FindAsync(id);
            if (documento == null)
            {
                return NotFound();
            }

            _context.Documento.Remove(documento);
            await _context.SaveChangesAsync();

            return documento;
        }

        private bool DocumentoExists(long id)
        {
            return _context.Documento.Any(e => e.Id == id);
        }
    }
}