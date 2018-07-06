using System;
using Xunit;
using MySql.Data.MySqlClient;
using DAL;

namespace DAL.Test
{
    public class DbConfiguratonTest
    {
        [Fact]
        public void OpenConnectionTest()
        {
            Assert.NotNull(DbConfiguration.OpenConnection());
        }

        [Theory]
        [InlineData("server=localhost;user id=EventUser;password=123456789;port=3306;database=userdb;SslMode=None")]
        public void OpenConnectionWithStringTest(string connectionString)
        {
            Assert.NotNull(DbConfiguration.OpenConnection(connectionString));
        }

        [Theory]
        [InlineData("server=localhost1;user id=EventUser;password=123456789;port=3306;database=userdb;SslMode=None")]
        [InlineData("server=localhost;user id=EventUser321;password=123456789;port=3306;database=userdb;SslMode=None")]
        [InlineData("server=localhost;user id=EventUser;password=123456789123;port=3306;database=userdb;SslMode=None")]
        [InlineData("server=localhost;user id=EventUser;password=123456789;port=3307;database=userdb;SslMode=None")]
        [InlineData("server=localhost;user id=EventUser;password=123456789;port=3306;database=userdb123;SslMode=None")]
        [InlineData("server=localhost;user id=EventUser;password=123456789;port=3306;database=userdb;SslMode=Non")]
        [InlineData("server=localhost;user id=EventUser;password=123456789;port=3306;database=userdb")]
        public void OpenConnectionWithStringFailTest(string connectionString)
        {
            Assert.Null(DbConfiguration.OpenConnection(connectionString));
        }

        [Fact]
        public void OpenDefaultConnectionTest()
        {
            Assert.NotNull(DbConfiguration.OpenDefaultConnection());
        }
    }
}
