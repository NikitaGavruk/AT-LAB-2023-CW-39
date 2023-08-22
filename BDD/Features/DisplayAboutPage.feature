Feature: Display About page
  As a user I want to view About page when I click about link in main page

  @UI
  Scenario: About page should be displayed when user clicks about link
    Given a user logs into the account
    When user clicks about link in menu
    Then user should see the page with "Wikipedia:About" heading