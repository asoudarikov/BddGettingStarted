Feature: Client Call Stats Tests

#@mytag
#Scenario: Add two numbers
#    Given the first number is 50
#    And the second number is 70
#    When the two numbers are added
#    Then the result should be 120

Scenario: Test custom step argument type converter that support NULL conversion
    When I get value NULL
    Then value should be null