using Microsoft.AspNetCore.Mvc;
using AbsensiApp_Api.Models;
using AbsensiApp_Api.Services;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System;

namespace AbsensiApp_Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    // [Route("v{version:apiVersion}/[controller]")]
    // [ApiVersion("1.0")]
    public class UserController : ControllerBase
    {
        private readonly MyDbContext _myDbContext;

        public UserController(MyDbContext myDbContext)
        {
            _myDbContext = myDbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var users = await _myDbContext.userInfo.ToListAsync();
            Console.WriteLine("usernya: " + users);
            return Ok(users);
        }

        [HttpGet]
        [Route("user/id")]
        public async Task<IActionResult> GetUserByUserId(int id)
        {
            var users = await _myDbContext.userInfo.FindAsync(id);
            Console.WriteLine("usernya: " + users);
            return Ok(users);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync(UserInfo userInfo)
        {
            _myDbContext.userInfo.Add(userInfo);
            await _myDbContext.SaveChangesAsync();
            return Created($"/user/id?id={userInfo.Id}", userInfo);
        }

        [HttpPut]
        public async Task<IActionResult> PutAsync(UserInfo userInfo)
        {
            //get by id dulu
            //jika id null maka tidak keluar opsi untuk update
            _myDbContext.userInfo.Update(userInfo);
            await _myDbContext.SaveChangesAsync();
            return NoContent();
        }
        [Route("{id}")]
        [HttpDelete]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var userToDelete = await _myDbContext.userInfo.FindAsync(id);
            if (userToDelete == null)
            {
                return NotFound();
            }
            _myDbContext.userInfo.Remove(userToDelete);
            //save changes untuk memastikan id yang didelete terupdate
            await _myDbContext.SaveChangesAsync();
            return NoContent();
        }
    }
}