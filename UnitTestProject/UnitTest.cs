using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Project_PP.Classes;
using Project_PP.Model;
using System.Collections.Generic;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTest
    {
        /// <summary>
        /// Положительный тест на проверку полей для регистрации пользователя
        /// </summary>
        [TestMethod]
        public void CheckUser_IsTrue()
        {
            Assert.IsTrue(CheckFieldsClass.CheckUser("Иванов", "Иван", "admin", "admin"));
        }

        /// <summary>
        /// Негативный тест на проверку полей для регистрации пользователя
        /// </summary>
        [TestMethod]
        public void CheckUser_IsFalse()
        {
            Assert.IsFalse(CheckFieldsClass.CheckUser("Иванов", "Иван", "admin", ""));
        }

        /// <summary>
        /// Положительный тест на проверку авторизации
        /// </summary>
        [TestMethod]
        public void CheckAuthorization_IsTrue()
        {
            Assert.IsTrue(CheckFieldsClass.CheckAuthorization("admin", "admin"));
        }

        /// <summary>
        /// Негативный тест на проверку авторизации
        /// </summary>
        [TestMethod]
        public void CheckAuthorization_IsFalse()
        {
            Assert.IsFalse(CheckFieldsClass.CheckAuthorization("admin", ""));
        }

        /// <summary>
        /// Положительный тест на проверку повтора пароля
        /// </summary>
        [TestMethod]
        public void CheckRepeatePassword_IsTrue()
        {
            Assert.IsTrue(CheckFieldsClass.CheckRepeatePassword("admin", "admin"));
        }

        /// <summary>
        /// Негативный тест на проверку повтора пароля
        /// </summary>
        [TestMethod]
        public void CheckRepeatePassword_IsFalse()
        {
            Assert.IsFalse(CheckFieldsClass.CheckRepeatePassword("admin", "aadmin"));
        }

        /// <summary>
        /// Положительный тест на проверку старого пароля
        /// </summary>
        [TestMethod]
        public void CheckOldPassword_IsTrue()
        {
            Assert.IsTrue(CheckFieldsClass.CheckOldPassword("admin", new LoginedTable() { ID = 1, LoginUser = "admin", PasswordUser = "admin".GetHashCode() }));
        }

        /// <summary>
        /// Негативный тест на проверку старого пароля
        /// </summary>
        [TestMethod]
        public void CheckOldPassword_IsFalse()
        {
            Assert.IsFalse(CheckFieldsClass.CheckOldPassword("admin", new LoginedTable() { ID = 1, LoginUser = "admin", PasswordUser = "aadmin".GetHashCode() }));
        }

        /// <summary>
        /// Положительный тест на проверку полей для изменения данных пользователя
        /// </summary>
        [TestMethod]
        public void CheckUpdateUser_IsTrue()
        {
            Assert.IsTrue(CheckFieldsClass.CheckUpdateUser("Иванов", "Иван", "admin"));
        }

        /// <summary>
        /// Негативный тест на проверку полей для изменения данных пользователя
        /// </summary>
        [TestMethod]
        public void CheckUpdateUser_IsFalse()
        {
            Assert.IsFalse(CheckFieldsClass.CheckUpdateUser("Иванов", "Иван", ""));
        }

        /// <summary>
        /// Положительный тест на проверку полей для смены пароля
        /// </summary>
        [TestMethod]
        public void CheckUpdatePassword_IsTrue()
        {
            Assert.IsTrue(CheckFieldsClass.CheckUpdatePassword("admin", "admin11", "admin11"));
        }

        /// <summary>
        /// Негативный тест на проверку полей для смены пароля
        /// </summary>
        [TestMethod]
        public void CheckUpdatePassword_IsFalse()
        {
            Assert.IsFalse(CheckFieldsClass.CheckUpdatePassword("", "admin11", "admin11"));
        }

        /// <summary>
        /// Положительный тест на проверку полей для смены пароля
        /// </summary>
        [TestMethod]
        public void CheckAdminUpdatePassword_IsTrue()
        {
            Assert.IsTrue(CheckFieldsClass.CheckAdminUpdatePassword("admin", "admin"));
        }

        /// <summary>
        /// Негативный тест на проверку полей для смены пароля
        /// </summary>
        [TestMethod]
        public void CheckAdminUpdatePassword_IsFalse()
        {
            Assert.IsFalse(CheckFieldsClass.CheckAdminUpdatePassword("admin", null));
        }

        /// <summary>
        /// Положительный тест на проверку полей для добавления клиента
        /// </summary>
        [TestMethod]
        public void CheckClient_IsTrue()
        {
            Assert.IsTrue(CheckFieldsClass.CheckClient("Иванов", "Иван", "Иванович", "ул. Горького, 1, 1", "+7 999 999 99 99"));
        }

        /// <summary>
        /// Негативный тест на проверку полей для добавления клиента
        /// </summary>
        [TestMethod]
        public void CheckClient_IsFalse()
        {
            Assert.IsFalse(CheckFieldsClass.CheckClient("Иванов", "Иван", "Иванович", null, null));
        }

        /// <summary>
        /// Положительный тест на проверку полей для добавления оборудования
        /// </summary>
        [TestMethod]
        public void CheckEquipment_IsTrue()
        {
            Assert.IsTrue(CheckFieldsClass.CheckEquipment("Смартфон", "11111111", "Samsung"));
        }

        /// <summary>
        /// Негативный тест на проверку полей для добавления оборудования
        /// </summary>
        [TestMethod]
        public void CheckEquipment_IsFalse()
        {
            Assert.IsFalse(CheckFieldsClass.CheckEquipment("Смартфон", "11111111", null));
        }

        /// <summary>
        /// Положительный тест на проверку полей для добавления оборудования
        /// </summary>
        [TestMethod]
        public void CheckSpareParts_IsTrue()
        {
            Assert.IsTrue(CheckFieldsClass.CheckSpareParts(new OrderTable(), "Аккумулятор", "https://ngknn.ru/", "2"));
        }

        /// <summary>
        /// Негативный тест на проверку полей для добавления оборудования
        /// </summary>
        [TestMethod]
        public void CheckSpareParts_IsFalse()
        {
            Assert.IsFalse(CheckFieldsClass.CheckSpareParts(new OrderTable(), "Аккумулятор", "https://ngknn.ru/", "a1"));
        }

        /// <summary>
        /// Положительный тест на проверку полей для приема оборудования
        /// </summary>
        [TestMethod]
        public void CheckAcceptEquipment_IsTrue()
        {
            Assert.IsTrue(CheckFieldsClass.CheckAcceptEquipment(new EquipmentTable(), "Аккумулятор", "Треснул экран", new ClientTable()));
        }

        /// <summary>
        /// Негативный тест на проверку полей для приема оборудования
        /// </summary>
        [TestMethod]
        public void CheckAcceptEquipment_IsFalse()
        {
            Assert.IsFalse(CheckFieldsClass.CheckAcceptEquipment(null, "Аккумулятор", "Треснул экран", new ClientTable()));
        }

        /// <summary>
        /// Положительный тест на проверку полей для выдачи оборудования
        /// </summary>
        [TestMethod]
        public void CheckIssueEquipment_IsTrue()
        {
            Assert.IsTrue(CheckFieldsClass.CheckIssueEquipment(new OrderTable(), "Треснул экран", new List<CostOfWork>()));
        }

        /// <summary>
        /// Негативный тест на проверку полей для выдачи оборудования
        /// </summary>
        [TestMethod]
        public void CheckIssueEquipment_IsFalse()
        {
            Assert.IsFalse(CheckFieldsClass.CheckIssueEquipment(null, "Треснул экран", new List<CostOfWork>()));
        }
    }
}
