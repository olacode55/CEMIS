using CEMIS.Business.Interface;
using CEMIS.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CEMIS.Business.Repository
{
   public class GradeLevelRepository: IGradeLevel
    {
        private readonly IRepository<GradeLevel> _GradelevelRepo;

        public GradeLevelRepository(IRepository<GradeLevel> GradelevelRepo)
        {
            _GradelevelRepo = GradelevelRepo;
        }

      public  List<GradeLevel> GetAllGradeLevel()
        {
            return _GradelevelRepo.All().Where(m => m.IsActive == true && m.IsDeleted == false).ToList();
        }

        public List<int> GetStep(int level)
        {
            var steps = new List<int>();
            var _level = level.ToString();
            var _gradeLevel = _GradelevelRepo.Filter(x => x.Name == _level).FirstOrDefault();
            for (int i = _gradeLevel.LowerBoundStep; i <= _gradeLevel.UpperBoundStep; i++)
            {
                steps.Add(i);
            }
            return steps;
        }
    }
}
