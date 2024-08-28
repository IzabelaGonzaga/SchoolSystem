using Domain.Entities;

namespace Domain.Model
{
    public class Register : IEntity
    {
        public int Id { get; set; }
        public DateTime RegisterDate { get; set; }
        public EStatus Status { get; set; }
        public int StudentId { get; set; }
        public Student Student { get; set; }
        public int ClassId { get; set; }
        public Class Class { get; set; }

        public static Register NewRegister(DateTime startDate, int classId, EStatus classStatus, int studentId, EUserStatus studentStatus)
        { 
            //ver questão das vagas
            if (startDate <= DateTime.Now)
            {
                throw new Exception("The start date shouldn't be greater or equal today.");
            } else if (studentStatus == EUserStatus.Inactive)
            {
                throw new Exception("The student should be active.");
            } else if (classStatus != EStatus.Active)
            {
                throw new Exception("The class should be active.");
            }

            var register = new Register()
            {
                RegisterDate = DateTime.Now,
                Status = EStatus.Active,
                StudentId = studentId,
                ClassId = classId
            };


            return register;
        }
    }
}