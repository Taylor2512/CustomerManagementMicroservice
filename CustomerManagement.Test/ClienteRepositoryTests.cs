using AutoMapper;

using CustomerManagement.BusinessLogic.Mappers;
using CustomerManagement.BusinessLogic.Models.Dto;
using CustomerManagement.DataAccess.Models;
using CustomerManagement.DataAccess.Repository;

using Microsoft.EntityFrameworkCore;

namespace CustomerManagement.Test
{
    [TestClass]
    public class ClienteRepositoryTests
    {
        [TestMethod]
        public async Task AddAsync_ShouldAddNewClienteToDatabase()
        {
            // Arrange
            DataAccess.Context.CustomerDbContext dbContext = DbContextHelper.GetTestDbContext();
            ClienteRepository clienteRepository = new(dbContext);

            Cliente newCliente = new()
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
            };

            // Act
            Task task1 = clienteRepository.AddAsync(newCliente);
            Task task2 = clienteRepository.SaveChangesAsync();
            await Task.WhenAll(task1, task2);
            // Assert
            Cliente? addedCliente = await dbContext.Cliente.FirstOrDefaultAsync(c => c.Id == newCliente.Id);
            Assert.IsNotNull(addedCliente);
            Assert.AreEqual(newCliente.Nombre, addedCliente.Nombre);
            Assert.AreEqual(newCliente.Apellido, addedCliente.Apellido);

            // Limpiar
            dbContext.Dispose();
        }
        [TestMethod]
        public async Task UpdateClienteToDatabase_ShouldUpdateExistingCliente()
        {
            // Arrange
            DataAccess.Context.CustomerDbContext dbContext = DbContextHelper.GetTestDbContext();
            ClienteRepository clienteRepository = new(dbContext);

            Cliente existingCliente = new()
            {
                Id = Guid.NewGuid(),
                Nombre = "John",
                Apellido = "Doe",
                NumeroCuenta = "12345",
                UsuarioCreacion = "12345",
                CorreoElectronico = "correoPrueba",
                EstadoCivilId = 1,
                GeneroId = 1,
                Activo = true,
                NumeroIdentificacion = "0951535970",
                ProfesionOcupacion = "pruebas"

            };

            await clienteRepository.AddAsync(existingCliente);
            await clienteRepository.SaveChangesAsync();

            // Act
            // Modificar la entidad existente en lugar de crear una nueva
            existingCliente.Nombre = "UpdatedName";
            existingCliente.Apellido = "UpdatedLastName";
            existingCliente.NumeroCuenta = "54321";
            existingCliente.UsuarioCreacion = "54321";
            existingCliente.CorreoElectronico = "updatedCorreoPrueba";
            existingCliente.EstadoCivilId = 2;
            existingCliente.GeneroId = 2;
            existingCliente.NumeroIdentificacion = "1234567890";
            existingCliente.ProfesionOcupacion = "updatedPruebas";

            await clienteRepository.UpdateAsync(existingCliente);
            await clienteRepository.SaveChangesAsync();

            // Assert
            Cliente? updatedClienteFromDb = await dbContext.Cliente.FirstOrDefaultAsync(c => c.Id == existingCliente.Id);
            Assert.IsNotNull(updatedClienteFromDb);
            Assert.AreEqual(existingCliente.Nombre, updatedClienteFromDb.Nombre);
            Assert.AreEqual(existingCliente.Apellido, updatedClienteFromDb.Apellido);
            Assert.AreEqual(existingCliente.NumeroCuenta, updatedClienteFromDb.NumeroCuenta);
            Assert.AreEqual(existingCliente.UsuarioCreacion, updatedClienteFromDb.UsuarioCreacion);
            Assert.AreEqual(existingCliente.CorreoElectronico, updatedClienteFromDb.CorreoElectronico);
            Assert.AreEqual(existingCliente.EstadoCivilId, updatedClienteFromDb.EstadoCivilId);
            Assert.AreEqual(existingCliente.GeneroId, updatedClienteFromDb.GeneroId);
            Assert.AreEqual(existingCliente.NumeroIdentificacion, updatedClienteFromDb.NumeroIdentificacion);
            Assert.AreEqual(existingCliente.ProfesionOcupacion, updatedClienteFromDb.ProfesionOcupacion);

            // Clean up
            dbContext.Dispose();
        }
        [TestMethod]
        public async Task GetAll_ShouldReturnAllClientesFromDatabase()
        {
            // Arrange
            DataAccess.Context.CustomerDbContext dbContext = DbContextHelper.GetTestDbContext();
            ClienteRepository clienteRepository = new(dbContext);

            Cliente cliente1 = new()
            {
                Id = Guid.NewGuid(),
                Nombre = "John",
                Apellido = "Doe",
                NumeroCuenta = "12345",
                UsuarioCreacion = "12345",
                CorreoElectronico = "correoPrueba",
                EstadoCivilId = 1,
                GeneroId = 1,
                NumeroIdentificacion = "0951535970",
                ProfesionOcupacion = "pruebas",
                Activo = true,

            };

            Cliente cliente2 = new()
            {
                Id = Guid.NewGuid(),
                Nombre = "Jane",
                Apellido = "Smith",
                NumeroCuenta = "54321",
                UsuarioCreacion = "54321",
                CorreoElectronico = "correoPrueba2",
                EstadoCivilId = 2,
                GeneroId = 2,
                NumeroIdentificacion = "1234567890",
                ProfesionOcupacion = "pruebas2",
                Activo = true,
            };

            await Task.WhenAll(clienteRepository.AddAsync(cliente1), clienteRepository.AddAsync(cliente2));
            await clienteRepository.SaveChangesAsync();

            // Act
            List<Cliente> result = clienteRepository.GetAll().ToList();

            // Assert
            Assert.AreEqual(2, result.Count());

            // Clean up
            dbContext.Dispose();
        }

