using System;
using Xunit;
using DAL;
using Persistence;

namespace DAL.Test
{
    public class UserUnitTest
    {
        private UserDB userDAL = new UserDB();


        [Fact]
        public void LoginTest1()
        {
            string username = "manager_01";
            string password = "123456";
            User user = userDAL.Login(username, password);

            Assert.NotNull(user);
            Assert.Equal(username, user.User_Name);
        }

        [Fact]
        public void LoginTest2()
        {
            string username = "staff_01";
            string password = "123456";
            User user = userDAL.Login(username, password);

            Assert.NotNull(user);
            Assert.Equal(username, user.User_Name);
        }

        [Fact]
        public void LoginTest3()
        {
            Assert.Null(userDAL.Login("customer_01", "123456789"));
        }

        [Fact]
        public void LoginTest4()
        {
            Assert.Null(userDAL.Login("'?^%'", "'.:=='"));
        }
    }
}