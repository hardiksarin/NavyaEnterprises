using Dapper;
using GravitonLibrary.Models;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Xunit;

namespace GravitonLibrary.DataAccess
{
    public class SQLConnector : IDataConnection
    {
        /// <summary>
        /// Gets The Login data from database
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public List<LoginModel> CheckLogin(LoginModel model)
        {
            using (IDbConnection connection = new NpgsqlConnection(GlobalConfig.getDatabaseConnectionString()))
            {
                List<LoginModel> output = new List<LoginModel>();
                output = connection.Query<LoginModel>("select * from login").ToList<LoginModel>();
                return output;
            }
        }

        /// <summary>
        /// Creates Bank Detaills and saves it in database.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public BankModel CreateBankDetails(BankModel model)
        {
            using (IDbConnection connection = new NpgsqlConnection(GlobalConfig.getDatabaseConnectionString()))
            {
                int id = connection.ExecuteScalar<int>($"insert into bank_details values(default,'{model.bank_name}','{model.bank_branch}','{model.bank_ifsc}') returning bank_id");
                model.bank_id = id;
                return model;
            }
        }

        /// <summary>
        /// Saves Bill Model to database.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public BillModel CreateBill(BillModel model)
        {
            using (IDbConnection connection = new NpgsqlConnection(GlobalConfig.getDatabaseConnectionString()))
            {
                connection.ExecuteScalar($"insert into bill values(default,'{model.bill_name}','{model.bill_due_date}',{model.bill_amount},{model.lid},{model.pid},'{model.bill_done}',{model.vid})");
                return model;
            }
        }

        /// <summary>
        /// Saves Category model to database.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public CostCategoryModel CreateCategory(CostCategoryModel model)
        {
            using (IDbConnection connection = new NpgsqlConnection(GlobalConfig.getDatabaseConnectionString()))
            {
                int id = connection.ExecuteScalar<int>($"insert into category values(default,'{model.category_name}','{model.category_alias}','{model.revenue}') returning category_id");
                model.category_id = id;
                return model;
            }
        }

        /// <summary>
        /// Saves Cheque Inventory to Database.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ChequeInventoryModel CreateChequeInventory(ChequeInventoryModel model)
        {
            using (IDbConnection connection = new NpgsqlConnection(GlobalConfig.getDatabaseConnectionString()))
            {
                int id = connection.ExecuteScalar<int>($"insert into cheque_inventory values(default,'{model.cheque_no}',{model.pid},{model.lid},'{model.status}',{model.bank_id}) returning cheque_id");
                model.cheque_id = id;
                return model;
            }
        }

        /// <summary>
        /// Saves Cost Center model to database
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public CostCenterModel CreateCostCenter(CostCenterModel model)
        {
            using (IDbConnection connection = new NpgsqlConnection(GlobalConfig.getDatabaseConnectionString()))
            {
                connection.ExecuteScalar($"insert into cost_centers values(default,'{model.cc_name}','{model.cc_alias}',{model.under_category},{model.under_cc})");
                return model;
            }
        }

        /// <summary>
        /// Saves Group Model to database.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public GroupModel CreateGroup(GroupModel model)
        {
            using (IDbConnection connection = new NpgsqlConnection(GlobalConfig.getDatabaseConnectionString()))
            {
                connection.ExecuteScalar($"insert into groups values(default,'{model.group_name}','{model.group_alias}',{model.under_group})");
                return model;
            }
        }

        /// <summary>
        /// Saves Journal model to Database.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public JournalModel CreateJournal(JournalModel model)
        {
            using (IDbConnection connection = new NpgsqlConnection(GlobalConfig.getDatabaseConnectionString()))
            {
                connection.ExecuteScalar($"insert into journal values('{model.j_date}','{model.j_time}','{model.j_log}')");
                return model;
            }
        }

