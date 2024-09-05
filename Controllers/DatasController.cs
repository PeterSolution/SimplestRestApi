using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestProject.FileDbContent;
using TestProject.Models;

namespace TestProject.Controllers
{
    [Route("api/Datas")]
    [ApiController]
    public class DatasController : ControllerBase
    {
        private readonly MyDbContent _context;

        public DatasController(MyDbContent context)
        {
            _context = context;
        }

        // GET: api/Datas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DbModelData>>> GetdbModelDatas()
        {
            return await _context.dbModelDatas.ToListAsync();
        }

        // GET: api/Datas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DbModelData>> GetDbModelData(int id)
        {
            var dbModelData = await _context.dbModelDatas.FindAsync(id);

            if (dbModelData == null)
            {
                return NotFound();
            }

            return dbModelData;
        }

        // PUT: api/Datas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDbModelData(int id, DbModelData dbModelData)
        {
            if (id != dbModelData.id)
            {
                return BadRequest();
            }

            _context.Entry(dbModelData).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DbModelDataExists(id))
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

        // POST: api/Datas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DbModelData>> PostDbModelData(DbModelData dbModelData)
        {
            _context.dbModelDatas.Add(dbModelData);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDbModelData", new { id = dbModelData.id }, dbModelData);
        }

        // DELETE: api/Datas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDbModelData(int id)
        {
            var dbModelData = await _context.dbModelDatas.FindAsync(id);
            if (dbModelData == null)
            {
                return NotFound();
            }

            _context.dbModelDatas.Remove(dbModelData);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DbModelDataExists(int id)
        {
            return _context.dbModelDatas.Any(e => e.id == id);
        }
    }
}
