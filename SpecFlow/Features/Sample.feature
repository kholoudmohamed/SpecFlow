Feature: Login
	Test AAMLive login feature

@SmokeTest
Scenario: Valid Login
	Given I visited login page
	And I have entered username and password
	| username   | Password   |
	| testtrader | eServices1 |
	When I press login
	Then I should be logged in
	And My Test Trader Test Trader displayed at the header