        /// <summary>
        /// Saves Ledger Model to Database
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public LedgerModel CreateLedger(LedgerModel model)
        {
            using (IDbConnection connection = new NpgsqlConnection(GlobalConfig.getDatabaseConnectionString()))
            {
                //Add Ledger Model to Database
                int lid = connection.ExecuteScalar<int>($"insert into ledger values(default,'{model.ledger_name}','{model.ledger_alias}',{model.ledger_opening_balance},{model.under_group},'{model.bill_based_accounting}','{model.cost_centers_applicable}','{model.enable_interest_calculations}') returning lid");
                model.mailingModel.lid = lid;

                //Add Mailing Details to Database
                connection.ExecuteScalar($"insert into mailing_details values('{model.mailingModel.md_name}','{model.mailingModel.md_address}','{model.mailingModel.md_city}','{model.mailingModel.md_state}','{model.mailingModel.md_country}','{model.mailingModel.md_pincode}',{model.mailingModel.lid})");
                return model;
            }
        }

        /// <summary>
        /// Saves Particular Model to Database.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ParticularModel CreateParticular(ParticularModel model)
        {
            using (IDbConnection connection = new NpgsqlConnection(GlobalConfig.getDatabaseConnectionString()))
            {
                int id = connection.ExecuteScalar<int>($"insert into particulars values(default,{model.particular_amount},{model.particular_name},{model.vid}) returning pid");
                model.pid = id;
                return model;
            }
        }

        /// <summary>
        /// Saves Voucher Model to Database
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public VoucherModel CreateVoucher(VoucherModel model)
        {
            using (IDbConnection connection = new NpgsqlConnection(GlobalConfig.getDatabaseConnectionString()))
            {
                //Create Voucher
                int id = connection.ExecuteScalar<int>($"insert into voucher values(default,'{model.v_date}',{model.v_number},'{model.vtype}',{model.account}) returning vid");
                model.vid = id;
                model.Particular.vid = id;

                //Create Particular
                model.Particular = CreateParticular(model.Particular);
                return model;
            }
        }

        /// <summary>
        /// Gets all the record of Bill from Database.
        /// </summary>
        /// <returns></returns>
        public List<BillModel> GetBill_All()
        {
            List<BillModel> output = new List<BillModel>();
            using (IDbConnection connection = new NpgsqlConnection(GlobalConfig.getDatabaseConnectionString()))
            {
                output = connection.Query<BillModel>("select * from bill").ToList();
                return output;
            }
        }

        /// <summary>
        /// Gets all the records of Category from database.
        /// </summary>
        /// <returns></returns>
        public List<CostCategoryModel> GetCategory_All()
        {
            List<CostCategoryModel> output = new List<CostCategoryModel>();
            using (IDbConnection connection = new NpgsqlConnection(GlobalConfig.getDatabaseConnectionString()))
            {
                output = connection.Query<CostCategoryModel>("select * from category").ToList<CostCategoryModel>();
                return output;
            }
        }

        /// <summary>
        /// Gets all the records of Cost center from Database.
        /// </summary>
        /// <returns></returns>
        public List<CostCenterModel> GetCostCenter_All()
        {
            List<CostCenterModel> output = new List<CostCenterModel>();
            using (IDbConnection connection = new NpgsqlConnection(GlobalConfig.getDatabaseConnectionString()))
            {
                output = connection.Query<CostCenterModel>("select * from cost_centers").ToList<CostCenterModel>();
                return output;
            }
        }

        /// <summary>
        /// Gets all records of groups from database.
        /// </summary>
        /// <returns></returns>
        public List<GroupModel> GetGroups_All()
        {
            List<GroupModel> output = new List<GroupModel>();
            using (IDbConnection connection = new NpgsqlConnection(GlobalConfig.getDatabaseConnectionString()))
            {
                output = connection.Query<GroupModel>("select * from groups").ToList<GroupModel>();
                return output;
            }
        }

        /// <summary>
        /// Gets all the records of Ledger from database.
        /// </summary>
        /// <returns></returns>
        public List<LedgerModel> GetLedger_All()
        {
            List<LedgerModel> output = new List<LedgerModel>();
            List<MailingDetailsModel> mailingDetails = new List<MailingDetailsModel>();
            using (IDbConnection connection = new NpgsqlConnection(GlobalConfig.getDatabaseConnectionString()))
            {
                output = connection.Query<LedgerModel>("select * from ledger").ToList<LedgerModel>();

                mailingDetails = connection.Query<MailingDetailsModel>("select * from mailing_details").ToList<MailingDetailsModel>();

                foreach (LedgerModel ledger in output)
                {
                    foreach (MailingDetailsModel mailing in mailingDetails)
                    {
                        if(ledger.lid == mailing.lid)
                        {
                            ledger.mailingModel = mailing;
                        }
                    }
                }
                return output;
            }
        }

