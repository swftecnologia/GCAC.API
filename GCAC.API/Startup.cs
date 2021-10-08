using System;
using System.Reflection;
using System.IO;
using System.Collections.Generic;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerUI;
using Audit.Core;
using GCAC.API.Data;
using GCAC.API.Extensions;
using GCAC.Infrastructure.Contextos;
using GCAC.Core.Interfaces.Servicos.Localidade;
using GCAC.Core.Servicos.Localidade;
using GCAC.Infrastructure.Repositorios.Localidade;
using GCAC.Core.Interfaces.Repositorios.Localidade;
using GCAC.Core.Interfaces.Servicos.InstrumentoColetivo;
using GCAC.Core.Servicos.InstrumentoColetivo;
using GCAC.Core.Interfaces.Repositorios.InstrumentoColetivo;
using GCAC.Infrastructure.Repositorios.InstrumentoColetivo;
using GCAC.Core.Contratos.Servicos.Participante;
using GCAC.Core.Servicos.Participante;
using GCAC.Core.Contratos.Repositorios.Participante;
using GCAC.Infrastructure.Repositorios.Participante;
using GCAC.Infrastructure.Repositorios;
using GCAC.Core.Interfaces.Repositorios;
using GCAC.Core.Contratos.Repositorios;
using GCAC.Core.Interfaces.Repositorios.Integracao;
using GCAC.Infrastructure.Repositorios.Integracao;
using GCAC.Core.Interfaces.Servicos.Integracao;
using GCAC.Core.Contratos.Servicos;
using GCAC.Core.Contratos.Servicos.Usuario;
using GCAC.Core.Servicos.Usuario;
using GCAC.Core.Contratos.Repositorios.Usuario;
using GCAC.Infrastructure.Repositorios.Usuario;

namespace GCAC.API
{
    /// <summary>
    /// 
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="configuration"></param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        /// <summary>
        /// 
        /// </summary>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            //NewtonsoftJson
            services.AddControllers().AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            //Context
            services.AddDbContext<GCACContext>(opition =>
                opition.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddDbContext<Context>(opition =>
                opition.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            //Cors
            services.AddCors(options =>
            {
                options.AddDefaultPolicy(
                    builder =>
                    {
                        builder.WithOrigins("https://www.gcac.com.br/")
                        .AllowAnyOrigin()
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                    });
            });

            //Swagger
            services.AddSwaggerGen(c =>
            {
                //c.OrderActionsBy((apiDesc) => $"{apiDesc.ActionDescriptor.RouteValues["controller"]}_{apiDesc.RelativePath}");

                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "GCAC API",
                    Description = "A simple example ASP.NET Core Web API",
                    TermsOfService = new Uri("https://example.com/terms"),
                    Contact = new OpenApiContact
                    {
                        Name = "SWF Tecnologia LTDA",
                        Email = string.Empty,
                        Url = new Uri("https://twitter.com/spboyer"),
                    },
                    License = new OpenApiLicense
                    {
                        Name = "Use under LICX",
                        Url = new Uri("https://example.com/license"),
                    }
                });

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });

