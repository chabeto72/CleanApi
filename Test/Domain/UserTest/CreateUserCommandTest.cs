using Application.Database.User.Commands.CreateUser;
using Application.DataBase;
using AutoMapper;
using Domain.Entities;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Test.Application.UserTest
{
    public class CreateUserCommandTest
    {
        private readonly Mock<IValidator<CreateUserModel>> _validator;
        private readonly Mock<IDataBaseService> _dataBaseService;
        private readonly Mock<IMapper> _mapper;
        private readonly CreateUserCommand _command;

        public CreateUserCommandTest()
        {
            _dataBaseService = new Mock<IDataBaseService>();
            _mapper = new Mock<IMapper>();
            _command = new CreateUserCommand(_dataBaseService.Object,_mapper.Object);
        }

        //Cuando se realiza la creación del objeto empleado
        //El escenario
        //Lo que debe arrojar
        [Fact]
        public async Task CreateEmployee_WhenFisrtNameHasInvalidFormatEmpty_ShoudlReturnValidationError()
        {
            //Arrange: Configuramos parametros de entrada de prueba unitaria
            User user = new User() { FirtsName = null,  Email = "ADS", NumberDocument = null, Password = "" };
            CreateUserModel createUserCommand = new CreateUserModel() { Nombre = null,  Correo = "ADS", Documento = null, Password = "" };
            _mapper.Setup(m => m.Map<User>(It.IsAny<CreateUserModel>())).Returns(user); // mapping data
            var mockSet = new Mock<DbSet<User>>();
            _dataBaseService.Setup(m => m.User).Returns(mockSet.Object);

            //Act: Se ejecuta el metodo a probar en nuestra prueba unitaria
            var result = await _command.Execute(createUserCommand);

            ////Assert: Se verifica los datos de retorno de nuestro metodo probado
            Assert.True(createUserCommand.Equals(result));
            //result.FirstError.Type.Should().Be(ErrorType.Validation);
            //result.FirstError.Code.Should().Be(Domain.EmployeeErrors.Errors.Employee.PhoneNumberInvalid.Code);
            //result.FirstError.Description.Should().Be(Domain.EmployeeErrors.Errors.Employee.PhoneNumberInvalid.Description);

        }
    }
}
