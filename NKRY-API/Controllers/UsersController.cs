using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NKRY_API.DataAccess.EFCore;
using NKRY_API.Domain.Contracts;
using NKRY_API.Domain.Entities;

namespace NKRY_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUnitOfWork _uniftOfWork;

        public UsersController(IUnitOfWork unitOfWork)
        {
            _uniftOfWork = unitOfWork;
        }

        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> Getusers()
        {
          if (_uniftOfWork.User == null)
          {
              return NotFound();
          }
            var allUsers = _uniftOfWork.User.GetAll();
            return Ok(allUsers);
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
          if (_uniftOfWork.User == null)
          {
              return NotFound();
          }
            var user = _uniftOfWork.User.GetById(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        // PUT: api/Users/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(int id, User user)
        {
            if (id != user.Id)
            {
                return BadRequest();
            }

            _uniftOfWork.User.Update(user);

            try
            {
                _uniftOfWork.Complete();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Users
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<User>> PostUser(User user)
        {
          if (_uniftOfWork.User == null)
          {
              return Problem("Entity set 'ApplicationContext.Users'  is null.");
          }
            _uniftOfWork.User.Create(user);
            _uniftOfWork.Complete();

            return CreatedAtAction("GetUser", new { id = user.Id }, user);
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            if (_uniftOfWork.User == null)
            {
                return NotFound();
            }
            var user = _uniftOfWork.User.GetById(id);
            if (user == null)
            {
                return NotFound();
            }

            _uniftOfWork.User.Delete(user);
            _uniftOfWork.Complete();

            return NoContent();
        }

        private bool UserExists(int id)
        {
            return (_uniftOfWork.User.GetAll()?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
