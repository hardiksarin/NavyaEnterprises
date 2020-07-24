using GravitonLibrary.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GravitonLibrary.DataAccess
{
    public interface IDataConnection
    {
        //Login
        List<LoginModel> CheckLogin(LoginModel model);

        //Catgeory
        CostCategoryModel CreateCategory(CostCategoryModel model);
        List<CostCategoryModel> GetCategory_All();
        void UpdateCategory(CostCategoryModel model);

        //Groups
        List<GroupModel> GetGroups_All();
        GroupModel CreateGroup(GroupModel model);
        void UpdateGroups(GroupModel model);
        
        //Cost Center
        List<CostCenterModel> GetCostCenter_All();
        CostCenterModel CreateCostCenter(CostCenterModel model);
        void UpdateCostCenter(CostCenterModel model);

        //Ledger
        LedgerModel CreateLedger(LedgerModel model);
        List<LedgerModel> GetLedger_All();
        void UpdateLedger(LedgerModel model);

        //Journall
        JournalModel CreateJournal(JournalModel model);

        //Bank
        BankModel CreateBankDetails(BankModel model);

        //Cheque Inventory
        ChequeInventoryModel CreateChequeInventory(ChequeInventoryModel model);
    }
}
