using Application.Database.User.Commands.CreateUser;
using FluentValidation;
using Moq;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Model;

namespace Test.Application
{
    public class CreateUserValidationTest
    {
        private readonly Mock<IValidator<CreateUserModel>> _validator;
        public CreateUserValidationTest()
        {
            _validator = new Mock<IValidator<CreateUserModel>>();
        }
        //Cuando se realiza la creación del objeto empleado
        //El escenario
        //Lo que debe arrojar
        [Fact]
        public async Task Should_Have_Error_When_Id_Is_Empty()
        {
            //Arrange: Configuramos parametros de entrada de prueba unitaria
            //UserEntity user = new UserEntity() { FirtsName = null, LastName = "Bejarano", Code = "ADS", NumberDocument = null, Password = "" };
            CreateUserModel createUserCommand = new CreateUserModel() { FirtsName = null, LastName = "Bejarano", Code = "ADS", NumberDocument = null, Password = "" };
            //_mapper.Setup(m => m.Map<UserEntity>(It.IsAny<CreateUserModel>())).Returns(user); // mapping data
            //var mockSet = new Mock<DbSet<UserEntity>>();
            //_dataBaseService.Setup(m => m.User).Returns(mockSet.Object);

            //Act: Se ejecuta el metodo a probar en nuestra prueba unitaria
            //_validator.Setup(m => m.Validate(It.IsAny<CreateUserModel>())).Returns();

            ////Assert: Se verifica los datos de retorno de nuestro metodo probado
            //Assert.True(createUserCommand.Equals(result));
            //result.FirstError.Type.Should().Be(ErrorType.Validation);
            //result.FirstError.Code.Should().Be(Domain.EmployeeErrors.Errors.Employee.PhoneNumberInvalid.Code);
            //result.FirstError.Description.Should().Be(Domain.EmployeeErrors.Errors.Employee.PhoneNumberInvalid.Description);

        }
    }
}
