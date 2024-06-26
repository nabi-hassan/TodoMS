using Applicaton.Dtos;
using Applicaton.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using NToastNotify;
using System.Diagnostics;
using WebApp.ServiceInterfaces;

namespace WebApp.Pages
{
    public class TodoListsModel : PageModel
    {
        private readonly IDataService _dataService; 
        private readonly IToastNotification _toastr;

        public TodoListsModel(IDataService dataService, IToastNotification toastr)
        {
            _dataService = dataService;
            _toastr = toastr;
        }
        [FromRoute] public int? gid { get; set; }

        public List<TodoListVM> modelVMs { get; set; }

        public async Task<IActionResult> OnGet()
        {
            var apiResponse = await _dataService.TodoLists.GetByGroupID(gid);
            var message = "Could'nt get response from API";
            if (apiResponse != null)
            {
                if (apiResponse.StatusCode == 200)
                {
                    modelVMs = apiResponse.Data != null ? JsonConvert.DeserializeObject<List<TodoListVM>>(apiResponse.Data.ToString()) : null;
                    message = $"Message: {apiResponse.Message} <br/>Description: {apiResponse.Description}";
                    _toastr.AddSuccessToastMessage(message);
                }
                else
                {
                    message = $"Title: {apiResponse.Title} <br/>Message: {apiResponse.Message}";
                    _toastr.AddErrorToastMessage(message);
                }
            }
            else
            {
                _toastr.AddErrorToastMessage(message);
            }

            return Page();
        }

        public async Task<IActionResult> OnGetAdd(string name)
        {
            var modelDto = new TodoListDTO
            {
                ListName = name,
                CreatedOn = DateTime.Now,
            };
            if (gid.HasValue)
            {
                modelDto.TodoGroupId = gid.Value;
            }
            var apiResponse = await _dataService.TodoLists.Create(modelDto);
            var message = "Could'nt get response from API";
            if (apiResponse != null)
            {
                if (apiResponse.StatusCode == 200)
                {
                    var createdDto = apiResponse.Data != null ? JsonConvert.DeserializeObject<TodoListDTO>(apiResponse.Data.ToString()) : null;
                    message = $"Message: {apiResponse.Message} <br/>Description: {apiResponse.Description}";
                }
                else
                {
                    message = $"Title: {apiResponse.Title} <br/>Message: {apiResponse.Message}";
                }
            }

            return new JsonResult(message);
        }

        public async Task<IActionResult> OnGetEdit(int id, string editedName)
        {
            var modelDto = new TodoListDTO
            {
                Id = id,
                ListName = editedName,
                CreatedOn = DateTime.Now,
            };
            if (gid.HasValue)
            {
                modelDto.TodoGroupId = gid.Value;
            }
            var apiResponse = await _dataService.TodoLists.Edit(id, modelDto);
            var message = "Could'nt get response from API";
            if (apiResponse != null)
            {
                if (apiResponse.StatusCode == 200)
                {
                    var editedDto = apiResponse.Data != null ? JsonConvert.DeserializeObject<TodoListDTO>(apiResponse.Data.ToString()) : null;
                    message = $"Message: {apiResponse.Message} <br/>Description: {apiResponse.Description}";
                }
                else
                {
                    message = $"Title: {apiResponse.Title} <br/>Message: {apiResponse.Message}";
                }
            }

            return new JsonResult(message);
        }

        public async Task<IActionResult> OnGetDetete(int id)
        {
            var apiResponse = await _dataService.TodoLists.Delete(id);
            var message = "Could'nt get response from API";
            if (apiResponse != null)
            {
                if (apiResponse.StatusCode == 200)
                {
                    var deletedDto = apiResponse.Data != null ? Convert.ToInt32(apiResponse.Data.ToString()) : -1;
                    message = $"Message: {apiResponse.Message} <br/>Description: {apiResponse.Description}";
                }
                else
                {
                    message = $"Title: {apiResponse.Title} <br/>Message: {apiResponse.Message}";
                }
            }

            return new JsonResult(message);
        }
    }
}
