﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTesting
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            string otp = null;
            bool result = MySecurityLib.Security.GetOTP(out otp);
            Assert.AreEqual(true, result);
            Assert.AreNotEqual(String.Empty, otp);

        }
        
        [TestMethod]
        public void TestMethod2()
        {
            string data = null;
            bool result = MySecurityLib.Security.Encrypt("passwrd", out data);
            Assert.AreEqual(true, result);
            Assert.AreNotEqual(String.Empty,data);

        }

        [TestMethod]
        public void TestMethod3()
        {
            string data = null;
            bool result = MySecurityLib.Security.Decrypt("/d9Iq5j6i10=", out data);
            Assert.AreEqual(true, result);
            Assert.AreNotEqual(String.Empty, data);
        }
    }
}
