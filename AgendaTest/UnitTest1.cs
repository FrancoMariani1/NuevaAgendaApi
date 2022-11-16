//using Microsoft.AspNetCore.Mvc;
//using Microsoft.Extensions.Configuration;
//using NuevaAgendaApi.Controllers;
//using NuevaAgendaApi.Data.Repository.Implementations;
//using NuevaAgendaApi.Dto;

//namespace AgendaTest
//{
//    public class TestAuthenticationController
    

//        [Fact]
//        public void AutenticarConUsuarioFalso()
//        {
           
//            AuthenticationController authcontroller = new AuthenticationController(_userRepository, _config);
//            AuthenticationRequestBody body = new AuthenticationRequestBody
//            {
//                Password = "password",
//                UserName = "pepito"
//            };

//            var response = authcontroller.Autenticar(body);

//            Assert.IsType<UnauthorizedObjectResult>(response);
//        }

//    }
//}