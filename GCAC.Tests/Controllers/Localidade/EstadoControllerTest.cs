using GCAC.API.Areas.Localidades.Estados.Controllers;
using GCAC.Core.Entidades.Localidade;
using GCAC.Core.Interfaces.Repositorios.Localidade;
using GCAC.Core.Interfaces.Servicos.Localidade;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace GCAC.Tests.Controllers.Localidade
{
    public class EstadoControllerTest
    {
        private readonly Mock<IEstadoServico> _mockRepo;
        private readonly EstadoController _controller;

        public EstadoControllerTest()
        {
            _mockRepo = new Mock<IEstadoServico>();
            _controller = new EstadoController(_mockRepo.Object);
        }

        [Fact]
        public async Task<IEnumerable<Estado>> SelecionarTodos()
        {
            return await _controller.SelecionarTodos();
        }

        [Fact]
        public async Task<ActionResult<Estado>> SelecionarPorId()
        {
            var item = await _controller.SelecionarPorId(2);
            return item;
        }

        [Fact]
        public async Task<IEnumerable<Estado>> SelecionarPorPais()
        {
            return await _controller.SelecionarPorPais(1);
        }
    }
}