        [TestMethod]
        public async Task GetById_ShouldReturnClienteFromDatabase()
        {
            // Arrange
            DataAccess.Context.CustomerDbContext dbContext = DbContextHelper.GetTestDbContext();
            ClienteRepository clienteRepository = new(dbContext);

            Cliente cliente = new()
            {
                Id = Guid.NewGuid(),
                Nombre = "John",
                Apellido = "Doe",
                NumeroCuenta = "12345",
                UsuarioCreacion = "12345",
                CorreoElectronico = "correoPrueba",
                EstadoCivilId = 1,
                GeneroId = 1,
                NumeroIdentificacion = "0951535970",
                ProfesionOcupacion = "pruebas"
            };

            await clienteRepository.AddAsync(cliente);
            await clienteRepository.SaveChangesAsync();

            // Act
            Cliente? result = clienteRepository.FindAll(cliente.Id);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(cliente.Nombre, result.Nombre);
            Assert.AreEqual(cliente.Apellido, result.Apellido);

            // Clean up
            dbContext.Dispose();
        }

        [TestMethod]
        public async Task Delete_ShouldRemoveClienteFromDatabase()
        {
            // Arrange
            DataAccess.Context.CustomerDbContext dbContext = DbContextHelper.GetTestDbContext();
            ClienteRepository clienteRepository = new(dbContext);

            Cliente cliente = new()
            {
                Id = Guid.NewGuid(),
                Nombre = "John",
                Apellido = "Doe",
                NumeroCuenta = "12345",
                UsuarioCreacion = "12345",
                CorreoElectronico = "correoPrueba",
                EstadoCivilId = 1,
                GeneroId = 1,
                NumeroIdentificacion = "0951535970",
                ProfesionOcupacion = "pruebas"
            };

            await clienteRepository.AddAsync(cliente);
            await clienteRepository.SaveChangesAsync();
            await clienteRepository.DeleteAsync(cliente);
            await clienteRepository.SaveChangesAsync();

            // Assert
            Cliente? deletedCliente = await dbContext.Cliente.FirstOrDefaultAsync(c => c.Id == cliente.Id);
            Assert.IsNull(deletedCliente);

            // Clean up
            dbContext.Dispose();
        }
        [TestMethod]
        public async Task GetAllAsync_ShouldReturnAllEntitiesFromDatabase()
        {
            // Arrange
            DataAccess.Context.CustomerDbContext dbContext = DbContextHelper.GetTestDbContext();
            Mapper mapper = new(new MapperConfiguration(cfg => cfg.AddProfile<ClienteMap>()));
            ClienteRepository clienteRepository = new(dbContext);

            Cliente cliente1 = new()
            {
                Id = Guid.NewGuid(),
                Nombre = "John",
                Apellido = "Doe",
                NumeroCuenta = "12345",
                UsuarioCreacion = "12345",
                CorreoElectronico = "correoPrueba",
                EstadoCivilId = 1,
                GeneroId = 1,
                NumeroIdentificacion = "0951535970",
                ProfesionOcupacion = "pruebas",
                Activo = true,

            };

            Cliente cliente2 = new()
            {
                Id = Guid.NewGuid(),
                Nombre = "Jane",
                Apellido = "Smith",
                NumeroCuenta = "54321",
                UsuarioCreacion = "54321",
                CorreoElectronico = "correoPrueba2",
                EstadoCivilId = 2,
                GeneroId = 2,
                NumeroIdentificacion = "1234567890",
                ProfesionOcupacion = "pruebas2",
                Activo = true,
            };

            await Task.WhenAll(clienteRepository.AddAsync(cliente1), clienteRepository.AddAsync(cliente2));
            await clienteRepository.SaveChangesAsync();
            // Act
            IQueryable<ClienteDto> result = await clienteRepository.GetAllAsync<ClienteDto>(mapper);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Count());

            // Clean up
            dbContext.Dispose();
        }


    }
}
