using Application.DTO;
using Data.Repositories;
using Domain.Model;

namespace Application.UseCases

{
    public static class RegisterUseCase
    {
        public static Register GetRegisterById(IRegisterRepository repository, int id)
        {
            return repository.GetById(id);
        }

        public static List<Register> GetRegisters(IRegisterRepository repository)
        {
            return repository.GetAll();
        }

        public static void AddRegister(IRegisterRepository repository, RegisterDto RegisterDto)
        {
            //TODO: Para que uma matrícula possa ser concluída, é necessário que o curso esteja ativo, a turma possua vaga e a data de inicio seja maior que hoje e que o aluno esteja ativo.
            // 30 matriculas por curso, verficar matriculas ativas.
            var RegisterEntity = new Register()
            {
                RegisterDate = DateTime.Now,
                StudentId = RegisterDto.StudentId,
                ClassId = RegisterDto.ClassId,
                Status = EStatus.Active,
                //TODO: Class ? Precisa de class, aparetemente o entity não adiciona automaticamente
                //TODO: Student ? Precisa de student, aparetemente o entity não adiciona automaticamente
            };

            repository.Add(RegisterEntity);
        }

        public static void UpdateRegister(IRegisterRepository repository, RegisterDto RegisterDto, int id)
        {
            var registerEntity = repository.GetById(id) ?? throw new Exception("Register not found.");

            registerEntity.StudentId = RegisterDto.StudentId;
            registerEntity.ClassId = RegisterDto.ClassId;
            registerEntity.Status = RegisterDto.Status;

            repository.Update(registerEntity);
        }

        public static void RemoveRegister(IRegisterRepository repository, int id)
        {
            repository.Delete(id);
        }
    }
}