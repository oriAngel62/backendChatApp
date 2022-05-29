using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
//using API.Data;
using Domain;
using API.Data;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class usersController : Controller
    {
        private readonly PomeloDB _context;
        private readonly IConfiguration conf;
        public usersController(PomeloDB context, IConfiguration conf)
        {
            _context = context;
            this.conf = conf;
        }

        [HttpGet]
        [Route("/api/users")]
        public async Task<ActionResult> Index()
        {
            //return just the name without other field
            return Json(_context.User);
        }

        [HttpPost]
        [Route("/api/users/signin")]
        public async Task<ActionResult> SignIn([FromBody] SignInRequest request)
        {
            var usersList = await _context.User.Where(user => user.UserName == request.UserId).ToListAsync();
            var user = usersList.FirstOrDefault();
            if (user == null) return NotFound();
            if (request.Password != user.Password) return NotFound();

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, conf["JWT:Subject"]),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                new Claim("UserId", request.UserId),
            };
            var symKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(conf["JWT:Key"]));
            var signInCreds = new SigningCredentials(symKey, SecurityAlgorithms.HmacSha256);
            var jwtSecurityToken = new JwtSecurityToken(
                conf["JWT:Issuer"],
                conf["JWT:Audience"],
                claims,
                expires: DateTime.UtcNow.AddDays(2),
                signingCredentials: signInCreds);
            var jwtToken = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
 
            return Ok(jwtToken.Replace("\"", ""));

        }

        [HttpPost]
        [Route("/api/users")]
        public async Task<ActionResult> AddNewUser([Bind("Id, NickName, Password, Server")] User user)
        {
            _context.User.Add(user);
            await _context.SaveChangesAsync();
            //return just the name without other field
            return Json(_context.User);
        }


        //// GET: Users
        //public async Task<IActionResult> Index()
        //{
        //      return _context.UserDetails != null ? 
        //                  View(await _context.UserDetails.ToListAsync()) :
        //                  Problem("Entity set 'PomeloDB.UserDetails'  is null.");
        //}

        //// GET: Users/Details/5
        //public async Task<IActionResult> Details(string id)
        //{
        //    if (id == null || _context.UserDetails == null)
        //    {
        //        return NotFound();
        //    }

        //    var user = await _context.UserDetails
        //        .FirstOrDefaultAsync(m => m.UserName == id);
        //    if (user == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(user);
        //}

        //// GET: Users/Create
        //public IActionResult Create()
        //{
        //    return View();
        //}

        //// POST: Users/Create
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("UserName,NickName,Password,Server")] User user)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(user);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(user);
        //}

        //// GET: Users/Edit/5
        //public async Task<IActionResult> Edit(string id)
        //{
        //    if (id == null || _context.UserDetails == null)
        //    {
        //        return NotFound();
        //    }

        //    var user = await _context.UserDetails.FindAsync(id);
        //    if (user == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(user);
        //}

        //// POST: Users/Edit/5
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(string id, [Bind("UserName,NickName,Password,Server")] User user)
        //{
        //    if (id != user.UserName)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(user);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!UserExists(user.UserName))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(user);
        //}

        //// GET: Users/Delete/5
        //public async Task<IActionResult> Delete(string id)
        //{
        //    if (id == null || _context.UserDetails == null)
        //    {
        //        return NotFound();
        //    }

        //    var user = await _context.UserDetails
        //        .FirstOrDefaultAsync(m => m.UserName == id);
        //    if (user == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(user);
        //}

        //// POST: Users/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(string id)
        //{
        //    if (_context.UserDetails == null)
        //    {
        //        return Problem("Entity set 'PomeloDB.UserDetails'  is null.");
        //    }
        //    var user = await _context.UserDetails.FindAsync(id);
        //    if (user != null)
        //    {
        //        _context.UserDetails.Remove(user);
        //    }

        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //private bool UserExists(string id)
        //{
        //  return (_context.User?.Any(e => e.UserName == id)).GetValueOrDefault();
        //}
    }
}
