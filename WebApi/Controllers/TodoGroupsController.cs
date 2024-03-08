﻿using Applicaton.Dtos;
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
    public class TodoGroupsController : ControllerBase
    {
        private readonly IDataService _dataService;

        public TodoGroupsController(IDataService dataService)
        {
            _dataService = dataService;
        }

        // GET: api/TodoGroups/Get
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/TodoGroups/Get/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/TodoGroups/Create
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] TodoGroupDTO modelDto)
        {
            if (modelDto == null) { 
                return BadRequest(ApiResponseBuilder.GenerateBadRequest("Create Failed","Input not valid or null"));
            }
            if (!ModelState.IsValid)
            {
                var errors = ModelState.GetModelStateErrors();
                if (errors != null && errors.Count > 0 ) {
                    var msgBuilder = new StringBuilder();
                    foreach (var error in errors)
                    {
                        msgBuilder.AppendLine(error.ToString());
                    }
                    return BadRequest(ApiResponseBuilder.GenerateBadRequest("Create Failed",msgBuilder.ToString()));
                }
            }
            var createdDto = await _dataService.TodoGroupsService.Create(modelDto);
            if (createdDto == null)
            {
                return BadRequest(ApiResponseBuilder.GenerateBadRequest("Create Failed", "Some Error Occured"));
            }
            return Ok(ApiResponseBuilder.GenerateOK(createdDto, "Created Sucessfully", $"Record created sucessfully at api/TodoGroups/Get/{createdDto.Id}"));
        }

        // PUT api/TodoGroups/Update/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] TodoGroupDTO modelDto)
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
            var createdDto = await _dataService.TodoGroupsService.Update(modelDto);
            if (createdDto == null)
            {
                return BadRequest(ApiResponseBuilder.GenerateBadRequest("Update Failed", "Some Error Occured"));
            }
            return Ok(ApiResponseBuilder.GenerateOK(createdDto, "OK", "Record updated sucessfully"));
        }

        // DELETE api/TodoGroups//5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id<=0) 
            {
                return BadRequest(ApiResponseBuilder.GenerateBadRequest("Delete Failed", "Input input"));
            }
            var rowsAffected = await _dataService.TodoGroupsService.Delete(id);
            if(rowsAffected <= 0)
            {
                return BadRequest(ApiResponseBuilder.GenerateBadRequest("Delete Failed", "Invalid Input"));
            }
            return Ok(ApiResponseBuilder.GenerateOK(rowsAffected, "OK", $"Record with id {id} deleted sucessfully"));
        }

        [HttpPost]
        public async Task<IActionResult> CreateRange([FromBody] List<TodoGroupDTO> modelDto)
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
            var createdDto = await _dataService.TodoGroupsService.CreateRange(modelDto);
            if (createdDto == null || createdDto.Count <= 0)
            {
                return BadRequest(ApiResponseBuilder.GenerateBadRequest("Bulk Create Failed", "Some Error Occured"));
            }
            return Ok(ApiResponseBuilder.GenerateOK(createdDto, "Ok", "Bulk creat sucess"));
        }
    }
}
