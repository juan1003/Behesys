using Behesys.ApiService.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Concurrent;

namespace Behesys.ApiService.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class PatientsController : ControllerBase
  {
    private static readonly ConcurrentDictionary<int, Patient> _patients = new();
    private static int _nextId = 1;

    static PatientsController()
    {
      // Seed with demo data
      AddPatient(new Patient { Name = "John Doe", Age = 45, Gender = "Male", LastVisit = DateTime.Now.AddDays(-2), Status = "Active" });
      AddPatient(new Patient { Name = "Jane Smith", Age = 32, Gender = "Female", LastVisit = DateTime.Now.AddDays(-10), Status = "Inactive" });
      AddPatient(new Patient { Name = "Carlos Ruiz", Age = 60, Gender = "Male", LastVisit = DateTime.Now.AddDays(-1), Status = "Active" });
      AddPatient(new Patient { Name = "Emily Chen", Age = 27, Gender = "Female", LastVisit = DateTime.Now.AddDays(-5), Status = "Active" });
      AddPatient(new Patient { Name = "Fatima Al-Farsi", Age = 53, Gender = "Female", LastVisit = DateTime.Now.AddDays(-20), Status = "Inactive" });
    }

    [HttpGet]
    public ActionResult<IEnumerable<Patient>> GetAll() => Ok(_patients.Values.OrderByDescending(p => p.Id));

    [HttpGet("{id}")]
    public ActionResult<Patient> GetById(int id)
    {
      if (_patients.TryGetValue(id, out var patient))
        return Ok(patient);
      return NotFound();
    }

    [HttpPost]
    public ActionResult<Patient> Add([FromBody] Patient patient)
    {
      if (string.IsNullOrWhiteSpace(patient.Name) || patient.Age <= 0 || string.IsNullOrWhiteSpace(patient.Gender) || string.IsNullOrWhiteSpace(patient.Status))
        return BadRequest();
      AddPatient(patient);
      return Created($"api/patients/{patient.Id}", patient);
    }

    private static void AddPatient(Patient patient)
    {
      patient.Id = _nextId++;
      _patients[patient.Id] = patient;
    }
  }
}
