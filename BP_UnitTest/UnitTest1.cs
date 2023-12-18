using Microsoft.VisualStudio.TestTools.UnitTesting;
using BPCalculator;

namespace BP_UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestIdealBloodPressure()
        {
            // Test for ideal blood pressure
            var bp = new BloodPressure { Systolic = 110, Diastolic = 70 };
            Assert.AreEqual(BPCategory.Ideal, bp.Category, "Blood pressure should be categorized as Ideal");
        }

        [DataTestMethod]
        [DataRow(80, 50, BPCategory.Low)]
        [DataRow(110, 70, BPCategory.Ideal)]
        [DataRow(130, 85, BPCategory.PreHigh)]
        [DataRow(160, 95, BPCategory.High)]
        public void TestDataDrivenBloodPressure(int systolic, int diastolic, BPCategory expectedCategory)
        {
            // Data-driven test for blood pressure for data defined above 
            var bp = new BloodPressure { Systolic = systolic, Diastolic = diastolic };
            Assert.AreEqual(expectedCategory, bp.Category, $"Blood pressure with Systolic: {systolic}, Diastolic: {diastolic} should be categorized as {expectedCategory}");
        }
    }
}