using Dapper;
using GravitonLibrary.Models;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

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
        /// Saves Category model to database.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public CostCategoryModel CreateCategory(CostCategoryModel model)
        {
            using (IDbConnection connection = new NpgsqlConnection(GlobalConfig.getDatabaseConnectionString()))
            {
                connection.ExecuteScalar($"insert into category values(default,'{model.category_name}','{model.category_alias}','{model.revenue}')");
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
        /// Saves Ledger Model to Database
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public LedgerModel CreateLedger(LedgerModel model)
        {
            using (IDbConnection connection = new NpgsqlConnection(GlobalConfig.getDatabaseConnectionString()))
            {
                connection.ExecuteScalar($"insert into ledger values(default,'{model.ledger_name}','{model.ledger_alias}',{model.ledger_opening_balance},{model.under_group},'{model.bill_based_accounting}','{model.cost_centers_applicable}','{model.enabel_interest_calculations}')");
                return model;
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
    }
}
