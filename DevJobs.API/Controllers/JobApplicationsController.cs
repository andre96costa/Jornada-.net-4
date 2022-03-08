using DevJobs.API.Entities;
using DevJobs.API.Models;
using DevJobs.API.Persistence;
using Microsoft.AspNetCore.Mvc;

namespace DevJobs.API.Controllers
{
    [Route("api/job-vacancies/{id}/applications")]
    [ApiController]
    public class JobApplicationsController : ControllerBase
    {
        public JobApplicationsController(DevJobsContext context)
        {
            _context = context;
        }

        private readonly DevJobsContext _context;

        [HttpPost]
        public IActionResult Post(int id, AddJobApplicationInputModel model)
        {
            var jobVacancy = _context.JobVacancies.SingleOrDefault(jv => jv.Id == id);
            if (jobVacancy == null)
            {
                return NotFound();
            }
            var application = new JobApplication(model.ApplicantName, model.ApplicantName, model.IdJobVacancy);
            jobVacancy.Applications.Add(application);
            return NoContent();
        }
    }
}