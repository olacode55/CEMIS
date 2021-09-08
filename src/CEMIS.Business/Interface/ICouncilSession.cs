using CEMIS.Data.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CEMIS.Business.Interface
{
    public interface ICouncilSession
    {
        List<CouncilSession> GetAll();

        CouncilSession GetById(long Id);

        Task CreatAsync(CouncilSession model);

        void Update(CouncilSession model);

        void Delete(long Id);

       // IEnumerable<SelectListItem> GetAcademicSessionList();

        void Toggle(long Id);


    }
}
