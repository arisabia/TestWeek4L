using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestWeek4L.Core.Interfaces;
using TestWeek4L.Core.Model;

namespace TestWeek4L.OrdineAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrdineController : ControllerBase
    {
        private readonly IOrdineBL businessLayer;

        private OrdineController(IOrdineBL businessLayer)
        {
            this.businessLayer = businessLayer;
        }

        // GET: api/<OrdineController>
        /// <summary>
        /// Get the Ordine list
        /// </summary>
        /// <returns>List of Oridine</returns>
        [HttpGet]
        public IActionResult Get()
        {
            var result = this.businessLayer.FetchOrdini();

            return Ok(result);
        }

        // GET api/<OrdineController>/5
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            if (id <= 0)
                return BadRequest("Invalid Ordine Id.");

            var oridine = this.businessLayer.FetchOrdineById(id);

            if (oridine == null)
                return NotFound($"Ordine with Id = {id} is missing.");

            return Ok(oridine);
        }

        // POST api/<OrdineController>
        [HttpPost]
        public IActionResult Post([FromBody] Ordine newOrdine)
        {
            if (newOrdine == null)
                return BadRequest("Invalid Book data.");

            if (!this.businessLayer.CreateOrdine(newOrdine))
                return BadRequest("Cannot complete the operation");

            return CreatedAtAction(nameof(GetById), new { id = newOrdine.ID }, newOrdine);
        }
        // PUT api/<OrdineController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Ordine editedOrdine)
        {
            if (editedOrdine == null)
                return BadRequest("Invalid Ordine data.");

            if (id != editedOrdine.ID)
                return BadRequest("Ordine IDs don't match.");

            if (!this.businessLayer.EditOrdine(editedOrdine))
                return BadRequest("Cannot complete the operation");

            return Ok();
        }
        // DELETE api/<OrdineController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            if (id <= 0)
                return BadRequest("Invalid Ordine ID.");

            var result = this.businessLayer.DeleteOrdinebyId(id);

            if (!result)
                return StatusCode(500, "Cannot complete the operation.");

            return Ok();
        }


    }
}
