Feature: Customers

  Scenario: Search customer
    Given I am on the banking website
    When I select "Login as Bank Manager" option
    Then I click "Customers" to see a list of customers
    When I search a peson by first name
    Then I should see a person with this first name
    When I search a peson by last name
    Then I should see a person with this last name
    When I search a peson by postcode
    Then I should see a person with this postcode
    When I search a peson by account number
    Then I should see a person with this account number
    #Then I should see an error message
    Then I should close Chrome