using CEMIS.Utility.ViewModel;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CEMIS.Business.Interface
{
    public interface IProgram
    {
        List<ProgramViewModel> GetAllPrograms();

        ProgramViewModel GetProgramById(long Id);

        void Create(ProgramViewModel model);
        void Update(ProgramViewModel model);

        void Delete(long Id);

        void Toggle(long Id);

        IEnumerable<SelectListItem> GetProgramList();
    }
}
