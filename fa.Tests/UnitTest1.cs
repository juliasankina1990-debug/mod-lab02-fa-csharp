using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using fans;

namespace NET
{
    [TestClass]
    public class UnitTest1
    {
        // ========== Существующие тесты (11 штук) ==========
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

        // ========== Новые тесты (12 штук, всего станет 23) ==========
        // Дополнительные тесты для FA1
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

        // Дополнительные тесты для FA2
        [TestMethod]
        public void FA2_Test_OneZeroOneOne()
        {
            FA2 fa = new FA2();
            Assert.IsTrue(fa.Run("01") == true);  // 1 ноль (нечет), 1 единица (нечет)
        }
        [TestMethod]
        public void FA2_Test_ThreeZerosTwoOnes()
        {
            FA2 fa = new FA2();
            Assert.IsTrue(fa.Run("00011") == true); // 3 нуля (нечет), 2 единицы (чет) -> false? нет, нужно нечет/нечет
            // 3 нечет, 2 чет -> false
            Assert.IsFalse(fa.Run("00011") == true);
        }
        [TestMethod]
        public void FA2_Test_ThreeZerosThreeOnes()
        {
            FA2 fa = new FA2();
            Assert.IsTrue(fa.Run("000111") == true); // 3 нечет, 3 нечет -> true
        }
        [TestMethod]
        public void FA2_Test_OnlyOneZero()
        {
            FA2 fa = new FA2();
            Assert.IsFalse(fa.Run("0") == true); // 1 нечет, 0 чет -> false
        }
        [TestMethod]
        public void FA2_Test_OnlyOneOne()
        {
            FA2 fa = new FA2();
            Assert.IsFalse(fa.Run("1") == true);
        }

        // Дополнительные тесты для FA3
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
