Feature: SwitchLanguage
  Switch to different languages

Scenario: Switch between different language on Wikipedia
  Given the user is on the Wikipedia website
  When the user switches to Russian language
  Then the page language should be Russian
  When the user switches to English language
  Then the page language should be English
  When the user switches to Uzbek language
  Then the page language should be Uzbek