using libreriaa_JAMB.Data.Models.Services;
using libreriaa_JAMB.Data.ViewModels;
using libreriaa_JAMB.Excepciones;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace libreriaa_JAMB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublishersController : ControllerBase
    {
        private PublishersService _publishersService;
        public PublishersController(PublishersService publishersService )
        {
            _publishersService = publishersService;
        }
        [HttpPost("add-publisher")] 
        public IActionResult AddPublisher([FromBody] PublisherVM publisher)
        {
           try
            {
                var newPublisher = _publishersService.AddPublisher(publisher);
                return Created(nameof(AddPublisher), newPublisher);
            }

            catch(PublisherNameException ex)
            {
                return BadRequest($"{ex.Message}, Nombre de la editora: {ex.PublisherName}");
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("get-publisher-by-id/{id}")]

        public IActionResult GetPubliserById(int id)
        {
            var _response = _publishersService.GetPublisherByID(id);
           if( _response == null )
            {
                return Ok(_response);
            }
            else
            {
                return NotFound();
            }
        }


        [HttpGet("get-publisher-books-with-authors/{id}")] 
        
        public IActionResult GetPubliserData (int id)
        {
            var _response = _publishersService.GetPublisheData(id);
            return Ok( _response );
        }
        [HttpDelete("delete-publisher-by-id/{id}")] 
        public IActionResult DeletePublisherById(int id)
        {
            try
            {
                _publishersService.DeletePublisherById(id);
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
