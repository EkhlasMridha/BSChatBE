using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataManager.Contracts;
using Models.DTO;
using TokenService.Contracts;
using System.Security.Claims;
using BSChat.Constants;
using TokenService;
using AutoMapper;
using Models.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BSChat.Controllers
{
    [Route("v1/[controller]")]
    [ApiController]
    public class IdentityController : ControllerBase
    {
        private IAuthDataManager _authDataManager;
        private ITokenGenerator _tokenGenerator;
        private IJwtSecrets _jwtSecrets;
        private IMapper _mapper;

        public IdentityController(IAuthDataManager authDataManager, ITokenGenerator tokenGenerator, IJwtSecrets jwtSecrets,IMapper mapper)
        {
            _authDataManager = authDataManager;
            _tokenGenerator = tokenGenerator;
            _jwtSecrets = jwtSecrets;
            _mapper = mapper;
        }

        // POST api/<IdentityController>
        [HttpPost("signin")]
        public async Task<IActionResult> Signin([FromBody] SignInModel signInModel)
        {
            var result = await _authDataManager.SignIn(signInModel.Mail);
            if (result == null)
            {
                return Unauthorized("Incorect credential");
            }

            var claims = new Claim[]
            {
                new Claim(BSConstants.UserId,result.Id.ToString()),
            };

            var jwt = await _tokenGenerator.GenerateJwtToken(claims, _jwtSecrets.TokenSecrete, DateTime.Now.AddDays(2));

            var token = new TokenModel
            {
                Token = jwt
             };
            return Ok(token);
        }

        [HttpPost("signup")]
        public async Task<IActionResult> SignUp([FromBody] PersonDto personDto)
        {
            if (personDto == null)
            {
                return BadRequest("Invalid parameter");
            }
            var person = _mapper.Map<Person>(personDto);
            await _authDataManager.SignUp(person);
            return Ok();
        }
    }
}
