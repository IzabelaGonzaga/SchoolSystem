using Domain.Model;

namespace Application.DTO;

public class RegisterDto
{
    public int StudentId { get; set; }
    public int ClassId { get; set; }
    public EStatus Status { get; set; }
}