using GravitonLibrary.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GravitonLibrary.DataAccess
{
    public interface IDataConnection
    {
        List<LoginModel> CheckLogin(LoginModel model);
        CostCategoryModel CreateCategory(CostCategoryModel model);
        List<GroupModel> GetGroups_All();
        GroupModel CreateGroup(GroupModel model);
        List<CostCategoryModel> GetCategory_All();
        List<CostCenterModel> GetCostCenter_All();
        CostCenterModel CreateCostCenter(CostCenterModel model);
    }
}
