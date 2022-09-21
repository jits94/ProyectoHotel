using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Proyecto.Data;
using Proyecto.DTOs;
using Proyecto.Models;
using System.Linq.Expressions;

namespace Proyecto.Controllers
{


    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class PersonaController: ControllerBase
    {


        private readonly HoteleriaContext context;
        private readonly IMapper mapper;

        public PersonaController(HoteleriaContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }


     

        [HttpGet]
        [ProducesResponseType(typeof(PersonaDTO), StatusCodes.Status200OK)]     
        [ProducesResponseType(typeof(ResponseError), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<List<PersonaDTO>>> Get()
        {
            try
            {
                var Persona = await context.Personas             
               .ToListAsync();        

                var PersonaDTO = mapper.Map<List<PersonaDTO>>(Persona);

                return Ok(PersonaDTO);
            }
            catch (Exception ex)
            {
                return new ResponseError(StatusCodes.Status400BadRequest, ex.Message).GetObjectResult();
            }
           
        }




        [HttpPost]
        [ProducesResponseType(typeof(PersonaDTO), StatusCodes.Status200OK)]      
        [ProducesResponseType(typeof(ResponseError), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Post([FromBody] InsertarPersonaDTO InsertarPersonaDTO)
        {
            try
            {
                var Insertar = mapper.Map<Persona>(InsertarPersonaDTO);
                
                await context.Personas.AddAsync(Insertar);
                await context.SaveChangesAsync();

                var dtoLectura = mapper.Map<PersonaDTO>(Insertar);
                return new CreatedAtRouteResult("getPersona", new { id = Insertar.Id }, dtoLectura);

                //return Ok("DATOS ENVIADOS CON EXITO");
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
        public async Task<ActionResult> Put(int id, [FromBody] InsertarPersonaDTO actualizarDTO)
        {
            try
            {
                var persona = await context.Personas.FindAsync(id);

                if (persona == null)
                {
                    return new ResponseError(StatusCodes.Status404NotFound, "El recurso no existe").GetObjectResult();
                }



                persona = mapper.Map(actualizarDTO, persona);


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
        [ProducesResponseType(typeof(ResponseError), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ResponseError), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                context.Personas.Remove(new Persona() { Id = id });
                await context.SaveChangesAsync();
                return NoContent();

            }
            catch (Exception ex)
            {
                return new ResponseError(StatusCodes.Status400BadRequest, ex.Message).GetObjectResult();
            }
        }




        [HttpGet("{id:int}", Name = "getPersona")]
        [ProducesResponseType(typeof(PersonaDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseError), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ResponseError), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<List<PersonaDTO>>> Get(int id)
        {
            try
            {
                var persona = await context.Personas.FindAsync(id);
              //.Include(x => x.Libros)
              //.FirstOrDefaultAsync(x => x.Id == id);


                if (persona == null)
                {
                    return new ResponseError(StatusCodes.Status404NotFound, "El recurso no existe").GetObjectResult();

                }
               
            
                var personaDTO = mapper.Map<PersonaDTO>(persona);
                return Ok(personaDTO);
            }
            catch (Exception ex)
            {

                return new ResponseError(StatusCodes.Status400BadRequest, ex.Message).GetObjectResult();
            }

        }


    }
}
