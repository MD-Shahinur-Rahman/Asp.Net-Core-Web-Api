using EmployeeManagementWebApi.Models.DTO;
using EmployeeManagementWebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly AppDbContext _db;
        private readonly IWebHostEnvironment _environment;

        public EmployeesController(AppDbContext db, IWebHostEnvironment environment)
        {
            _db = db;
            _environment = environment;
        }

        [HttpGet]
        public IActionResult GetAllEmployees()
        {
            List<Employee> employees = _db.Employees.Include(e => e.Experiences).ToList();
            string jsonString = JsonConvert.SerializeObject(employees, Formatting.Indented, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            return Content(jsonString, "application/json");
        }

        [HttpGet("{employeeId}")]
        public IActionResult GetEmployeeById(int employeeId)
        {
            Employee employee = _db.Employees.Include(e => e.Experiences).FirstOrDefault(e => e.EmployeeId == employeeId);
            if (employee == null)
            {
                return NotFound();
            }
            string jsonString = JsonConvert.SerializeObject(employee, Formatting.Indented, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            return Content(jsonString, "application/json");
        }

        [HttpPost]
        public async Task<IActionResult> PostEmployee([FromForm] EmployeeDtos empdto)
        {
            string imageUrl = GetImageFile(empdto);
            Employee empObj = new Employee
            {
                EmployeeName = empdto.EmployeeName,
                IsActive = empdto.IsActive,
                JoinDate = empdto.JoinDate,
                Email = empdto.Email,
                ImageName = empdto.ImageName,
                ImageUrl = imageUrl
            };

            _db.Employees.Add(empObj);
            await _db.SaveChangesAsync();

            var emp = _db.Employees.FirstOrDefault(e => e.EmployeeName == empdto.EmployeeName);
            List<Experience> list = JsonConvert.DeserializeObject<List<Experience>>(empdto.Experiences);
            if (list != null && list.Count > 0)
            {
                foreach (Experience ex in list)
                {
                    Experience expObj = new Experience
                    {
                        EmployeeId = emp.EmployeeId,
                        Title = ex.Title,
                        Duration = ex.Duration
                    };
                    _db.Experiences.Add(expObj);
                }
                await _db.SaveChangesAsync();
            }

            return Ok("Employee saved successfully");
        }

        private string GetImageFile(EmployeeDtos empDto)
        {
            string fileName = empDto.ImageName + ".jpg";
            string filePath = Path.Combine(_environment.WebRootPath, "Upload", fileName);

            if (empDto.ImgFile?.Length > 0)
            {
                if (!Directory.Exists(Path.Combine(_environment.WebRootPath, "Upload")))
                {
                    Directory.CreateDirectory(Path.Combine(_environment.WebRootPath, "Upload"));
                }

                using (FileStream fileStream = new FileStream(filePath, FileMode.Create))
                {
                    empDto.ImgFile.CopyTo(fileStream);
                }
            }

            return "/Upload/" + fileName;
        }

        [HttpPut("{employeeId}")]
        public async Task<IActionResult> UpdateEmployee(int employeeId, [FromForm] EmployeeDtos emp)
        {
            var empObj = await _db.Employees.FindAsync(employeeId);
            if (empObj == null)
            {
                return NotFound("Employee not found");
            }

            string imageUrl = GetImageFile(emp);
            empObj.EmployeeName = emp.EmployeeName;
            empObj.IsActive = emp.IsActive;
            empObj.Email = emp.Email;
            empObj.JoinDate = emp.JoinDate;
            empObj.ImageName = emp.ImageName;
            empObj.ImageUrl = imageUrl;

            var existingExperiences = _db.Experiences.Where(e => e.EmployeeId == employeeId);
            if (existingExperiences.Any())
            {
                _db.RemoveRange(existingExperiences);
            }

            List<Experience> list = JsonConvert.DeserializeObject<List<Experience>>(emp.Experiences);
            if (list != null && list.Count > 0)
            {
                foreach (Experience ex in list)
                {
                    Experience expObj = new Experience
                    {
                        EmployeeId = employeeId,
                        Title = ex.Title,
                        Duration = ex.Duration
                    };
                    _db.Experiences.Add(expObj);
                }
            }

            await _db.SaveChangesAsync();
            return Ok("Employee updated successfully");
        }

        [HttpDelete("{employeeId}")]
        public async Task<IActionResult> DeleteEmployee(int employeeId)
        {
            var empObj = await _db.Employees.FindAsync(employeeId);
            if (empObj == null)
            {
                return NotFound("Employee not found");
            }

            _db.Employees.Remove(empObj);
            await _db.SaveChangesAsync();
            return Ok("Employee deleted successfully");
        }
    }
}
