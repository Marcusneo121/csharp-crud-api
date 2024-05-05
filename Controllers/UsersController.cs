using csharp_crud_api.Data;
using Microsoft.AspNetCore.Mvc;
using csharp_crud_api.Models;
using Microsoft.EntityFrameworkCore;

namespace csharp_crud_api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly UserContext _userContext;

    public UsersController(UserContext userContext)
    {
        _userContext = userContext;
    }

    //GET: api/users
    [HttpGet]
    public async Task<ActionResult<IEnumerable<User>>> GetUsers()
    {
        return await _userContext.Users.ToListAsync();
    }

    //GET: api/users/1
    [HttpGet("{id}")]
    public async Task<ActionResult<IEnumerable<User>>> GetUserByID(int id)
    {
        var user = await _userContext.Users.FindAsync(id);

        if (user == null)
        {
            return NotFound($"Unable to find user with id {id}");
        }

        return Ok(user);
    }

    //POST: api/users
    [HttpPost]
    public async Task<ActionResult<User>> CreateUser(User user)
    {
        _userContext.Users.Add(user);
        await _userContext.SaveChangesAsync();

        return CreatedAtAction(nameof(GetUserByID), new { id = user.Id }, user);
    }

    //PUT: api/users/1
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateUser(int id, User user)
    {
        if (id != user.Id)
        {
            return BadRequest("");
        }

        _userContext.Entry(user).State = EntityState.Modified;
        await _userContext.SaveChangesAsync();

        return NoContent();
    }

    //DELETE: api/users/1
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteUser(int id)
    {
        var user = await _userContext.Users.FindAsync(id);

        if (user == null)
        {
            return NotFound();
        }

        _userContext.Users.Remove(user);
        await _userContext.SaveChangesAsync();

        return NoContent();
    }

    //Dummy Endpoint
    [HttpGet("test")]
    public async Task<IActionResult> Test()
    {
        return Ok("Hello World");
    }
}
