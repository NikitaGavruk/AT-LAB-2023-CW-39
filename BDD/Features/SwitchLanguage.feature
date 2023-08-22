Feature: SwitchLanguage
	Switch to different languages as a guest user

Scenario: Switch between different languages on Wikipedia
	Given the user is on the Wikipedia web page
	When the user switches to language
	Then the page title should be expectedTitle
	Examples: 
	| language | expectedTitle |
	| "russian" | "Языковые разделы Википедии" |
	| "english" | "List of Wikipedias" |
	| "uzbek" | "Vikipediyaga" |