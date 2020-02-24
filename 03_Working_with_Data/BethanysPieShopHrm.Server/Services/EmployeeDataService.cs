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
            => await JsonSerializer.DeserializeAsync<IEnumerable<Employee>>
                (await _httpClient.GetStreamAsync($"api/employee"), new JsonSerializerOptions());

        public async Task<Employee> GetEmployeeDetails(int employeeId)
            => await JsonSerializer.DeserializeAsync<Employee>
                (await _httpClient.GetStreamAsync($"api/employee/{employeeId}"), new JsonSerializerOptions());

        public Task<Employee> AddEmployee(Employee employee) 
            => throw new NotImplementedException();
        public Task UpdateEmployee(Employee employee) 
            => throw new NotImplementedException();
        public Task DeleteEmployee(int employeeId) 
            => throw new NotImplementedException();
    }
}
