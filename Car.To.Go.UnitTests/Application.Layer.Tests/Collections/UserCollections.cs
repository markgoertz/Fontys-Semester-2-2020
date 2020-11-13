using BLL.Collections;
using Car.To.Go.UnitTests.Mockdata_User;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Car.To.Go.UnitTests.Application.Layer.Tests.Collections
{
   
    [TestClass]
    public class UserCollectionTests
    {
        private readonly UserCollection user = new UserCollection();

/*Validate Tests ------------------------------------ Validate Tests --------------------------------------------- Validate Tests ------------------------------------------------ Validate Tests ----------------------------------- */

        [TestMethod]
        public void ValidateLoginFailasUser()
        {
            var expected = "Failed";
            var result = user.ValidateLogin(MockDataUser.NotknownUser);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void ValidateLoginSuccesasUser()
        {
            var expected = "Success";
            var result = user.ValidateLogin(MockDataUser.CorrectUserTest);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void ValidateUserwithWrongPassword()
        {
            var expected = "Failed";
            var result = user.ValidateLogin(MockDataUser.WrongPasswordUser);
            Assert.AreEqual(expected, result);
        }


/*CheckDoubleEmails Tests ------------------------------------ CheckDoubleEmails Tests --------------------------------------------- CheckDoubleEmails Tests ------------------------------------------------ CheckDoubleEmails Tests ----------------------------------- */

        [TestMethod]
        public void GivenDoubleEmails()
        {
            var expected = true;
            bool result = user.CheckDoubleEmails(MockDataUser.CorrectUserTest);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void NoDoubleEmails()
        {
            var expected = false;
            bool result = user.CheckDoubleEmails(MockDataUser.NotknownUser);
            Assert.AreEqual(expected, result);
        }

/*GetAllUsers Tests ------------------------------------ GetAllUsers Tests --------------------------------------------- GetAllUsers Tests ------------------------------------------------ GetAllUsers Tests ----------------------------------- */

        [TestMethod]
        public void GetAllUsersTest()
        {
            var result = user.GetUsers();
            Assert.IsNotNull(result);
        }


        [TestMethod]
        public void CreateForUser()
        {

        }
    }

}
