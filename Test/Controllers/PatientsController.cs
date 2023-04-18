using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using System.Data.SqlClient;

namespace Test.Controllers.Patientscontroller

{
    [ApiController]
    [Route("api/[controller]")]
    public class PatientsController : ControllerBase
    {
        private readonly List<Patient> _patients = new List<Patient>
        {
            new Patient { Id = 1, Name = "John", LastName = "Doe", DateOfBirth = new DateTime(1985, 1, 1) },
            new Patient { Id = 2, Name = "Jane", LastName = "Smith", DateOfBirth = new DateTime(1990, 2, 2) },
            new Patient { Id = 3, Name = "Alice", LastName = "Johnson", DateOfBirth = new DateTime(1975, 3, 3) },
           
        };

        [HttpGet]
        public ActionResult<IEnumerable<Patient>> GetPatients([FromQuery] string lastName)
        {
            var filteredPatients = _patients.FindAll(p => string.Equals(p.LastName, lastName, StringComparison.OrdinalIgnoreCase));
            if (filteredPatients.Count == 0)
            {
                return NoContent();
            }
            else
            {
                return Ok(filteredPatients);
            }
        }
    }

    public class Patient
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}

public class PatientsController : ControllerBase
{
    private string _connectionString; 

    public PatientsController(string connectionString)
    {
        _connectionString = connectionString;
    }

    [HttpGet]
    public IActionResult GetDoctorsAndSpecializations()
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            connection.Open();

            
            string query = "SELECT d.DoctorId, d.FirstName, d.LastName, s.SpecializationName " +
                           "FROM Doctors d " +
                           "JOIN Specializations s ON d.SpecializationId = s.SpecializationId";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int doctorId = (int)reader["DoctorId"];
                        string firstName = (string)reader["FirstName"];
                        string lastName = (string)reader["LastName"];
                        string specialization = (string)reader["SpecializationName"];

                        
                        Console.WriteLine($"DoctorId: {doctorId}, FirstName: {firstName}, LastName: {lastName}, Specialization: {specialization}");
                    }
                }
            }

           
            return Ok();
        }
    }
}