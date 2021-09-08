using CEMIS.Data.Entities;
using CEMIS.Utility.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CEMIS.Business
{
    public interface IStudent
    {
        //IEnumerable<Student> GetAllStudents();
        IEnumerable<Student> GetAll();
        IEnumerable<Student> GetDropoutStudents();
        IEnumerable<Student> GetStudentsBySessionAndProgram(long ProgramId, long AcademicSessionId);
        Student GetStudentByRef(string Ref);

        Student GetStudentById(long Id);

        Student GetStudentByStudentId(string StudentId);

        Task AddStudentAsync(Student model);

        Task AddStudentPreviousEdu(PreviousEducation model);
        void UpdateStudent(Student model);
        void UpdateStudentPreviousEdu(PreviousEducation model);

        List<PreviousEducation> GetPreviousEducations(long studentId);
        void DeletPreviousEducation(PreviousEducation model);

        List<StudentLog> GetExistingStudents(long AcademicSessionId, long ProgramId, long LevelId);

        List<StudentLog> GetAllExistingStudents();

        StudentLog GetExistingStudentByRef(string Ref);

        StudentLog GetExistingStudentByStudentID(string StudentId, long ProgramId, long LevelId);

        void AddExistingStudent(StudentLog model);

        void UpdateExistingStudent(StudentLog model);

        StudentLog CheckExistingStudentIfExist(string Ref, long AcademicSessioId, long ProgramId, long LevelId);

        StudentLog CheckExistingStudentIfExistByStudentID(string StudentId, long AcademicSessioId, long ProgramId, long LevelId);
    }
}
