using AutoMapper;

using CustomerManagement.BusinessLogic.Mappers;
using CustomerManagement.BusinessLogic.Models.Dto;
using CustomerManagement.BusinessLogic.Models.Request;
using CustomerManagement.BusinessLogic.Services;
using CustomerManagement.DataAccess.Interfaces;
using CustomerManagement.DataAccess.Models;
using CustomerManagement.DataAccess.Repository;

using Moq;

namespace CustomerManagement.Test
{
    [TestClass]
    public class ClienteServicesTests
    {
        private  IMapper mapper;
        private Mock<IClienteRepository> _clienteRepositoryMock;

        [TestInitialize]
        public void Setup()
        {
            MapperConfiguration mapperConfig = new(cfg =>
           {
               cfg.AddProfile(new ClienteMap());
           });
            mapper = mapperConfig.CreateMapper();

            _clienteRepositoryMock = new Mock<IClienteRepository>();
        }

        [TestMethod]
        public async Task Create_ShouldCreateNewClienteAndReturnDto()
        {
            ClienteServices clienteServices = new(_clienteRepositoryMock.Object, mapper);
            ClienteRequest request = new()
            {
                Nombre = "John",
                Apellido = "Doe",
                NumeroCuenta = "12345",
                CorreoElectronico = "correoPrueba",
                EstadoCivilId = 1,
                GeneroId = 1,
                NumeroIdentificacion = "0951535970",
                ProfesionOcupacion = "pruebas"
            };

            _clienteRepositoryMock.Setup(r => r.All).Returns(new List<Cliente>().AsQueryable());

            ClienteDto result = await clienteServices.Create(request);

            Assert.IsNotNull(result);
            Assert.AreEqual(request.Nombre, result.Nombre);
            Assert.AreEqual(request.Apellido, result.Apellido);

            _clienteRepositoryMock.Verify(r => r.Add(It.IsAny<Cliente>()), Times.Once);
            _clienteRepositoryMock.Verify(r => r.SaveChangesAsync(), Times.Once);
        }

        [TestMethod]
        public async Task Delete_ShouldDeleteExistingClienteAndReturnTrue()
        {

            ClienteServices clienteServices = new(clienteRepository: _clienteRepositoryMock.Object, mapper);
            Guid existingClienteId = Guid.NewGuid();


            _clienteRepositoryMock.Setup(r => r.FindAll(existingClienteId)).Returns(new Cliente
            {
                Id = Guid.NewGuid(),
                Nombre = "John",
                Apellido = "Doe",
                Activo = true,
                NumeroCuenta = "12345",
                UsuarioCreacion = "12345",
                CorreoElectronico = "correoPrueba",
                EstadoCivilId = 1,
                GeneroId = 1,
                NumeroIdentificacion = "0951535970",
                ProfesionOcupacion = "pruebas"
            });


            bool result = await clienteServices.Delete(existingClienteId);


            Assert.IsTrue(result);


            _clienteRepositoryMock.Verify(r => r.Delete(It.IsAny<Cliente>()), Times.Once);
            _clienteRepositoryMock.Verify(r => r.SaveChangesAsync(), Times.Once);
        }


