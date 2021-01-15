using BLL.Collections;
using BLL.Models;
using Car.To.Go.UnitTests.Mockdata_User;
using DAL.DatabaseConnectionHandler;
using DAL.Handler;
using Factories;
using Logic_interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Car.To.Go.UnitTests.Application.Layer.Tests.Collections
{

    [TestClass]
    public class UserCollectionTests
    {
        private readonly User user = new User();
        private readonly UserCollection usercollection = new UserCollection();


        public void Connectionsetter()
        {
            DBConnectionHandler.SetConnectionString("Server = mssql.fhict.local; Database = dbi434548; User Id = dbi434548; Password = MijnFontysServer2020");
        }

        /*Validate Tests ------------------------------------ Validate Tests --------------------------------------------- Validate Tests ------------------------------------------------ Validate Tests ----------------------------------- */

        [TestMethod]
        public void ValidateLoginFailasUser()
        {
            var expected = "Failed";
            Connectionsetter();
            var result = user.ValidateLogin(MockDataUser.NotknownUser);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void ValidateLoginSuccesasUser()
        {
            Connectionsetter();
            var expected = "Success";
            var result = user.ValidateLogin(MockDataUser.CorrectUserTest);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void ValidateUserwithWrongPassword()
        {
            Connectionsetter();
            var expected = "Failed";
            var result = user.ValidateLogin(MockDataUser.WrongPasswordUser);
            Assert.AreEqual(expected, result);
        }


/*CheckDoubleEmails Tests ------------------------------------ CheckDoubleEmails Tests --------------------------------------------- CheckDoubleEmails Tests ------------------------------------------------ CheckDoubleEmails Tests ----------------------------------- */

        [TestMethod]
        public void GivenDoubleEmails()
        {
            Connectionsetter();
            var expected = true;
            bool result = user.CheckDoubleEmails(MockDataUser.CorrectUserTest);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void NoDoubleEmails()
        {
            Connectionsetter();
            var expected = false;
            bool result = user.CheckDoubleEmails(MockDataUser.NotknownUser);
            Assert.AreEqual(expected, result);
        }

/*GetAllUsers Tests ------------------------------------ GetAllUsers Tests --------------------------------------------- GetAllUsers Tests ------------------------------------------------ GetAllUsers Tests ----------------------------------- */

        [TestMethod]
        public void GetAllUsersTest()
        {
            Connectionsetter();
            var result = usercollection.GetUsers();
            Assert.IsNotNull(result);
        }
    }

}
