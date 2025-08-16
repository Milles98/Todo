using System.ComponentModel.DataAnnotations;

namespace TodoApp.Dto
{
    public class TodoPatchDto
    {
        [MaxLength(200)]
        public string? Description { get; set; }
        public bool? IsCompleted { get; set; }
    }
}
