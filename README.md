# GDIM33 Vertical Slice
## Milestone 1 Devlog
One visual scripting graph in my game is the Midday graph. This graph is what runs during the daytime state of the game. This handles the button clicking minigame, which is still a work-in-progress. On entering this state, it takes the background image and changes it to the daytime image. It also sets active the canvas GameObject containing the UI for the minigame. It uses an On Button Click event, and, when clicking the Money Button, increases the Money Int variable by 1. the On Update Event changes the Money Int variable to a string and puts it after the string "Money amount: ", and then sets the text of the Money Amount TMP in the scene to that string. The end result is that, each time you click the money button, it updates the number on the screen to show you how much money you have, increasing by one each time.


<img width="1000" height="650" alt="Vertical Slice Breakdown" src="https://github.com/user-attachments/assets/eaac66b2-46f9-43d1-ba94-c60bbecf3827" />
This is my new breakdown. It includes the state machine I am now using to switch between morning, day, and night. My state machine works to switch between different times of day after certain events. In the morning, you might go through a series of dialogue nodes, and then progress to going to work. This switches the game state to the daytime section. Here, you play a money earning minigame as you are at work, trying to click a button as many times as possible before the timer runs out. Once the timer runs out, it transitions to the night state. Each state also has a different background.


This works with the other systems in my game because the day and night states use the dialogue system to display dialogue and change relationship levels based on that, keeping track of different choices you make and displaying sprites and dialogue lines. During the day, the other system of the minigame is switched on and the dialogue system is turned off. The state machine basically switches between mutually exclusive states that utilize different gameplay systems.


## Milestone 2 Devlog
Milestone 2 Devlog goes here.
## Milestone 3 Devlog
Milestone 3 Devlog goes here.
## Milestone 4 Devlog
Milestone 4 Devlog goes here.
## Final Devlog
Final Devlog goes here.
## Open-source assets
- Cite any external assets used here!