        /// <summary>
        /// Gets all the records of particulars from database.
        /// </summary>
        /// <returns></returns>
        public List<ParticularModel> GetParticular_All()
        {
            List<ParticularModel> output = new List<ParticularModel>();
            using (IDbConnection connection = new NpgsqlConnection(GlobalConfig.getDatabaseConnectionString()))
            {
                output = connection.Query<ParticularModel>("select * from particulars").ToList();
                return output;
            }
        }

        /// <summary>
        /// Gets all the records of Voucher from Database.
        /// </summary>
        /// <returns></returns>
        public List<VoucherModel> GetVoucher_All()
        {
            List<VoucherModel> output = new List<VoucherModel>();
            using (IDbConnection connection = new NpgsqlConnection(GlobalConfig.getDatabaseConnectionString()))
            {
                output = connection.Query<VoucherModel>("select * from voucher").ToList();
                return output;
            }
        }

        /// <summary>
        /// Updates the Category into Database.
        /// </summary>
        /// <param name="model"></param>
        public void UpdateCategory(CostCategoryModel model)
        {
            using (IDbConnection connection = new NpgsqlConnection(GlobalConfig.getDatabaseConnectionString()))
            {
                connection.ExecuteScalar($"update category set category_name = '{model.category_name}', category_alias = '{model.category_alias}', revenue = '{model.revenue}' where category_id = {model.category_id}");
            }
        }

        /// <summary>
        /// Updates the Cost Centers into Database.
        /// </summary>
        /// <param name="model"></param>
        public void UpdateCostCenter(CostCenterModel model)
        {
            using (IDbConnection connection = new NpgsqlConnection(GlobalConfig.getDatabaseConnectionString()))
            {
                connection.ExecuteScalar($"update cost_centers set cc_name = '{model.cc_name}', cc_alias = '{model.cc_alias}', under_category = {model.under_category}, under_cc = {model.under_cc} where cost_center_id = {model.cost_center_id}");
            }
        }

        /// <summary>
        /// Updates the Groups into Database.
        /// </summary>
        /// <param name="model"></param>
        public void UpdateGroups(GroupModel model)
        {
            using (IDbConnection connection = new NpgsqlConnection(GlobalConfig.getDatabaseConnectionString()))
            {
                connection.ExecuteScalar($"update groups set group_name = '{model.group_name}', group_alias = '{model.group_alias}', under_group = {model.under_group} where group_id = {model.group_id}");
            }
        }

        /// <summary>
        /// Updates the Ledgers and its Mailing Details into Database.
        /// </summary>
        /// <param name="model"></param>
        public void UpdateLedger(LedgerModel model)
        {
            MailingDetailsModel m = model.mailingModel;
            using (IDbConnection connection = new NpgsqlConnection(GlobalConfig.getDatabaseConnectionString()))
            {
                //Update Ledger table in database
                connection.ExecuteScalar($"update ledger set ledger_name = '{model.ledger_name}', ledger_alias = '{model.ledger_alias}', ledger_opening_balance = {model.ledger_opening_balance}, under_group = {model.under_group}, bill_based_accounting = '{model.bill_based_accounting}', cost_centers_applicable = '{model.cost_centers_applicable}', enabel_interest_calculations = '{model.enable_interest_calculations}' where lid = {model.lid}");

                //update Mailing Details Table in Database
                connection.ExecuteScalar($"update mailing_details set md_name = '{m.md_name}', md_address = '{m.md_address}', md_city = '{m.md_city}', md_state = '{m.md_state}', md_country = '{m.md_country}', md_pincode = '{m.md_pincode}' where lid = {model.lid}");
            }
        }
    }
}
  