        [TestMethod]
        public async Task GetAll_ShouldReturnListOfClientes()
        {
            DataAccess.Context.CustomerDbContext dbContext = DbContextHelper.GetTestDbContext();
            ClienteRepository clienteRepository = new(dbContext);


            ClienteServices clienteServices = new(_clienteRepositoryMock.Object, mapper);

            List<Cliente> clientes = new()
            {
                new Cliente { Id = Guid.NewGuid(), Nombre = "John", Apellido = "Doe", Activo = true, NumeroCuenta = "12345", UsuarioCreacion = "12345", CorreoElectronico = "correoPrueba", EstadoCivilId = 1, GeneroId = 1, NumeroIdentificacion = "0951535970", ProfesionOcupacion = "pruebas" },
                new Cliente { Id = Guid.NewGuid(), Nombre = "Jane", Apellido = "Smith", Activo = true, NumeroCuenta = "54321", UsuarioCreacion = "54321", CorreoElectronico = "correoPrueba2", EstadoCivilId = 2, GeneroId = 2, NumeroIdentificacion = "1234567890", ProfesionOcupacion = "pruebas2" },
                new Cliente { Id = Guid.NewGuid(), Nombre = "Jane", Apellido = "Smith", Activo = true, NumeroCuenta = "54321", UsuarioCreacion = "54321", CorreoElectronico = "correoPrueba2", EstadoCivilId = 2, GeneroId = 2, NumeroIdentificacion = "1234567890", ProfesionOcupacion = "pruebas2" },
                new Cliente { Id = Guid.NewGuid(), Nombre = "Jane", Apellido = "Smith", Activo = true, NumeroCuenta = "54321", UsuarioCreacion = "54321", CorreoElectronico = "correoPrueba2", EstadoCivilId = 2, GeneroId = 2, NumeroIdentificacion = "1234567890", ProfesionOcupacion = "pruebas2" },
                new Cliente { Id = Guid.NewGuid(), Nombre = "Jane", Apellido = "Smith", Activo = true, NumeroCuenta = "54321", UsuarioCreacion = "54321", CorreoElectronico = "correoPrueba2", EstadoCivilId = 2, GeneroId = 2, NumeroIdentificacion = "1234567890", ProfesionOcupacion = "pruebas2" },
                new Cliente { Id = Guid.NewGuid(), Nombre = "Jane", Apellido = "Smith", Activo = true, NumeroCuenta = "54321", UsuarioCreacion = "54321", CorreoElectronico = "correoPrueba2", EstadoCivilId = 2, GeneroId = 2, NumeroIdentificacion = "1234567890", ProfesionOcupacion = "pruebas2" },
                new Cliente { Id = Guid.NewGuid(), Nombre = "Jane", Apellido = "Smith", Activo = true, NumeroCuenta = "54321", UsuarioCreacion = "54321", CorreoElectronico = "correoPrueba2", EstadoCivilId = 2, GeneroId = 2, NumeroIdentificacion = "1234567890", ProfesionOcupacion = "pruebas2" }
            };

            dbContext.Cliente.AddRange(clientes);
            await dbContext.SaveChangesAsync();


            _clienteRepositoryMock.Setup(r => r.GetAllPaginateAsync<ClienteDto>(mapper, 1, 5))
                                  .Returns(clienteRepository.GetAllPaginateAsync<ClienteDto>(mapper, 1, 5));


            List<ClienteDto> result = await clienteServices.GetAll();


            Assert.IsNotNull(result);
            Assert.AreEqual(result.Count, 5);
            dbContext.Dispose();
        }


        [TestMethod]
        public async Task GetById_ShouldReturnClienteDto()
        {

            ClienteServices clienteServices = new(_clienteRepositoryMock.Object, mapper);
            Guid clientId = Guid.NewGuid();
            ClienteDto clienteDto = new() { Id = clientId, Nombre = "John", Apellido = "Doe", NumeroCuenta = "12345", CorreoElectronico = "correoPrueba", EstadoCivilId = 1, GeneroId = 1, NumeroIdentificacion = "0951535970", ProfesionOcupacion = "pruebas" };


            _clienteRepositoryMock.Setup(r => r.FindAllAsync<ClienteDto>(mapper, clientId))
                                  .ReturnsAsync(clienteDto);


            ClienteDto result = await clienteServices.GetById(clienteDto.Id);


            Assert.IsNotNull(result);
            Assert.AreEqual(clientId, result.Id);
            Assert.AreEqual(clienteDto.Nombre, result.Nombre);

            _clienteRepositoryMock.Verify(r => r.FindAllAsync<ClienteDto>(mapper, clientId), Times.Once);
        }

        [TestMethod]
        public async Task Update_ShouldUpdateExistingClienteAndReturnDto()
        {
            ClienteServices clienteServices = new(_clienteRepositoryMock.Object, mapper);
            Guid existingClienteId = Guid.NewGuid();
            ClienteRequest request = new()
            {
                Nombre = "John",
                Apellido = "Doe",
                NumeroCuenta = "12345",
                CorreoElectronico = "correoPrueba",
                EstadoCivilId = 1,
                GeneroId = 1,
                NumeroIdentificacion = "0951535970",
                ProfesionOcupacion = "pruebas"
            };

            Cliente existingCliente = new() { Id = existingClienteId, Nombre = "John", Apellido = "Doe", Activo = true, NumeroCuenta = "12345", UsuarioCreacion = "12345", CorreoElectronico = "correoPrueba", EstadoCivilId = 1, GeneroId = 1, NumeroIdentificacion = "0951535970", ProfesionOcupacion = "pruebas" };
            _clienteRepositoryMock.Setup(r => r.FindAll(existingClienteId))
                                  .Returns(existingCliente);

            ClienteDto result = await clienteServices.Update(existingClienteId, request);

            Assert.IsNotNull(result);
            Assert.AreEqual(existingClienteId, result.Id);
            Assert.AreEqual(request.Nombre, result.Nombre);

            _clienteRepositoryMock.Setup(r => r.UpdateAsync(It.IsAny<Cliente>()))
                                 .Returns(Task.CompletedTask);

            _clienteRepositoryMock.Setup(r => r.SaveChangesAsync())
                                  .Returns(Task.CompletedTask);

        }
    }
}
