using BethanysPieShopHrm.Server.Services;
using BethanysPieShopHRM.Shared;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BethanysPieShopHrm.Server.Pages
{
    public class EmployeeDetailBase : ComponentBase
    {

		[Inject]
		public IEmployeeDataService EmployeeDataService { get; set; }

		protected override async Task OnInitializedAsync()
			=> Employee = await EmployeeDataService.GetEmployeeDetails(Int32.Parse(EmployeeId));

		[Parameter]
		public string EmployeeId { get; set; }

		public Employee Employee { get; set; } = null;
	}
}
