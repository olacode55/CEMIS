using Cemis.Business.Central.Interface;
using Cemis.Data.Central.Entities;
using CEMIS.Business.Central.Interface;
using CEMIS.Data.Central;
using CEMIS.Utility;
using CEMIS.Utility.ViewModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Cemis.Business.Central.Repository
{
    public class ResultRepository : IResult
    {
        private readonly IRepository<Result> _resultRepository;
        private appContextCentral _context;
        public ResultRepository(IRepository<Result> resultRepository , appContextCentral context)
        {
            _context = context;
            _resultRepository = resultRepository;
        }
        public ResponseData<ResultViewModel> PushStudentResult(ResultViewModel resultVM, long collegeId)
        {
            try
            {
                ResponseData<ResultViewModel> resp;
                var resultDetail = _resultRepository.All().FirstOrDefault(x => x.SourceID == resultVM.Id && x.CollegeID == collegeId);

                if (resultDetail == null)
                {
                    var result = new Result
                    {
                        AcademicSessionSourceId = resultVM.AcademicSessionId,
                        StudentId = resultVM.StudentId,
                        CollegeID = collegeId,
                        CourseSourceId = resultVM.CourseId,
                        CreatedBy = resultVM.CreatedBy,
                        DateCreated = resultVM.DateCreated,
                        DateFetched = DateTime.Now,
                        DateUpdated = resultVM.DateUpdated,
                        Score = resultVM.Score,
                        ProgramSourceId = resultVM.ProgramId,
                        Grade = resultVM.Grade,
                        SourceID = resultVM.Id,
                        IsActive = resultVM.IsActive,
                        IsDeleted = resultVM.IsDeleted,
                        UpdatedBy = resultVM.UpdateBy,
                        Level = resultVM.Level
                    };

                    _resultRepository.Create(result);


                    resp = new ResponseData<ResultViewModel>
                    {
                        IsSuccessful = true,
                        Message = "Result created successfully",
                        RespCode = "00"
                    };
                    return resp;
                }


                resultDetail.AcademicSessionSourceId = resultVM.AcademicSessionId;
                resultDetail.StudentId = resultVM.StudentId;
                resultDetail.CourseSourceId = resultVM.CourseId;
                resultDetail.DateFetched = DateTime.Now;
                resultDetail.DateUpdated = resultVM.DateUpdated;
                resultDetail.Score = resultVM.Score;
                resultDetail.ProgramSourceId = resultVM.ProgramId;
                resultDetail.Grade = resultVM.Grade;
                resultDetail.SourceID = resultVM.Id;
                resultDetail.IsActive = resultVM.IsActive;
                resultDetail.IsDeleted = resultVM.IsDeleted;
                resultDetail.UpdatedBy = resultVM.UpdateBy;
                resultDetail.Level = resultVM.Level;

                resp = new ResponseData<ResultViewModel>
                {
                    IsSuccessful = true,
                    Message = "Result updated successfully",
                    RespCode = "00"
                };
                return resp;
            }
            catch (Exception ex)
            {
                ErrorLogManager.Error(ex);
                return new ResponseData<ResultViewModel>
                {
                    Message = "Operation failed",
                    RespCode = "04",
                    IsSuccessful = false
                };
            }


        }


        public List<StudentResultViewModel> GetStudentResult(string studentId, int SessionId, int level, int semester)
        {
            try
            {
                var student = _context.Student.FirstOrDefault(x => x.StudentId == studentId);
                var connectionString = _context.Database.GetDbConnection().ConnectionString;
                using (SqlConnection myCon = new SqlConnection(connectionString))
                {
                    DataTable dt = new DataTable();
                    var details = new List<StudentResultViewModel>();

                    SqlCommand cmd = new SqlCommand("GetStudentResult", myCon);
                    cmd.Parameters.AddWithValue("@StudentId", studentId);
                    cmd.Parameters.AddWithValue("@CollegeId", student.CollegeID);
                    cmd.Parameters.AddWithValue("@SessionId", SessionId);
                    cmd.Parameters.AddWithValue("@Level", level.ToString());
                    cmd.Parameters.AddWithValue("@Semeter", semester);

                    cmd.CommandType = CommandType.StoredProcedure;
                    myCon.Open();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);

                    foreach (DataRow dr in dt.Rows)
                    {

                        var obj = new StudentResultViewModel()
                        {
                          CourseCode = dr["CourseCode"].ToString(),
                          CourseTitle = dr["CourseTitle"].ToString(),
                          Credit = dr["Credit"].ToString(),
                          Grade = dr["Grade"].ToString(),
                          Score = dr["Score"].ToString(),
                        };
                        
                        details.Add(obj);
                    }

                    myCon.Close();
                    return details;
                }
            }
            catch (Exception ex)
            {

                ErrorLogManager.Error(ex);
                return new List<StudentResultViewModel>();
            }
        }
    }
}
