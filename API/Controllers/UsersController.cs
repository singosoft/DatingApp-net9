using API.Data;
using API.DTOs;
using API.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;


public class UsersController(IUserRepository userRepository , IMapper mapper) : BaseApiController
{
    [AllowAnonymous]
    [HttpGet]
    public async Task<ActionResult<IEnumerable<MemberDto>>> GetUsers()
    {
        var users = await userRepository.GetUsersAsync();
        if(users == null) return NotFound();
        var usersToReturn = mapper.Map<IEnumerable<MemberDto>>(users);
        return Ok(usersToReturn);
    }

//    // [Authorize]
//     [HttpGet("{id:int}")] //api/users/id
//     public async Task<ActionResult<AppUser>> GetUserId(int id)
//     {
//         var user = await userRepository.GetUserByIdAsync(id);
//         if (user == null) return NotFound();
//         return user;
//     }

     [HttpGet("{username}")]
     public async Task<ActionResult<MemberDto>> GetUser(string username) {
         var user = await userRepository.GetUserByUsernameAsync(username);
         if(user == null) return NotFound();
         return mapper.Map<MemberDto>(user);
        
    }
}
