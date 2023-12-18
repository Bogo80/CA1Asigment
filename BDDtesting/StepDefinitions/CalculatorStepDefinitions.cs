using System;
using TechTalk.SpecFlow;
using NUnit.Framework;
using BPCalculator;

[Binding]

public class CalculatorStepDefinitions
{
    private BloodPressure _bloodPressure = new BloodPressure();
    private BPCategory _result;

    [Given(@"I have entered (.*) as systolic value")]
    public void GivenIHaveEnteredSystolicValue(int systolic)
    {
        _bloodPressure.Systolic = systolic;
    }

    [Given(@"I have entered (.*) as diastolic value")]
    public void GivenIHaveEnteredDiastolicValue(int diastolic)
    {
        _bloodPressure.Diastolic = diastolic;
    }

    [When(@"I calculate my blood pressure category")]
    public void WhenICalculateMyBloodPressureCategory()
    {
        _result = _bloodPressure.Category;
    }

    [Then(@"the result should be (.*)")]
    public void ThenTheResultShouldBe(string category)
    {
        Assert.AreEqual(Enum.Parse(typeof(BPCategory), category), _result);
    }
}
