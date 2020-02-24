using BethanysPieShopHrm.Server.Services;
using BethanysPieShopHRM.Shared;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BethanysPieShopHrm.Server.Pages
{
	public class EmployeeOverviewBase : ComponentBase
	{
		[Inject]
		public IEmployeeDataService EmployeeDataService { get; set; }

		protected override async Task OnInitializedAsync()
			=> Employees = (await EmployeeDataService.GetEmployees()).ToList();		

		public IEnumerable<Employee> Employees { get; set; }		
	}
}
