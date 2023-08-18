Feature: Search Testing
    As a user
    I want to be able to search for informations on the website
    So that I can find the article I need quickly and easily

   @UI
   Scenario: Search for an article with a given <searchRequest>
		Given I should see the search bar
		When I execute search with a given <searchRequest>
		Then I should see article page with <searchRequest> title
		Examples: 
		| searchRequest       |
		| "Mikhail Lomonosov" |