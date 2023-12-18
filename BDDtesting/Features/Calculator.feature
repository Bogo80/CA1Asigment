Feature: BloodPressureCalculator
    
Scenario: High Blood Pressure
    Given I have entered 150 as systolic value
    And I have entered 95 as diastolic value
    When I calculate my blood pressure category
    Then the result should be High

Scenario: Ideal Blood Pressure
    Given I have entered 115 as systolic value
    And I have entered 75 as diastolic value
    When I calculate my blood pressure category
    Then the result should be Ideal
