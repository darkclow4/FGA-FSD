﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web_API.Contexts;
using Web_API.Models;

namespace Web_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UniversitiesEFController : ControllerBase
    {
        private readonly SQLServerContext _context;

        public UniversitiesEFController(SQLServerContext context)
        {
            _context = context;
        }

        // GET: api/UniversitiesEF
        [HttpGet]
        public async Task<ActionResult<IEnumerable<University>>> GetUniversities()
        {
          if (_context.Universities == null)
          {
              return NotFound();
          }
            return await _context.Universities.ToListAsync();
        }

        // GET: api/UniversitiesEF/5
        [HttpGet("{id}")]
        public async Task<ActionResult<University>> GetUniversity(int id)
        {
          if (_context.Universities == null)
          {
              return NotFound();
          }
            var university = await _context.Universities.FindAsync(id);

            if (university == null)
            {
                return NotFound();
            }

            return university;
        }

        // PUT: api/UniversitiesEF/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUniversity(int id, University university)
        {
            if (id != university.Id)
            {
                return BadRequest();
            }

            _context.Entry(university).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UniversityExists(id))
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

        // POST: api/UniversitiesEF
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<University>> PostUniversity(University university)
        {
          if (_context.Universities == null)
          {
              return Problem("Entity set 'SQLServerContext.Universities'  is null.");
          }
            _context.Universities.Add(university);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUniversity", new { id = university.Id }, university);
        }

        // DELETE: api/UniversitiesEF/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUniversity(int id)
        {
            if (_context.Universities == null)
            {
                return NotFound();
            }
            var university = await _context.Universities.FindAsync(id);
            if (university == null)
            {
                return NotFound();
            }

            _context.Universities.Remove(university);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UniversityExists(int id)
        {
            return (_context.Universities?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
