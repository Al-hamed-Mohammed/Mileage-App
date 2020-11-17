using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MileageApp.Data;
using MileageApp.Models;

namespace MileageApp.Pages.Employees
{
    public class IndexModel : PageModel
    {
        private readonly MileageApp.Data.MileageAppContext _context;

        public IndexModel(MileageApp.Data.MileageAppContext context)
        {
            _context = context;
        }

        public IList<Employee> Employee { get;set; }

        [BindProperty(SupportsGet = true)]
        public string totalmiles { get; set; }

        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }
        [BindProperty(SupportsGet = true)]


        public string fromdate { get; set; }
        [BindProperty(SupportsGet = true)]
        public string todate { get; set; }
        // Requires using Microsoft.AspNetCore.Mvc.Rendering;
        public SelectList Genres { get; set; }
        [BindProperty(SupportsGet = true)]
        public string FirstName { get; set; }
        

        public async Task OnGetAsync()
        {
            IQueryable<string> employeeQuery = from m in _context.Employee
                                               orderby m.LastName
                                               select m.LastName;

            var employees = from m in _context.Employee
                         select m;

            var sum1 = _context.Employee.Sum(p => p.Miles);

            totalmiles = sum1.ToString();

            
            if (!string.IsNullOrEmpty(SearchString))
            {
                employees = employees.Where(s => s.FirstName.Contains(SearchString));

                var sum3 = employees.Where(s => s.FirstName.Contains(SearchString)).Sum(a=>a.Miles);

                totalmiles = sum3.ToString();
            }

            if (!string.IsNullOrEmpty(fromdate))
            {
                if (string.IsNullOrWhiteSpace(todate))
                {
                    todate = DateTime.Today.ToString("yyyy-MM-dd");
                }
                if (!string.IsNullOrWhiteSpace(fromdate))
                {
                    employees = employees.Where(s => s.TravelDate >= Convert.ToDateTime(fromdate) && s.TravelDate <= Convert.ToDateTime(todate));

                    var sum2 = employees.Where(s => s.TravelDate >= Convert.ToDateTime(fromdate) && s.TravelDate <= Convert.ToDateTime(todate)).Sum(p => p.Miles);

                    totalmiles = sum2.ToString();
                    // return View("Index", model);

                }
            }

            if (!string.IsNullOrEmpty(FirstName))
            {
                employees = employees.Where(x => x.LastName == FirstName);

                var sum4 = employees.Where(x => x.LastName == FirstName).Sum(a=>a.Miles);

                totalmiles = sum4.ToString();
            }
            Genres = new SelectList(await employeeQuery.Distinct().ToListAsync());

            Employee = await employees.ToListAsync();
        }
    }
}
