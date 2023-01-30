using MGApiRest.DTO;
using MGApiRest.Entities;
using MGApiRest.Services.Repositories.Clients;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TestMGTestProject.Services
{
    class ClientsRepositoryTest
    {
        private Mgcliente mgcliente;
        private MGClienteDTO mgclientedto;
        [SetUp]
        public void Setup()
        {
            mgcliente = new Mgcliente()
            {
                CliIdentificacion = "22222",
                CliNombreCompleto = "Prueba Unit Test",
                CliDireccion = "Calle 4 4-4",
                CliTelefono = "3018907654",
                CliContactoId = 1,
                CliFechaCreacion = Convert.ToDateTime("2023/01/29"),
            };
            mgclientedto = new MGClienteDTO()
            {
                CliIdentificacion = "22222",
                CliNombreCompleto = "Prueba Unit Test",
                CliDireccion = "Calle 4 4-4",
                CliTelefono = "3018907654",
                CliContactoId = 1,
                CliFechaCreacion = Convert.ToDateTime("2023/01/29"),
            };
            
        }
        private IServiceProvider createContext(string nameBD)
        {
            var services = new ServiceCollection();
            services.AddDbContext<MentumGroupContext>(options =>
            options.UseInMemoryDatabase(databaseName: nameBD),
            ServiceLifetime.Scoped,
                ServiceLifetime.Scoped);
            return services.BuildServiceProvider();
        }

        [Test]
        public async Task createClientsTest()
        {
            //Arrange
            var nameDB = Guid.NewGuid().ToString();
            var serviceProvider = createContext(nameDB);
            var db = serviceProvider.GetService<MentumGroupContext>();
            db.Add(mgcliente);

            //Act

            //throw new Exception("Ok");

            ClientsRepository services = new ClientsRepository(db);
            var responseService = await services.CreateClientAsync(mgclientedto);
            //Assert

            Assert.AreEqual(responseService,"Ok");

            
        }
    }
}

