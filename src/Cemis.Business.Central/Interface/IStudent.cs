using Cemis.Data.Central.Entities;
using CEMIS.Utility;
using CEMIS.Utility.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cemis.Business.Central.Interface
{
    public interface IStudent
    {
        List<Student> GetAllStudent();
        Student GetStudentById(long Id);
        ResponseData<Student> CreateStudent(Student student);
        StudentRegistrationDTO ValidateStudent(string studentId, string registrationPin);
        Task<ResponseData<StudentRegistrationDTO>> StudentRegistration(StudentRegistrationDTO studentRegDTO, string callback);
        ResponseData<StudentLogViewModel> PushStudentLog(StudentLogViewModel studentLogVM, long collegeID);
        ResponseData<Student> PushStudentDetails(StudentViewModel studentVM , long collegeID);
        List<StudentProfileViewModel> GetStudentProfile(string studentId);
    }
}
