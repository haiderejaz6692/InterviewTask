Feature: Current weather data Functionality

OpenWeather have different open API's with limited access
i've picked Very First endpoint which provide Current Weather Data to user.


Background:
	Given Set up a base url as 'https://api.openweathermap.org/data/2.5/'

@BonusReq
Scenario: Verify API Authentication and Required Params
	When Set App Id "<App_Id>"
	And Set Coordinates Longitude "<long>" latitude "<lati>"
	Then Verify Status code "<Status_Code>"
	Then Verify Status Message "<Status_Message>"

	Examples: 
	| App_Id                           | long  | lati  | Status_Code | Status_Message                                                                    |
	| 52bfc68578a292f826daa5350cf469e3 | 139   | 35    | 200         | OK                                                                                |
	| wrongId                          | 139   | 35    | 401         | Invalid API key. Please see http://openweathermap.org/faq#error401 for more info. |
	| 52bfc68578a292f826daa5350cf469e3 | wrong | 35    | 400         | wrong longitude                                                                   |
	| 52bfc68578a292f826daa5350cf469e3 | 139   | wrong | 400         | wrong latitude                                                                    |


Scenario: Verify API Response
	When Set App Id "<App_Id>"
	And Set Coordinates Longitude "<long>" latitude "<lati>"
	Then Verify Status code "<Status_Code>"
	Then Verify Response Coordinates Longitude "<long>" latitude "<lati>"
	Then Verify Country "<Country>"
	Then Verify Weather Should not empty
	Then Verify main temprature pressure humidity should not empty or null

	Examples: 
	| App_Id                           | long | lati | Status_Code | Country |
	| 52bfc68578a292f826daa5350cf469e3 | 139  | 35   | 200         | JP      |