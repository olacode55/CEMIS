using CEMIS.Data.Central;
using CEMIS.Data.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CEMIS.Utility.ViewModel;
namespace CEMIS.Business.Central.Interface
{
  public  interface IRoleService
    {
        Task<string> CreateRoleAsync(RoleDTO model);

        Task <string> RemoveRole(RoleViewModel model);
        Task<string> AssignUsersToRole(long roleId, long[] userIds);
        Task<string> RemoveUsersFromRole(long roleId, long[] userIds);
        Task<string> UpdateRoleAsync(RoleDTO obj, long id);
        Task<RoleViewModel> GetRole(long id);
        Task<IEnumerable<RoleViewModel>> GetAllRolesAsync();
        Task<RoleCollectionViewModel> GetAssignedAndUnAssignedUserToRole(long Id);

    }
}
