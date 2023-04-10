using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;
using BlazorCrud.Shared.Models;

namespace BlazorCrud.Client.Pages
{
    public class GetEmployeeComponent : ComponentBase
    {
        [Inject]
        private HttpClient Client { get; set; }

        public List<EmployeeModel> EmployeeList;
        public List<EmployeeModel> searchUserData;
        public EmployeeModel user;
        public string SearchString { get; set; } = string.Empty;
        protected override async Task OnInitializedAsync()
        {
            await GetUser();
        }
        private async Task GetUser()
        {
            EmployeeList = await Client.GetFromJsonAsync<List<EmployeeModel>>("api/employee");
            searchUserData = EmployeeList;
        }
        private void FilterEmployee()
        {
            if (!string.IsNullOrEmpty(SearchString))
            {
                EmployeeList = searchUserData
                .Where(x => x.Name.IndexOf(SearchString, StringComparison.OrdinalIgnoreCase) != -1)
                .ToList();
            }
            else
            {
                EmployeeList = searchUserData;
            }
        }
        private void DeleteConfirm(int userID)
        {
            user = EmployeeList.FirstOrDefault(x => x.EmployeeId == userID);
        }
        public void ResetSearch()
        {
            SearchString = string.Empty;
            EmployeeList = searchUserData;
        }
    }
}
