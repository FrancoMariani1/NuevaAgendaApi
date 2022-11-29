using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NuevaAgendaApi.Data.Interfaces;
using NuevaAgendaApi.Data.Repository.Implementations;
using NuevaAgendaApi.Dto;
using NuevaAgendaApi.Entities;
using System.Text.Json;

namespace NuevaAgendaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        private IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public UserController( IUserRepository userRepository)
        {
            _userRepository = userRepository;

        }




        //public static List<User> FakeUsers = new List<User>()
        //{
        //    new User()
        //    {
        //        Email = "asdas@hotmail.com",
        //        Name = "Pepe",
        //        Password = "passwordsegura",
        //        Id = 1,
        //    },

        //    new User()
        //    {
        //        Email = "lkjb@hotmail.com",
        //        Name = "Andres",
        //        Password = "passwordsegura1",
        //        Id = 2,
        //    }
        //};

        //public List<User> users = new List<User>()
        //{
        //    new User(){Name = "Enrique", Id = 23456},
        //    new User(){Name = "Juan", Id = 12345}
        //};

        //[HttpGet]
        //[Route("GetOne/{Id}")]

        //public ActionResult GetOneById(int Id)
        //{

        //    return Ok(FakeUsers.Where(x =>x.Id == Id).ToList());
        //}

        //[HttpGet]
        //[Route("GetOne/{Id}")]
        //public IActionResult GetOneById(int Id)
        //{
        //    List<User> usersToReturn = _userRepository.GetAllUsers();
        //    usersToReturn.Where(x => x.Id == Id).ToList();
        //    if (usersToReturn.Count > 0)
        //        return Ok(usersToReturn);
        //    return NotFound("Usuario inexistente");
        //}


        [HttpGet]
        public IActionResult GetAll()
        {
            //public UserRepository us = new UserRepository();
            return Ok(_userRepository.GetAll());
        }


        [HttpGet]
        [Route("{Id}")]

        public IActionResult GetOneById(int Id)
        {
            var user = _userRepository.GetById(Id);

        
            var dto = _mapper.Map<GetUserByIdResponse>(user);
            try
            {
                return Ok(dto);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);   
            }
            //return Ok();
        }
        

        [HttpPost]
        public IActionResult CreateUser(CreateAndUpdateUserDTO userDTO)
        {
            try
            {
                _userRepository.Create(userDTO);
                
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
            return Created("Created", userDTO);
        }

        [HttpPut]

        public IActionResult UpdateUser(CreateAndUpdateUserDTO userDTO)
        {
            try
            {
                _userRepository.Update(userDTO);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
            return NoContent();
        }
       

        [HttpDelete]
        [Route("{Id}")]
        public IActionResult DeleteUser(int Id)
        {
            try
            {
                _userRepository.Delete(Id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
            return Ok();
        }

        [HttpDelete]

        public IActionResult Delete(int Id)
        {
            try
            {
                if (_userRepository.GetById(Id).Name == "Admin")
                {
                    _userRepository.Delete(Id);
                }
                else
                {
                    _userRepository.Archive(Id);
                }
                return StatusCode(204);
            }
            catch(Exception ex)
            {
                return BadRequest(ex);
            }
            //return Ok();
        }

    }
}
