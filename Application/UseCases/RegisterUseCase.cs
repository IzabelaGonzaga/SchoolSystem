﻿using Application.DTO;
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

        public static void AddRegister(IRegisterRepository repository, IStudentRepository repository2, IClassRepository repository3, RegisterDto RegisterDto)
        {
            //TODO: Para que uma matrícula possa ser concluída, é necessário que a turma possua vaga.
            // 30 matriculas por curso, verficar matriculas ativas.

            var classEntity = repository3.GetById(RegisterDto.ClassId);
            var studentEntity = repository2.GetById(RegisterDto.StudentId);

            var RegisterEntity = Register.NewRegister(classEntity.StartDate, classEntity.Id, classEntity.Status, studentEntity.Id, studentEntity.Status);

            repository.Add(RegisterEntity);
        }

        public static void UpdateRegister(IRegisterRepository repository, RegisterDto RegisterDto, int id)
        {
            var registerEntity = repository.GetById(id) ?? throw new Exception("Register not found.");

            registerEntity.StudentId = RegisterDto.StudentId;
            registerEntity.ClassId = RegisterDto.ClassId;
            
            if(RegisterDto.Status.HasValue) registerEntity.Status = (EStatus)RegisterDto.Status;

            repository.Update(registerEntity);
        }

        public static void RemoveRegister(IRegisterRepository repository, int id)
        {
            repository.Delete(id);
        }
    }
}