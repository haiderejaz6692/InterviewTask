Feature: To Verify Users API

Background:
	Given I set up a base url as 'https://reqres.in/'

@Task1
Scenario: Get user list and verify particular user
    When I send a Get user list request from page "<Page_No>"
    Then Verify Response code is "<Status_Code>"
    Then Verify it returns "<User_Count>" users in total as response
    Then Verify Page No "<Page_No>" 
    Then Verify result contains user FirstName "<First_Name>"
    Then Verify result contains user LastName "<Last_Name>"
    Then Verify result contains user Email "<Email>"
    Then Verify result contains user Avatar "<Avatar>"

    Examples: 
    | Page_No | Status_Code | User_Count | First_Name | Last_Name | Email                  | Avatar                                   |
    | 1       | 200         | 6          | Janet      | Weaver    | janet.weaver@reqres.in | https://reqres.in/img/faces/2-image.jpg  |
    | 2       | 200         | 6          | Byron      | Fields    | byron.fields@reqres.in | https://reqres.in/img/faces/10-image.jpg |

@Task1
Scenario: Verify Users on Page
    When I send a Get user list request from page "<Page_No>"
    Then Verify Response code is "<Status_Code>"
    Then Verify Page No "<Page_No>"
    Then Verify it returns "<User_Count>" users in total as response
    
    Examples: 
    | Page_No | Status_Code | User_Count |
    | 12      | 200         | 0          |
    | 1       | 200         | 6          |
