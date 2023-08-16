Feature: Login And Logout
    guest user can login and logout

@UI
Scenario: A user should be able to login and logout
    Given a guest user that not logged in
    When user logs into the system
    Then Main page with username appears
    When user logs out from system
    Then user is redirected to main page