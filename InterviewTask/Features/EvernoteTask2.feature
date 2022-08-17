Feature: Evernote Online Notes Functionality


@Task2
Scenario: Verify User Can Login To App With Right Credentials
	Given User Lands On Login Page
	When User Enters Email "<username>"
	Then User Clicks on Continue/Login Button
	Then Verify user "<exists>"
	And User Enters Password "<password>" and Login if user "<exists>"

	Examples: 
	| username                | password  | exists     |
	| m.haider.ijaz@gmail.com | Habcd5432 | exists     |
	| random@testMail.com     | test      | not Exists |

@Task2
Scenario: Verify Created Notes should be visible to the user even after logout
	Given User Lands On Login Page
	When User Enters Email "<username>"
	Then User Clicks on Continue/Login Button
	Then User Enters Password "<password>"
	Then User Clicks on Continue/Login Button
	Then User navigate to Notes
	Then User clicks add notes button
	Then Add Notes Title "<title>"
	Then Add Notes Description "<description>"
	Then User Logout the session
	Then User Navigate to Login Page
	When User Enters Email "<username>"
	Then User Clicks on Continue/Login Button
	Then User Enters Password "<password>"
	Then User Clicks on Continue/Login Button
	Then User navigate to Notes
	Then Verify Created Note with Title "<title>" and Description "<description>"
	And Move it to trash

	Examples: 
	| username                | password  | title                       | description                                       |
	| m.haider.ijaz@gmail.com | Habcd5432 | Evernote Functionality Test | Created Notes should be visible even after logout |