using CEMIS.Data.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CEMIS.Business.Interface
{
    public interface IAcademicSession
    {
        List<AcademicSession> GetAll();

        AcademicSession GetById(long Id);

        Task CreatAsync(AcademicSession model);

        void Update(AcademicSession model);

        void Delete(long Id);

        IEnumerable<SelectListItem> GetAcademicSessionList();

        void Toggle(long Id);


    }
}
