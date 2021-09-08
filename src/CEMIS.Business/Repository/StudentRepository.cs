using CEMIS.Business.Interface;
using CEMIS.Data.Entities;
using CEMIS.Utility.ViewModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CEMIS.Business.Repository
{
    public class StudentRepository : IStudent
    {

        private IRepository<Student> _studentRepo;
        private IRepository<StudentLog> _studentLogRepo;
        private IRepository<PreviousEducation> _previousEducation;
        public StudentRepository(IRepository<Student> studentRepo, IRepository<StudentLog> studentLogRepo, IRepository<PreviousEducation> previousEducation, IConfiguration _configuration)
        {
            _studentRepo = studentRepo;
            _studentLogRepo = studentLogRepo;
            _previousEducation = previousEducation;
        }


        public IEnumerable<Student> GetAll()
        {
            return _studentRepo.All()
                .Where(x => x.IsActive == true && x.IsDeleted == false)
                .ToList();
        }

        public IEnumerable<Student> GetDropoutStudents()
        {
            return _studentRepo.All()
                .Where(x => x.IsActive == false && x.IsDeleted == false)
                .ToList();
        }

        public IEnumerable<Student> GetStudentsBySessionAndProgram(long ProgramId, long AcademicSessionId)
        {

            return GetAll().Where(x => x.ProgramId == ProgramId && x.AcademicSessionId == AcademicSessionId).ToList();

        }

        public Student GetStudentByRef(string Ref)
        {
            return GetAll().Where(x => x.AppRefNumber == Ref).FirstOrDefault();
        }

        public Student GetStudentById(long Id)
        {
            return GetAll().Where(x => x.Id == Id).FirstOrDefault();
        }

        public Student GetStudentByStudentId(string StudentId)
        {
            return GetAll().Where(x => x.StudentId == StudentId).FirstOrDefault();
        }


        public async Task AddStudentAsync(Student model)
        {
            await _studentRepo.CreateAsync(model);
        }

        public async Task AddStudentPreviousEdu(PreviousEducation model)
        {
            await _previousEducation.CreateAsync(model);
        }

        public void UpdateStudent(Student model)
        {
            _studentRepo.Update(model);
        }

        public void UpdateStudentPreviousEdu(PreviousEducation model)
        {
            _previousEducation.Update(model);
        }

        public List<PreviousEducation> GetPreviousEducations(long studentId)
        {
            return _previousEducation.All().Where(x => x.StudentID == studentId).ToList();
        }

        public void DeletPreviousEducation(PreviousEducation model)
        {
            _previousEducation.Delete(model);
        }

        public List<StudentLog> GetExistingStudents(long AcademicSessionId, long ProgramId, long LevelId)
        {
            var studentLog = _studentLogRepo.All()
                .Where(x => x.IsActive == true && x.IsDeleted == false && x.LevelId == LevelId && x.ProgramId == ProgramId && x.AcademicSessionId == AcademicSessionId)
                .ToList();

            return studentLog;
        }


        public List<StudentLog> GetAllExistingStudents()
        {
            var studentLog = _studentLogRepo.All()
                .Where(x => x.IsActive == true && x.IsDeleted == false)
                .ToList();

            return studentLog;
        }
        public StudentLog GetExistingStudentByRef(string Ref)
        {
            return _studentLogRepo.All()
                .Where(x => x.IsActive == true && x.IsDeleted == false && x.AppRefNumber == Ref)
                .FirstOrDefault();
        }

        public void AddExistingStudent(StudentLog model)
        {

            _studentLogRepo.Create(model);

        }

        public void UpdateExistingStudent(StudentLog model)
        {
            _studentLogRepo.Update(model);
        }

        public StudentLog CheckExistingStudentIfExist(string Ref, long AcademicSessioId, long ProgramId, long LevelId)
        {
            return _studentLogRepo.All()
                .Where(x => x.IsActive == true && x.IsDeleted == false && x.AppRefNumber == Ref && x.ProgramId == ProgramId
                && x.AcademicSessionId == AcademicSessioId && x.LevelId == LevelId)
                .FirstOrDefault();
        }

        public StudentLog CheckExistingStudentIfExistByStudentID(string StudentId, long AcademicSessioId, long ProgramId, long LevelId)
        {
            return _studentLogRepo.All()
              .Where(x => x.IsActive == true && x.IsDeleted == false && x.StudentId == StudentId && x.ProgramId == ProgramId
              && x.AcademicSessionId == AcademicSessioId && x.LevelId == LevelId)
              .FirstOrDefault();
        }

        public StudentLog GetExistingStudentByStudentID(string StudentId, long ProgramId, long LevelId)
        {
            return _studentLogRepo.All()
            .Where(x => x.IsActive == true && x.IsDeleted == false && x.StudentId == StudentId && x.ProgramId == ProgramId
            && x.LevelId == LevelId)
            .FirstOrDefault();
        }
    }
}
