using Microsoft.AspNetCore.Mvc;
using Backend.BO.Commons;
using Backend.BLL.Features.Users;
using Backend.BO.Payloads.Requests;
using System.Net;

namespace Backend.API.Controllers.v1
{
    public class UsersController : BaseApiController
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        // GET: api/Users
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        //{
        //    return await _context.Users.ToListAsync();
        //}

        // GET: api/Users/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<User>> GetUser(Guid id)
        //{
        //    var user = await _context.Users.FindAsync(id);

        //    if (user == null)
        //    {
        //        return NotFound();
        //    }

        //    return user;
        //}

        // PUT: api/Users/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutUser(Guid id, User user)
        //{
        //    if (id != user.Id)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(user).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!UserExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        
        [HttpPost("sign-up/customer")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesErrorResponseType(typeof(ResponseModel<string>))]
        public async Task<ActionResult<User>> SignupForCustomer(CustomerSignupRequest customer)
        {
            var result = await _userService.SignupForCustomer(customer);
            if (result)
            {
                var response = new ResponseModel<string>(
                    statusCode: (int)HttpStatusCode.OK,
                    message: "Register successfully!",
                    response: null
                );
                return Ok(response);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPost("sign-up/clinic-owner")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesErrorResponseType(typeof(ResponseModel<string>))]
        public async Task<ActionResult<User>> SignupForClinicOwner(ClinicOwnerSignupRequest clinicOwner)
        {
            var result = await _userService.SignupForClinicOwner(clinicOwner);
            if (result)
            {
                var response = new ResponseModel<string>(
                    statusCode: (int)HttpStatusCode.OK,
                    message: "Register successfully!",
                    response: null
                );
                return Ok(response);
            }
            else
            {
                return BadRequest();
            }
        }

        // DELETE: api/Users/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteUser(Guid id)
        //{
        //    var user = await _context.Users.FindAsync(id);
        //    if (user == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Users.Remove(user);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}

        //private bool UserExists(Guid id)
        //{
        //    return _context.Users.Any(e => e.Id == id);
        //}
    }
}
