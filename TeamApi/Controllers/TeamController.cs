using AutoMapper;
using Azure;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TeamApi.Data;
using TeamApi.Data.Dtos;
using TeamApi.Models;
using TeamApi.Profiles;

namespace TeamApi.Controllers;

[ApiController]
[Route("[controller]")]
public class TeamController : ControllerBase
{
    private readonly TeamDbContext _context;
    private readonly IMapper _mapper;

    public TeamController(TeamDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }


    [HttpGet]
    public async Task<IActionResult> Get(int skip = 0, int take = 10)
    {
        try
        {
            var teams = await _context.Teams.ToListAsync();
            var teamsDto = _mapper.Map<List<ReadTeamDtos>>(teams);
            return Ok(teamsDto);
        }
        catch(Exception)
        {
            return StatusCode(500,"Ocorreu um erro inesperado. Tente novamente mais tarde");
        }
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetId(int id)
    {
        try
        {
            var team = await _context.Teams.FirstOrDefaultAsync(x => x.Id == id);
            if (team == null) return NotFound("Time não encontrado");
            var teamsDto = _mapper.Map<ReadTeamDtos>(team);

            return Ok(teamsDto);
        }catch(Exception)
        {
            return StatusCode(500,"Ocorreu um erro inesperado. Tente novamente mais tarde");
        }

    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CreateDto teamsDto)
    {
        try
        {
            var team = _mapper.Map<Team>(teamsDto);
            if (!ModelState.IsValid) return BadRequest(ModelState);
            await _context.Teams.AddAsync(team);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetId), new { id = team.Id }, team);
        }catch(Exception)
        {
            return StatusCode(500,"Ocorreu um erro inesperado. Tente novamente mais tarde");
        }
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] UpdateDto teamDto)
    {
        try
        {
            var team = await _context.Teams.FirstOrDefaultAsync(x => x.Id == id);
            if (team == null) return NotFound("Time não encontrado");

            var teamUpdate = _mapper.Map(teamDto, team);
            await _context.SaveChangesAsync();
            await _context.SaveChangesAsync();
            return NoContent();
        }
        catch(Exception)
        {
            return StatusCode(500,"Ocorreu um erro inesperado. Tente novamente mais tarde");
        }
    }
    [HttpPatch("{id}")]
    public async Task<IActionResult> Patch(int id, [FromBody] JsonPatchDocument<UpdateDto> teamDto)
    {
        try
        {
            var team = await _context.Teams.FirstOrDefaultAsync(x => x.Id == id);
            if (team == null) return NotFound("Time não encontrado");

            var teamUpdate = _mapper.Map<UpdateDto>(team);
            teamDto.ApplyTo(teamUpdate, ModelState);

            if (!ModelState.IsValid) return BadRequest(ModelState);
            _mapper.Map(teamUpdate, team);
            await _context.SaveChangesAsync();
            await _context.SaveChangesAsync();
            return NoContent();
        }
        catch (Exception)
        {
            return StatusCode(500, "Ocorreu um erro inesperado. Tente novamente mais tarde");
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            var team = await _context.Teams.FirstOrDefaultAsync(x => x.Id == id);  
            if(team == null) return NotFound("Time não encontrado"); 
             _context.Teams.Remove(team);
            await _context.SaveChangesAsync();
            return NoContent();

        }catch(Exception)
        {
            return StatusCode(500,"Ocorreu um erro inesperado. Tente novamente mais tarde");
        }
    }



}
