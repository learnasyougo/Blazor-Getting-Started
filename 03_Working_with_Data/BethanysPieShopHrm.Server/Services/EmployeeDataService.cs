using BethanysPieShopHRM.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace BethanysPieShopHrm.Server.Services
{
    public class EmployeeDataService : IEmployeeDataService
    {
        private readonly HttpClient _httpClient;

        public EmployeeDataService(HttpClient httpClient)
            => _httpClient = httpClient;

        public async Task<IEnumerable<Employee>> GetEmployees()
        {

            var employeesJsonData = await _httpClient.GetStreamAsync($"api/employee");
            var employees = await JsonSerializer.DeserializeAsync<IEnumerable<Employee>>(employeesJsonData, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            return employees;
        }

        public async Task<Employee> GetEmployeeDetails(int employeeId)
            => await JsonSerializer.DeserializeAsync<Employee>
                (await _httpClient.GetStreamAsync($"api/employee/{employeeId}"), new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

        public Task<Employee> AddEmployee(Employee employee) 
            => throw new NotImplementedException();
        public Task UpdateEmployee(Employee employee) 
            => throw new NotImplementedException();
        public Task DeleteEmployee(int employeeId) 
            => throw new NotImplementedException();
    }
}
