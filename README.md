# How to Run

Open the .SLN inside of visual studio and run the preojct, it should be configured by default. If it fails set the startup project to be Playground

## Components of the Console App

Asks the user for the weight as well as the to and from postcode. Contains retry logic for when the user inputs an invalid weight or post code. 
I consider an invalid postcode to be anything thats not an integer and the weight being anything that is not a valid double.

## Structure

Simple console app that is just split into two projects, Playground and Playground.UnitTests, dont take note of the project names, its just a default starter template.

Tests are very light, as I only had about an hour in total to write the app

## Playground project structure

The playground project structure is split into 3 main parts for its logic:

- InputHandler, which handles all user input and validation logic
- OutputHandler, which handles all output to the user and output logic
- RateCalculator, which handles the rate calculation logic

## Where does it get its data from

The app gets its event data fed into it from events.json