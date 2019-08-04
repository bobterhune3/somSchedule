# somSchedule

This project will generate a Strat-o-matic schedule from a template and configuration file then print out the output to verify it's balanced.

## What this program does
SOM allows you to generate your own schedule, but it can be difficult and painful to get it right.   This program allows you to generate a one time template and you can rebuild a league schedule as often as you want.
  * Maybe your league has a Soccer style tierd concept where teams move up and down leagues based on performance.
  * Maybe you want to manipulate the schedule so the best teams face off at the end of the season.
  * Maybe you just want to mix up the schedule so the same teams don't play each other at the same point in the schedule every year.
  
## How does it work.
This program uses a simple search and replace algorhytm to build a schedule out of a template.   You assign each team a general code that matches an entry in the schedule and run this program.  Out comes a schedule ready for import in the SOM game!

## Getting Started.
Build a schedule in the SOM format.  The easiest way to start is to export an example schedule from the game

### Looking at a schedule Tempalte
* From Strat-O-Matic Baseball game.  Select the League | Schedule Maintenance Menu item.
* Then hit the export button.  This will add a file name YearLeague.TXT to the export directory

### Expected Layout of the template
One line per game.  There are four columns.  
Day Number, Away Team, Home Team, Day or Night game (D or N)
 - Day Number = 1= April 2nd, then number can range from 1 to 250 (Dec 7)
 - Away Team = This is the game abbreviation assigned to the team
 - Home Team = This is the game abbreviation assigned to the team
 - Day or Night = This value should be D or N, and determines if it is a day or night game

### STEP ONE - Define your codes.
Codes are just a generic way to identify a schedule slot.   
For example:
  AE1, AW1, NW1, NE1

### STEP TWO - Create a team lookup file
In a text editor create a file named **ScheduleConfig.txt**
The contents of the file will assign the teams to codes
For example:
```  AE1=NYA
  AE2=BAA
  AE3=TOA
  AE4=TBA
  AE5=BOA
  AW1=DEA
  ```
You will want to list each team and make sure the team abbreviation is exactly what shows in the Standings Report

### STEP THREE - Create your schedule.
This is the hard part.  The important part is to create the schedule using the Generic Codes you just defined in Step Two
Name the file you created **ScheduleTemplate.csv**
Keep this file in a safe place.  You can reuse this template year after year.

### STEP FOUR - Run the program
Copy the **ScheduleConfig.txt** and **ScheduleTemplate.csv** files into the directory you copied this program to.
An example of both of these files are included in the "example" directory of this project
To run just run the `somSchedule` program.

### STEP FIVE - Review the results
Unless there is an error. A report will be generated to the screen.  Errors are often caused by a file input file is not located in the correct location
```
  MLG: 162/ 81H-81A days off=22, day games=58
 VVVVHHH HHHHHV VVVVVVVHHHVVVHHHVV VHHHVVVHHHVV VHHHVVVHHHVVVHH VVHH HHVV   VVVHH HHHH VVVVVVHHHV VVHHHH HHVVV   VVH HHHV VVVVVVVVVHHHHH HHHHHHHHHH VVVHHHVVVVVVVVVHHHHVVVVHH HHHHHHVVVV
    vs TXG/ 9H-9A
    vs DTB/ 9H-9A
    vs TOG/ 9H-9A
    vs CLM/ 9H-9A
    vs WSG/ 9H-9A
    vs SDG/ 3H-3A
    vs SEG/ 3H-3A
    vs PTB/ 3H-3A
    vs SLB/ 3H-3A
    vs NYB/ 3H-3A
    vs OKM/ 3H-3A
    vs TBM/ 3H-3A
    vs PHM/ 3H-3A
    vs AZB/ 3H-3A
    vs KCM/ 3H-3A
    vs CHB/ 3H-3A
    vs LAM/ 3H-3A
 ```
 This report will help you verify the schedule you generated is what you expect.
 The first like is
 ***LINE ONE***: TEAM: TOTAL GAMES/ HOME GAMES-AWAY GAMES / Days off count, Day Game count
 ***LINE TWO***: The series schedule, with days off.  This `VVVVHHH HHHHHV` show 4 Away games then 3 home games, one day of per space, then a 5 home games and an away game.
 ***THE REST***: How many home and away games against each team in your league.  This helps when you have an unbalanced schedule.
 
 ### STEP SIX - Import the schedule file into your league!
 A file named #scheduleOut.TXT# will have been generated.
 You can optionally make a copy of this file and call it CSV if you want to look at the generated file in Excel.
 
 From the SOM Baseball game.  
  1. Select the League you want to import the schedule into
  2. You may have to Restart the League if some games have been played
  3. From the Schedule Maintenance Dialog there will be an IMPORT button
  4. Use the file browse dialog to point to the #scheduleOut.TXT# that you generated.
  
 ### STEP SEVEN - PLAY BALL!
 Remember, you can regenerate new leagues each season using the same template by only updating the #ScheduleConfig.txt# file.
 
  
  
