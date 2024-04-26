using Applicaton.Dtos;
using Applicaton.Extensions;
using Applicaton.Helpers;
using Applicaton.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TodosController : ControllerBase
    {
        private readonly IDataService _dataService;

        public TodosController(IDataService dataService)
        {
            _dataService = dataService;
        }

        // GET: api/Todos/Get
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var modelVms = await _dataService.TodosService.Get();
            if (modelVms == null || modelVms.Count <= 0)
            {
                return NotFound(ApiResponseBuilder.GenerateNotFound("Get Failed", "Record(s) not found"));
            }
            return Ok(ApiResponseBuilder.GenerateOK(modelVms, "OK", $"{modelVms.Count} Record(s) Found"));
        }

        // GET api/Todos/Get/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            if (id <= 0)
                return BadRequest(ApiResponseBuilder.GenerateBadRequest("Get Failed", "Input not valid"));
            var modelDto = await _dataService.TodosService.Get(id);
            if (modelDto == null)
                return NotFound(ApiResponseBuilder.GenerateNotFound("Get Failed", $"Record with id {id} not found"));
            return Ok(ApiResponseBuilder.GenerateOK(modelDto, "OK", $"Record with id: {modelDto.Id} fetched"));
        }

        // POST api/Todos/Create
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] TodoDTO modelDto)
        {
            if (modelDto == null) { 
                return BadRequest(ApiResponseBuilder.GenerateBadRequest("Create Failed","Input not valid or null"));
            }
            if (!ModelState.IsValid)
            {
                var errors = ModelState.GetModelStateErrors();

                if (errors != null && errors.Count > 0 ) 
                {
                    var msgBuilder = new StringBuilder();
                    foreach (var error in errors)
                    {
                        msgBuilder.AppendLine(error.ToString());
                    }
                    return BadRequest(ApiResponseBuilder.GenerateBadRequest("Create Failed",msgBuilder.ToString()));
                }
            }
            var createdDto = await _dataService.TodosService.Create(modelDto);

            if (createdDto == null)
            {
                return BadRequest(ApiResponseBuilder.GenerateBadRequest("Create Failed", "Some Error Occured"));
            }
            return Ok(ApiResponseBuilder.GenerateOK(createdDto, "Created Sucessfully", $"Record created sucessfully at api/Todos/Get/{createdDto.Id}"));
        }

        // PUT api/Todos/Update/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] TodoDTO modelDto)
        {
            if (id <=0 || modelDto == null || modelDto.Id != id) 
            {
                return BadRequest(ApiResponseBuilder.GenerateBadRequest("Update Failed","Input input"));
            }

            if (!ModelState.IsValid)
            {
                var errors = ModelState.GetModelStateErrors();
                if (errors != null && errors.Count > 0)
                {
                    var msgBuilder = new StringBuilder();
                    foreach (var error in errors)
                    {
                        msgBuilder.AppendLine(error.ToString());
                    }
                    return BadRequest(ApiResponseBuilder.GenerateBadRequest("Update Failed", msgBuilder.ToString()));
                }
            }
            var createdDto = await _dataService.TodosService.Update(modelDto);
            if (createdDto == null)
            {
                return BadRequest(ApiResponseBuilder.GenerateBadRequest("Update Failed", "Some Error Occured"));
            }
            return Ok(ApiResponseBuilder.GenerateOK(createdDto, "OK", "Record updated sucessfully"));
        }

        // DELETE api/Todos//5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id<=0) 
            {
                return BadRequest(ApiResponseBuilder.GenerateBadRequest("Delete Failed", "Input input"));
            }
            var rowsAffected = await _dataService.TodosService.Delete(id);
            if(rowsAffected <= 0)
            {
                return BadRequest(ApiResponseBuilder.GenerateBadRequest("Delete Failed", "Invalid Input"));
            }
            return Ok(ApiResponseBuilder.GenerateOK(rowsAffected, "OK", $"Record with id {id} deleted sucessfully"));
        }

        [HttpPost]
        public async Task<IActionResult> CreateRange([FromBody] List<TodoDTO> modelDto)
        {
            if (modelDto == null || modelDto.Count <= 0)
            {
                return BadRequest(ApiResponseBuilder.GenerateBadRequest("Bulk Create Failed", "Input is null"));
            }
            if (!ModelState.IsValid)
            {
                var errors = ModelState.GetModelStateErrors();
                if (errors != null && errors.Count > 0)
                {
                    var msgBuilder = new StringBuilder();
                    foreach (var error in errors)
                    {
                        msgBuilder.AppendLine(error.ToString());
                    }
                    return BadRequest(ApiResponseBuilder.GenerateBadRequest("Bulk Create Failed", msgBuilder.ToString()));
                }
            }
            var createdDto = await _dataService.TodosService.CreateRange(modelDto);
            if (createdDto == null || createdDto.Count <= 0)
            {
                return BadRequest(ApiResponseBuilder.GenerateBadRequest("Bulk Create Failed", "Some Error Occured"));
            }
            return Ok(ApiResponseBuilder.GenerateOK(createdDto, "Ok", "Bulk Create sucess"));
        }

        [HttpPost]
        public async Task<IActionResult> UpdateRange([FromBody] List<TodoDTO> modelDto)
        {
            if (modelDto == null || modelDto.Count <= 0)
            {
                return BadRequest(ApiResponseBuilder.GenerateBadRequest("Bulk Update Failed", "Input is null"));
            }
            if (!ModelState.IsValid)
            {
                var errors = ModelState.GetModelStateErrors();
                if (errors != null && errors.Count > 0)
                {
                    var msgBuilder = new StringBuilder();
                    foreach (var error in errors)
                    {
                        msgBuilder.AppendLine(error.ToString());
                    }
                    return BadRequest(ApiResponseBuilder.GenerateBadRequest("Bulk Update Failed", msgBuilder.ToString()));
                }
            }
            var updatedDto = await _dataService.TodosService.UpdateRange(modelDto);
            if (updatedDto == null || updatedDto.Count <= 0)
            {
                return BadRequest(ApiResponseBuilder.GenerateBadRequest("Bulk Update Failed", "Some Error Occured"));
            }
            return Ok(ApiResponseBuilder.GenerateOK(updatedDto, "Ok", "Bulk Update sucess"));
        }

        [HttpPost]
        public async Task<IActionResult> DeleteRange([FromBody] List<TodoDTO> modelDto)
        {
            if (modelDto == null || modelDto.Count <= 0)
            {
                return BadRequest(ApiResponseBuilder.GenerateBadRequest("Bulk Delete Failed", "Input is null"));
            }
            if (!ModelState.IsValid)
            {
                var errors = ModelState.GetModelStateErrors();
                if (errors != null && errors.Count > 0)
                {
                    var msgBuilder = new StringBuilder();
                    foreach (var error in errors)
                    {
                        msgBuilder.AppendLine(error.ToString());
                    }
                    return BadRequest(ApiResponseBuilder.GenerateBadRequest("Bulk Delete Failed", msgBuilder.ToString()));
                }
            }
            var rowsAffected = await _dataService.TodosService.DeleteRange(modelDto);
            if (rowsAffected  <= 0)
            {
                return BadRequest(ApiResponseBuilder.GenerateBadRequest("Bulk Delete Failed", "Some Error Occured"));
            }
            return Ok(ApiResponseBuilder.GenerateOK(rowsAffected, "Ok", "Bulk Delete sucess"));
        }

        // GET api/Todos/GetByListID/5
        [HttpGet("{lid?}")]
        public async Task<IActionResult> GetByListID([FromRoute] int? lid)
        {
            if (lid <= 0)
                return BadRequest(ApiResponseBuilder.GenerateBadRequest("Get Failed", "Input not valid"));
            var modelDto = await _dataService.TodosService.GetByListID(lid);
            if (modelDto == null)
                return NotFound(ApiResponseBuilder.GenerateNotFound("Get Failed", "Record(s) not found"));
            return Ok(ApiResponseBuilder.GenerateOK(modelDto, "OK", $"{modelDto.Count} Record fetched"));
        }

    }
}
