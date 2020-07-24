using GravitonLibrary.DataAccess;
using GravitonLibrary.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace GravitonLibrary.Tests
{
    public class SQLConnectorTests
    {
        [Fact]
        public void CreateCategory_AddCatgoryModelToDB()
        {
            CostCategoryModel model = new CostCategoryModel();
            int expected = 1;

            GlobalConfig.Connection.CreateCategory(model);

            int actual = model.category_id;

            Assert.Equal(expected, actual);
        }

        public int add(int a, int b)
        {
            return a + b;
        }
    }
}
