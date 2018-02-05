using Microsoft.AspNetCore.Http;

namespace ExempleAspNetCore.ViewModels
{
    public class CourseCreate
    {
        public int ProgramId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        
        public IFormFile Picture { get; set; }
    }
}
