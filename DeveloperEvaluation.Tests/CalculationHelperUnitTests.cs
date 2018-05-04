using System;
using System.Collections.Generic;
using DeveloperEvaluation.Util;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DeveloperEvaluation.Tests
{
    [TestClass]
    public class CalculationHelperUnitTests
    {
        [TestMethod]
        public void TestCalculations_AllPositiveIntegers_Odd()
        {
            CalculationHelper calc = new CalculationHelper(generateTestData_AllPositiveIntegers_Odd());
            CalculationDTO dto = calc.Calculate();

            Assert.IsNotNull(dto.mean);
            Assert.IsNotNull(dto.median);
            Assert.IsNotNull(dto.mode);

            Assert.AreEqual(26.2, dto.mean);
            Assert.AreEqual(25, dto.median);

            List<double> testMode = new List<double>() { 12 };
            for(var i = 0; i < dto.mode.Count; i++)
            {
                Assert.AreEqual(testMode[i], dto.mode[i]);
            }

        }

        [TestMethod]
        public void TestCalculations_AllPositiveIntegers_Even()
        {
            CalculationHelper calc = new CalculationHelper(generateTestData_AllPositiveIntegers_Even());
            CalculationDTO dto = calc.Calculate();

            Assert.IsNotNull(dto.mean);
            Assert.IsNotNull(dto.median);
            Assert.IsNotNull(dto.mode);

            Assert.AreEqual(36.75, dto.mean);
            Assert.AreEqual(28.5, dto.median);

            List<double> testMode = new List<double>() { 12, 75 };
            for (var i = 0; i < dto.mode.Count; i++)
            {
                Assert.AreEqual(testMode[i], dto.mode[i]);
            }
        }

        [TestMethod]
        public void TestCalculations_AllNegativeIntegers_Odd()
        {
            CalculationHelper calc = new CalculationHelper(generateTestData_AllNegativeIntegers_Odd());
            CalculationDTO dto = calc.Calculate();

            Assert.IsNotNull(dto.mean);
            Assert.IsNotNull(dto.median);
            Assert.IsNotNull(dto.mode);

            Assert.AreEqual(-32.285714285714285, dto.mean);
            Assert.AreEqual(-32, dto.median);

            List<double> testMode = new List<double>() { -12, -50 };
            for (var i = 0; i < dto.mode.Count; i++)
            {
                Assert.AreEqual(testMode[i], dto.mode[i]);
            }
        }

        [TestMethod]
        public void TestCalculations_AllNegativeIntegers_Even()
        {
            CalculationHelper calc = new CalculationHelper(generateTestData_AllNegativeIntegers_Even());
            CalculationDTO dto = calc.Calculate();

            Assert.IsNotNull(dto.mean);
            Assert.IsNotNull(dto.median);
            Assert.IsNotNull(dto.mode);

            Assert.AreEqual(-34.333333333333336, dto.mean);
            Assert.AreEqual(-28.5, dto.median);

            List<double> testMode = new List<double>() { -12 };
            for (var i = 0; i < dto.mode.Count; i++)
            {
                Assert.AreEqual(testMode[i], dto.mode[i]);
            }
        }

        [TestMethod]
        public void TestCalculations_AllPositiveDecimals_Odd()
        {
            CalculationHelper calc = new CalculationHelper(generateTestData_AllPositiveDecimals_Odd());
            CalculationDTO dto = calc.Calculate();

            Assert.IsNotNull(dto.mean);
            Assert.IsNotNull(dto.median);
            Assert.IsNotNull(dto.mode);

            Assert.AreEqual(0.4072864, dto.mean);
            Assert.AreEqual(0.234, dto.median);

            List<double> testMode = new List<double>() { 0.234 };
            for (var i = 0; i < dto.mode.Count; i++)
            {
                Assert.AreEqual(testMode[i], dto.mode[i]);
            }

        }

        [TestMethod]
        public void TestCalculations_AllPositiveDecimals_Even()
        {
            CalculationHelper calc = new CalculationHelper(generateTestData_AllPositiveDecimals_Even());
            CalculationDTO dto = calc.Calculate();

            Assert.IsNotNull(dto.mean);
            Assert.IsNotNull(dto.median);
            Assert.IsNotNull(dto.mode);

            Assert.AreEqual(0.5355599999999999, dto.mean);
            Assert.AreEqual(0.59793, dto.median);

            List<double> testMode = new List<double>() { 0.234, 0.7101 };
            for (var i = 0; i < dto.mode.Count; i++)
            {
                Assert.AreEqual(testMode[i], dto.mode[i]);
            }

        }

        [TestMethod]
        public void TestCalculations_AllNegativeDecimals_Odd()
        {
            CalculationHelper calc = new CalculationHelper(generateTestData_AllNegativeDecimals_Odd());
            CalculationDTO dto = calc.Calculate();

            Assert.IsNotNull(dto.mean);
            Assert.IsNotNull(dto.median);
            Assert.IsNotNull(dto.mode);

            Assert.AreEqual(-0.3663464, dto.mean);
            Assert.AreEqual(-0.234, dto.median);


            List<double> testMode = new List<double>() { -0.234, -0.018932, -0.8394, -0.7101, -0.0293 };
            for (var i = 0; i < dto.mode.Count; i++)
            {
                Assert.AreEqual(testMode[i], dto.mode[i]);
            }
        }

        [TestMethod]
        public void TestCalculations_AllNegativeDecimals_Even()
        {
            CalculationHelper calc = new CalculationHelper(generateTestData_AllNegativeDecimals_Even());
            CalculationDTO dto = calc.Calculate();

            Assert.IsNotNull(dto.mean);
            Assert.IsNotNull(dto.median);
            Assert.IsNotNull(dto.mode);

            Assert.AreEqual(-0.3862486666666667, dto.mean);
            Assert.AreEqual(-0.35988000000000003, dto.median);

            List<double> testMode = new List<double>() { -0.234, -0.018932, -0.8394, -0.7101, -0.0293, -0.48576 };
            for (var i = 0; i < dto.mode.Count; i++)
            {
                Assert.AreEqual(testMode[i], dto.mode[i]);
            }
        }

        [TestMethod]
        public void TestCalculations_MixedBag_Odd()
        {
            CalculationHelper calc = new CalculationHelper(generateTestData_MixedBag_Odd());
            CalculationDTO dto = calc.Calculate();

            Assert.IsNotNull(dto.mean);
            Assert.IsNotNull(dto.median);
            Assert.IsNotNull(dto.mode);

            Assert.AreEqual(164122.13748818, dto.mean);
            Assert.AreEqual(0.0328409, dto.median);

            List<double> testMode = new List<double>() { -19304.273, 838984, 0.0328409, -0.0204, 930.948 };
            for (var i = 0; i < dto.mode.Count; i++)
            {
                Assert.AreEqual(testMode[i], dto.mode[i]);
            }

        }

        [TestMethod]
        public void TestCalculations_MixedBag_Even()
        {
            CalculationHelper calc = new CalculationHelper(generateTestData_MixedBag_Even());
            CalculationDTO dto = calc.Calculate();

            Assert.IsNotNull(dto.mean);
            Assert.IsNotNull(dto.median);
            Assert.IsNotNull(dto.mode);

            Assert.AreEqual(104594.44790681665, dto.mean);
            Assert.AreEqual(0.006220449999999999, dto.median);


            List<double> testMode = new List<double>() { -19304.273, 838984, 0.0328409, -0.0204, 930.948, -193044 };
            for (var i = 0; i < dto.mode.Count; i++)
            {
                Assert.AreEqual(testMode[i], dto.mode[i]);
            }

        }

        #region data generators
        private string[] generateTestData_AllPositiveIntegers_Odd()
        {
            return new string[] {
                "25",
                "12",
                "12",
                "32",
                "50"
            };
        }

        private string[] generateTestData_AllPositiveIntegers_Even()
        {
            return new string[]
            {
                "25",
                "12",
                "12",
                "32",
                "50",
                "75",
                "75",
                "13"
            };
        }

        private string[] generateTestData_AllNegativeIntegers_Odd()
        {
            return new string[]
            {
                "-25",
                "-12",
                "-12",
                "-32",
                "-50",
                "-50",
                "-45"
            };
        }

        private string[] generateTestData_AllNegativeIntegers_Even()
        {
            return new string[]
            {
                "-25",
                "-12",
                "-12",
                "-32",
                "-50",
                "-75"
            };
        }

        private string[] generateTestData_AllPositiveDecimals_Odd()
        {
            return new string[]
            {
                ".234",
                ".018932",
                ".83940",
                ".7101",
                ".234"
            };
        }

        private string[] generateTestData_AllPositiveDecimals_Even()
        {
            return new string[]
            {
                ".234",
                ".7101",
                ".83940",
                ".7101",
                ".234",
                ".48576"
            };
        }

        private string[] generateTestData_AllNegativeDecimals_Odd()
        {
            return new string[]
            {
                "-.234",
                "-.018932",
                "-.83940",
                "-.7101",
                "-.0293"
            };
        }

        private string[] generateTestData_AllNegativeDecimals_Even()
        {
            return new string[]
            {
                "-.234",
                "-.018932",
                "-.83940",
                "-.7101",
                "-.0293",
                "-.48576"
            };
        }

        private string[] generateTestData_MixedBag_Odd()
        {
            return new string[]
            {
                "-19304.273",
                "838984",
                ".0328409",
                "-.0204",
                "930.948"
            };
        }

        private string[] generateTestData_MixedBag_Even()
        {
            return new string[]
            {
                "-19304.273",
                "838984",
                ".0328409",
                "-.0204",
                "930.948",
                "-193044"
            };
        }
    }
}
#endregion