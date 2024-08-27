using Application.DTO;
using Data.Repositories;
using Domain.Model;

//TODO: deveria ter um uso de caso só para desativar a classe, sem precisar colocar todos os dados
namespace Application.UseCases

{
    public static class ClassUseCase
    {
        public static Class GetClassById(IClassRepository repository, int id)
        {
            return repository.GetById(id);
        }

        public static List<Class> GetClasses(IClassRepository repository)
        {
            return repository.GetAll();
        }

        public static void AddClass(IClassRepository repository, ClassDto classDto)
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

        public static void UpdateClass(IClassRepository repository, ClassDto classDto, int id)
        {
            var classEntity = repository.GetById(id) ?? throw new Exception("Class not found.");
            classEntity = new Class()
            {
                Title = classDto.Title,
                Description = classDto.Description,
                StartDate = classDto.StartDate,
                Status = EStatus.Active,
                Registers = classEntity.Registers,
            };

            repository.Update(classEntity);
        }

        public static void RemoveClass(IClassRepository repository, int id)
        {
            repository.Delete(id);
        }
    }
}