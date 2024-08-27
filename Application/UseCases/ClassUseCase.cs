using Application.DTO;
using Data.Repositories;
using Domain.Model;

namespace Application.UseCases

{
    public class ClassUseCase
    {
            public static void AddClass(ClassDto classDto, IClassRepository repository)
        {
            var classEntity = new Class()
            {
                Title = classDto.Title,
                Description = classDto.Description,
                StartDate = classDto.StartDate,
                Status = EStatus.Active,
                Registers = []
            };

            repository.Add(classEntity);
        }
    }
}