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
    public class TodoGroupsModel : PageModel
    {
        private readonly IDataService _dataService; 
        private readonly IToastNotification _toastr;

        public TodoGroupsModel(IDataService dataService, IToastNotification toastr)
        {
            _dataService = dataService;
            _toastr = toastr;
        }

        public List<TodoGroupVM> modelVMs { get; set; }

        public async Task<IActionResult> OnGet()
        {
            var apiResponse = await _dataService.TodoGroups.Get();
            var message = "Could'nt get response from API";
            if (apiResponse != null)
            {
                if (apiResponse.StatusCode == 200)
                {
                    modelVMs = apiResponse.Data != null ? JsonConvert.DeserializeObject<List<TodoGroupVM>>(apiResponse.Data.ToString()) : null;
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
            var modelDto = new TodoGroupDTO
            {
                GroupName = name,
                CreatedOn = DateTime.Now,
            };
            var apiResponse = await _dataService.TodoGroups.Create(modelDto);
            var message = "Could'nt get response from API";
            if (apiResponse != null)
            {
                if (apiResponse.StatusCode == 200)
                {
                    var createdDto = apiResponse.Data != null ? JsonConvert.DeserializeObject<TodoGroupDTO>(apiResponse.Data.ToString()) : null;
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
            var modelDto = new TodoGroupDTO
            {
                Id = id,
                GroupName = editedName,
                CreatedOn = DateTime.Now,
            };
            var apiResponse = await _dataService.TodoGroups.Edit(id, modelDto);
            var message = "Could'nt get response from API";
            if (apiResponse != null)
            {
                if (apiResponse.StatusCode == 200)
                {
                    var editedDto = apiResponse.Data != null ? JsonConvert.DeserializeObject<TodoGroupDTO>(apiResponse.Data.ToString()) : null;
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
            var apiResponse = await _dataService.TodoGroups.Delete(id);
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
