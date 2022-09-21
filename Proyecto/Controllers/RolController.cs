using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Proyecto.Data;
using Proyecto.DTOs;
using Proyecto.Models;

namespace Proyecto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolController : ControllerBase
    {
        private readonly HoteleriaContext context;
        private readonly IMapper mapper;

        public RolController(HoteleriaContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }


        [HttpGet]

        public async Task<ActionResult<List<RolDTO>>> Get()
        {
            var Rol = await context.Rols
                //.Include(x => x.AlquilerCasas)
                .ToListAsync();

            var RolDTO = mapper.Map<List<RolDTO>>(Rol);

            return Ok(RolDTO);
        }

        [HttpPost]
        [ProducesResponseType(typeof(RolDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseError), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Post([FromBody] insertarRolDTO insertarRolDTO)
        {
            try
            {
                var Insertar = mapper.Map<Rol>(insertarRolDTO);

                await context.Rols.AddAsync(Insertar);
                await context.SaveChangesAsync();

                var dtoLectura = mapper.Map<RolDTO>(Insertar);
                return new CreatedAtRouteResult("getRol", new { id = Insertar.Id }, dtoLectura);

               // return Ok("DATOS ENVIADOS CON EXITO");
            }
            catch (Exception ex)
            {
                return new ResponseError(StatusCodes.Status400BadRequest, ex.Message).GetObjectResult();
            }
        }


        [HttpPut("{id:int}")]
        // [Authorize(Roles = "ADM")]
        [ProducesResponseType(typeof(RolDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseError), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ResponseError), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Put(int id, [FromBody] insertarRolDTO actualizarDTO)
        {
            try
            {
                var rol = await context.Rols.FindAsync(id);

                if (rol == null)
                {
                    return new ResponseError(StatusCodes.Status404NotFound, "El recurso no existe").GetObjectResult();
                }



                rol = mapper.Map(actualizarDTO, rol);


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

        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                context.Rols.Remove(new Rol() { Id = id });
                await context.SaveChangesAsync();
                return NoContent();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet("{id:int}", Name = "getRol")]
        [ProducesResponseType(typeof(RolDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseError), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ResponseError), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<List<RolDTO>>> Get(int id)
        {
            try
            {
                var persona = await context.Rols.FindAsync(id);
            

                if (persona == null)
                {
                    return new ResponseError(StatusCodes.Status404NotFound, "El recurso no existe").GetObjectResult();

                }

              
                var rolDTO = mapper.Map<RolDTO>(persona);
                return Ok(rolDTO);
            }
            catch (Exception ex)
            {

                return new ResponseError(StatusCodes.Status400BadRequest, ex.Message).GetObjectResult();
            }

        }

    }
}
