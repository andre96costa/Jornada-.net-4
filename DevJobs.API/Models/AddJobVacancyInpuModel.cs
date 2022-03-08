namespace DevJobs.API.Models
{
    public record AddJobVacancyInpuModel(string Title, string Description, string Company, bool IsRemote, string SalaryRange)
    {
        
    }
}