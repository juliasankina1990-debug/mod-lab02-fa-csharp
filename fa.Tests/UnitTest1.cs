using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using fans;

namespace NET
{
    [TestClass]
    public class UnitTest1
    {

        // ========== Существующие тесты (11 шт) ==========
        [TestMethod]
        public void TestMethod1()
        {
            string s = "0111";
            FA1 fa = new FA1();
            bool? result = fa.Run(s);
            Assert.IsTrue(result == true);
        }
        [TestMethod]
        public void TestMethod2()
        {
            string s = "01011";
            FA1 fa = new FA1();
            bool? result = fa.Run(s);
            Assert.IsTrue(result == false);
        }
        [TestMethod]
        public void TestMethod3()
        {
            string s = "110101011";
            FA1 fa = new FA1();
            bool? result = fa.Run(s);
            Assert.IsTrue(result == false);
        }
        [TestMethod]
        public void TestMethod4()
        {
            string s = "1110111";
            FA1 fa = new FA1();
            bool? result = fa.Run(s);
            Assert.IsTrue(result == true);
        }
        [TestMethod]
        public void TestMethod5()
        {
            string s = "10";
            FA1 fa = new FA1();
            bool? result = fa.Run(s);
            Assert.IsTrue(result == true);
        }
        [TestMethod]
        public void TestMethod6()
        {
            string s = "0101";
            FA2 fa = new FA2();
            bool? result = fa.Run(s);
            Assert.IsTrue(result == false);
        }
        [TestMethod]
        public void TestMethod7()
        {
            string s = "00110011";
            FA2 fa = new FA2();
            bool? result = fa.Run(s);
            Assert.IsTrue(result == false);
        }
        [TestMethod]
        public void TestMethod8()
        {
            string s = "0001";
            FA2 fa = new FA2();
            bool? result = fa.Run(s);
            Assert.IsTrue(result == true);
        }
        [TestMethod]
        public void TestMethod9()
        {
            string s = "111000";
            FA2 fa = new FA2();
            bool? result = fa.Run(s);
            Assert.IsTrue(result == true);
        }
        [TestMethod]
        public void TestMethod10()
        {
            string s = "00110011";
            FA3 fa = new FA3();
            bool? result = fa.Run(s);
            Assert.IsTrue(result == true);
        }
        [TestMethod]
        public void TestMethod11()
        {
            string s = "0101";
            FA3 fa = new FA3();
            bool? result = fa.Run(s);
            Assert.IsTrue(result == false);
        }

        // ========== Новые тесты (12 шт, всего 23) ==========
        [TestMethod]
        public void FA1_Test_NoZero()
        {
            FA1 fa = new FA1();
            Assert.IsFalse(fa.Run("111") == true);
        }
        [TestMethod]
        public void FA1_Test_TwoZeros()
        {
            FA1 fa = new FA1();
            Assert.IsFalse(fa.Run("00111") == true);
        }
        [TestMethod]
        public void FA1_Test_OnlyZero()
        {
            FA1 fa = new FA1();
            Assert.IsFalse(fa.Run("0") == true);
        }
        [TestMethod]
        public void FA1_Test_ExactlyOneZeroAndOneOne()
        {
            FA1 fa = new FA1();
            Assert.IsTrue(fa.Run("01") == true);
        }
        [TestMethod]
        public void FA1_Test_EmptyString()
        {
            FA1 fa = new FA1();
            Assert.IsFalse(fa.Run("") == true);
        }

        [TestMethod]
        public void FA2_Test_OneZeroOneOne()
        {
            FA2 fa = new FA2();
            Assert.IsTrue(fa.Run("01") == true);
        }
        [TestMethod]
        public void FA2_Test_ThreeZerosTwoOnes()
        {
            FA2 fa = new FA2();
            // 3 нуля (нечёт), 2 единицы (чёт) -> false
            Assert.IsFalse(fa.Run("00011") == true);
        }
        [TestMethod]
        public void FA2_Test_ThreeZerosThreeOnes()
        {
            FA2 fa = new FA2();
            Assert.IsTrue(fa.Run("000111") == true);
        }
        [TestMethod]
        public void FA2_Test_OnlyOneZero()
        {
            FA2 fa = new FA2();
            Assert.IsFalse(fa.Run("0") == true);
        }
        [TestMethod]
        public void FA2_Test_OnlyOneOne()
        {
            FA2 fa = new FA2();
            Assert.IsFalse(fa.Run("1") == true);
        }

        [TestMethod]
        public void FA3_Test_Contains11_AtStart()
        {
            FA3 fa = new FA3();
            Assert.IsTrue(fa.Run("110") == true);
        }
        [TestMethod]
        public void FA3_Test_Contains11_AtEnd()
        {
            FA3 fa = new FA3();
            Assert.IsTrue(fa.Run("011") == true);
        }
        [TestMethod]
        public void FA3_Test_Contains11_Overlap()
        {
            FA3 fa = new FA3();
            Assert.IsTrue(fa.Run("111") == true);
        }
        [TestMethod]
        public void FA3_Test_No11_Alternating()
        {
            FA3 fa = new FA3();
            Assert.IsFalse(fa.Run("101010") == true);
        }
        [TestMethod]
        public void FA3_Test_Empty()
        {
            FA3 fa = new FA3();
            Assert.IsFalse(fa.Run("") == true);
        }
    }
}
