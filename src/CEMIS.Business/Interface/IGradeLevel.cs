using CEMIS.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CEMIS.Business.Interface
{
   public interface IGradeLevel
    {
        List<GradeLevel> GetAllGradeLevel();

        List<int> GetStep(int level);


    }
}