            //Session
            services.AddDistributedMemoryCache();
            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(30);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });

            //Serviços
            #region Serviços

            services.AddScoped(typeof(IBaseServico<>), typeof(BaseServico<>));

            #region Integracao

            services.AddScoped<IEntidadeSindicalCNESServico, EntidadeSindicalCNESServico>();

            #endregion

            #region Instrumento Coletivo

            services.AddScoped<ICategoriaServico, CategoriaServico>();
            services.AddScoped<IClassificacaoServico, ClassificacaoServico>();
            services.AddScoped<IClausulaGrupoServico, ClausulaGrupoServico>();
            services.AddScoped<IClausulaServico, ClausulaServico>();
            services.AddScoped<IClausulaSubGrupoServico, ClausulaSubGrupoServico>();
            services.AddScoped<IDocumentoServico, DocumentoServico>();
            services.AddScoped<IEntidadeSindicalServico, EntidadeSindicalServico>();

            #endregion

            #region Localidade

            services.AddScoped<IPaisServico, PaisServico>();
            services.AddScoped<IEstadoServico, EstadoServico>();
            services.AddScoped<IMunicipioServico, MunicipioServico>();
            services.AddScoped<IRegiaoServico, RegiaoServico>();

            #endregion

            #region Participante

            services.AddScoped<IAbrangenciaServico, AbrangenciaServico>();
            services.AddScoped<IContatoServico, ContatoServico>();
            services.AddScoped<IFuncaoServico, FuncaoServico>();
            services.AddScoped<IGrauEntidadeServico, GrauEntidadeServico>();
            services.AddScoped<IGrupoServico, GrupoServico>();
            services.AddScoped<IParticipanteServico, ParticipanteServico>();
            services.AddScoped<IRepresentanteLegalServico, RepresentanteLegalServico>();
            services.AddScoped<ITipoContatoServico, TipoContatoServico>();
            services.AddScoped<ITipoPessoaServico, TipoPessoaServico>();

            #endregion

            #region Usuário

            #endregion

            services.AddScoped<IContaServico, ContaServico>();

            #endregion

            //Repositórios
            #region Repositorios

            services.AddScoped(typeof(IBaseRepositorio<>), typeof(BaseRepositorio<>));

            #region Integracao

            services.AddScoped<IEntidadeSindicalCNESRepositorio, EntidadeSindicalCNESRepositorio>();

            #endregion

            #region Instrumento Coletivo

            services.AddScoped<ICategoriaRepositorio, CategoriaRepositorio>();
            services.AddScoped<IClassificacaoRepositorio, ClassificacaoRepositorio>();
            services.AddScoped<IClausulaGrupoRepositorio, ClausulaGrupoRepositorio>();
            services.AddScoped<IClausulaRepositorio, ClausulaRepositorio>();
            services.AddScoped<IClausulaSubGrupoRepositorio, ClausulaSubGrupoRepositorio>();
            services.AddScoped<IDocumentoRepositorio, DocumentoRepositorio>();
            services.AddScoped<IEntidadeSindicalRepositorio, EntidadeSindicalRepositorio>();

            #endregion

            #region Localidade

            services.AddScoped<IPaisRepositorio, PaisRepositorio>();
            services.AddScoped<IEstadoRepositorio, EstadoRepositorio>();
            services.AddScoped<IMunicipioRepositorio, MunicipioRepositorio>();
            services.AddScoped<IRegiaoRepositorio, RegiaoRepositorio>();

            #endregion

            #region Participante

            services.AddScoped<IAbrangenciaRepositorio, AbrangenciaRepositorio>();
            services.AddScoped<IContatoRepositorio, ContatoRepositorio>();
            services.AddScoped<IFuncaoRepositorio, FuncaoRepositorio>();
            services.AddScoped<IGrauEntidadeRepositorio, GrauEntidadeRepositorio>();
            services.AddScoped<IGrupoRepositorio, GrupoRepositorio>();
            services.AddScoped<IParticipanteRepositorio, ParticipanteRepositorio>();
            services.AddScoped<IRepresentanteLegalRepositorio, RepresentanteLegalRepositorio>();
            services.AddScoped<ITipoContatoRepositorio, TipoContatoRepositorio>();
            services.AddScoped<ITipoPessoaRepositorio, TipoPessoaRepositorio>();

            #endregion

            #region Usuário

            services.AddScoped<IContaRepositorio, ContaRepositorio>();

            #endregion

            #endregion
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //Configuração de Ambientes
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //Swagger
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "GCAC.API");
                c.RoutePrefix = string.Empty;
                c.DocExpansion(DocExpansion.None);
            });

            //Session
            app.UseSession();

            //Middleware
            app.UseMiddleware<ExceptionMiddleware>();
            
            //Https
            app.UseHttpsRedirection();
            
            //Routing
            app.UseRouting();
            
            //Cors
            app.UseCors();
            
            //Authorization
            app.UseAuthorization();
            
            //Endpoints
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            //Audit Core
            Audit.Core.Configuration.Setup().UseEntityFramework(ef =>
                ef.AuditTypeMapper(t => typeof(GCAC.Core.Entidades.Log.Auditoria))
                .AuditEntityAction<GCAC.Core.Entidades.Log.Auditoria>((ev, entry, entity) =>
                {
                    entity.Dados = entry.ToJson();
                    entity.Usuario = Environment.UserName;
                    entity.DataOperacao = DateTime.Now;
                })
                .IgnoreMatchedProperties(true));
        }
    }
}