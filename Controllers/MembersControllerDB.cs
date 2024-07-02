using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GymApi.Data;
using GymApi.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GYMAPI.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class MembersControllerDB : ControllerBase
    {

        private readonly DataContext _context;
        public MembersControllerDB(DataContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSingle(int id)
        {
            try
            {
                Members p = await _context.TB_MEMBERS.FirstOrDefaultAsync(pBusca => pBusca.Id == id);

                return Ok(p);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> Get()
        {
            try
            {
                List<Members> lista = await _context.TB_MEMBERS.ToListAsync();
                return Ok(lista);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Add(Members novoMembers)
        {
            try
            {
                if (novoMembers.Nivelconta > 3)
                {
                    throw new Exception("Nivel de conta não pode ser maior que 3");
                }
                await _context.TB_MEMBERS.AddAsync(novoMembers);
                await _context.SaveChangesAsync();

                return Ok(novoMembers.Id);
            }

            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }

/*
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            Members pRemover = await _context.TB_MEMBERS.FirstOrDefault(p => p.id == id);

            _context.TB_MEMBERS.Remove(pRemover);
            int linhaAfetadas = await _context.SaveChangesAsync();
            
            return Ok(linhaAfetadas);
        }
        catch (System.Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
*/


}
