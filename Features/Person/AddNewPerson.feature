Feature: Add new student

    As a new student
    I need to create a student account
    So that I can enroll in a new academic term

    Background: 
        Given a person who is new to the school

    Scenario: New person is added to system
        When a first and last name is submitted
        Then as new person is added to the system