using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Proyecto.Data;
using Proyecto.DTOs;
using Proyecto.Models;
using System.Data;

namespace Proyecto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CasaController: ControllerBase
    {



        private readonly HoteleriaContext context;
        private readonly IMapper mapper;

        public CasaController(HoteleriaContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }




        [HttpGet]
        [ProducesResponseType(typeof(PersonaDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseError), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ResponseError), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<List<CasaDTO>>> Get()
        {
            var casa = await context.Casas
                //.Include(x => x.AlquilerCasas)
                .ToListAsync();

            var casaDTO = mapper.Map<List<CasaDTO>>(casa);

            return Ok(casaDTO);
        }



        [HttpPost]
        [ProducesResponseType(typeof(PersonaDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseError), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Post([FromBody] InsertarCasaDTO InsertarCasaDTO)
        {
            try
            {
                var Insertar = mapper.Map<Casa>(InsertarCasaDTO);
                Insertar.Estadocasa = "Libre";
                Insertar.StatusFl = "1";

                await context.Casas.AddAsync(Insertar);
                await context.SaveChangesAsync();
                return Ok("DATOS ENVIADOS CON EXITO");
            }
            catch (Exception ex)
            {
                return new ResponseError(StatusCodes.Status400BadRequest, ex.Message).GetObjectResult();
            }
        }

        [HttpPut("{id:int}")]
        // [Authorize(Roles = "ADM")]
        [ProducesResponseType(typeof(CasaDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseError), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ResponseError), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Put(int id, [FromBody] ActualizarCasaDTO actualizarDTO)
        {
            try
            {
                var casa = await context.Casas.FindAsync(id);

                if (casa == null)
                {
                    return new ResponseError(StatusCodes.Status404NotFound, "El recurso no existe").GetObjectResult();
                }



                casa = mapper.Map(actualizarDTO, casa);
                casa.Estadocasa = actualizarDTO.Estadocasa;
                casa.StatusFl = actualizarDTO.StatusFl;

                // context.Entry(autor).State = EntityState.Modified;
                await context.SaveChangesAsync();


                //return NoContent();
                return Ok("DATOS ACTUALIZADOS CON EXITO");


            }
            catch (Exception ex)
            {

                return new ResponseError(StatusCodes.Status400BadRequest, ex.Message).GetObjectResult();
            }




        }

        [HttpDelete("{id:int}")]
        [ProducesResponseType(typeof(PersonaDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseError), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                context.Casas.Remove(new Casa() { Id = id });
                await context.SaveChangesAsync();
                return NoContent();

            }
            catch (Exception ex)
            {
                return new ResponseError(StatusCodes.Status400BadRequest, ex.Message).GetObjectResult();
            }
        }
    }
}
