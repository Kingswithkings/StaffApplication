using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StaffApplication.DataLayer;
using StaffApplication.DTOs;
using StaffApplication.Models;
using System.Collections.Generic;
using System.Linq;

namespace StaffApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StaffController : ControllerBase
    {
        private readonly StaffDbContext _dbContext;

        public StaffController(StaffDbContext context)
        {
            _dbContext = context;
        }

        private static List<Staff> _stafflist = new List<Staff>
        {
            new Staff { StaffId = 1, FirstName = "Kings", LastName = "Idogu", Email = "kingsuthanaidogu@gmail.com", PhoneNumber = "08165418019" },
            new Staff { StaffId = 2, FirstName = "Jane", LastName = "Smith", Email = "janesmith@gmail.com", PhoneNumber = "09036314700"}
        };

        [HttpGet]
        public ActionResult Get()
        {
            return Ok(_stafflist);
        }

        [HttpGet("{id}")]
        public ActionResult GetById(int id)
        {
            var staff = _stafflist.FirstOrDefault(s => s.StaffId == id);
            if (staff == null)
                return NotFound();
            return Ok(staff);
        }

        [HttpGet("ByPhoneNumber/{PhoneNumber}")]
        public ActionResult GetByPhoneNumber(string PhoneNumber)
        {
            var staff = _stafflist.FirstOrDefault(s => s.PhoneNumber == PhoneNumber);
            if (staff == null)
                return NotFound();
            return Ok(staff);
        }

        [HttpGet("ByEmail/{Email}")]
        public ActionResult GetByEmail(string Email)
        {
            var staff = _stafflist.FirstOrDefault(s => s.Email == Email);
            if (staff == null)
                return NotFound();
            return Ok(staff);
        }

        [HttpPost]
        public IActionResult Post([FromBody] StaffRegistrationDto newStaff)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // You can add the new staff to the context and save changes to the database
            Staff staff = new Staff()
            {
                PhoneNumber = newStaff.PhoneNumber,
                Email = newStaff.Email,
                FirstName = newStaff.FirstName,
                LastName = newStaff.LastName,
            };
            _dbContext.Staff.Add(staff);
            _dbContext.SaveChanges();

            // Return a 201 Created response with the new staff data
            return CreatedAtAction(nameof(GetById), new { id = staff.StaffId }, newStaff);
        }
    }
}
