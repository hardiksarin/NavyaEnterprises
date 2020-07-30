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

        //Voucher
        VoucherModel CreateVoucher(VoucherModel model);
        List<VoucherModel> GetVoucher_All();
        List<VoucherModel> GetVoucher_Payment();
        List<VoucherModel> GetVoucher_Reciept();

        //Particulars
        ParticularModel CreateParticular(ParticularModel model);
        List<ParticularModel> GetParticular_All();

        //Bills
        BillModel CreateBill(BillModel model);
        List<BillModel> GetBill_All();
        List<BillModel> GetBill_ById(LedgerModel model);
        void UpdateBill(BillModel model);

        //Journall
        JournalModel CreateJournal(JournalModel model);

        //Bank
        BankModel CreateBankDetails(BankModel model);

        //Cheque Inventory
        ChequeInventoryModel CreateChequeInventory(ChequeInventoryModel model);

        //Transactions
        TransactionModel CreateTransaction(TransactionModel model);
    }
}
