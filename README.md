# GDIM33 Vertical Slice
## Milestone 1 Devlog
One visual scripting graph in my game is the Midday graph. This graph is what runs during the daytime state of the game. This handles the button clicking minigame, which is still a work-in-progress. On entering this state, it takes the background image and changes it to the daytime image. It also sets active the canvas GameObject containing the UI for the minigame. It uses an On Button Click event, and, when clicking the Money Button, increases the Money Int variable by 1. the On Update Event changes the Money Int variable to a string and puts it after the string "Money amount: ", and then sets the text of the Money Amount TMP in the scene to that string. The end result is that, each time you click the money button, it updates the number on the screen to show you how much money you have, increasing by one each time.


<img width="1000" height="650" alt="Vertical Slice Breakdown" src="https://github.com/user-attachments/assets/d1cf08fc-bc2d-4b40-a8ed-31fc4bfc0886" />
This is my new breakdown. It includes the state machine I am now using to switch between morning, day, and night. My state machine works to switch between different times of day after certain events. In the morning, you might go through a series of dialogue nodes, and then progress to going to work. This switches the game state to the daytime section. Here, you play a money earning minigame as you are at work, trying to click a button as many times as possible before the timer runs out. Once the timer runs out, it transitions to the night state. Each state also has a different background.


This works with the other systems in my game because the day and night states use the dialogue system to display dialogue and change relationship levels based on that, keeping track of different choices you make and displaying sprites and dialogue lines. During the day, the other system of the minigame is switched on and the dialogue system is turned off. The state machine basically switches between mutually exclusive states that utilize different gameplay systems.


## Milestone 2 Devlog

My complicating gameplay feature is that after the end of the day, the child character begins to change into a different creature depending on the relationship level changes that have resulted from your decisions. This is my task breakdown:
1. Create a state machine for the different days
- Make the transition event in code and trigger it in the state graph through dialogue nodes
- In the on enter event of the next day state, check friendship levels and trigger a different route based on comparing the different friendship level values
2. Change the character’s appearance and dialogue routes based on the new development in relationship
- Add the character as a model with different meshes for the different facial features
- Program the feature swapping mechanic and implement it in the dialogue node options
- Create dialogue nodes that have different story outcomes for the changing effects of the next day
- Implement new physical features that are different based on the relationship branches


The task steps break-down activity did help me build the feature for this Milestone. The quiz question did not really help me because I ended up changing the feature from what I wrote about in the quiz to something else. If I were to improve my break-downs to be more helpful, I would probably re-order them to do more specific things step-by-step rather than broad tasks narrowing down, since that’s the way I have been finding that my thinking functions better.


I bridged visual scripting and code in my game by calling a custom event from a Graph from a C# method. The event I am calling triggers a transition to the next day state, meaning it switches from Day 1 to Day 2. This is triggered in a method within my dialogue manager script, when an enum variable is set to a day value. Once the visual scripting state machine transitions to the day 2 state, it immediately compares relationship level values in order to determine which dialogue node to trigger. This allows me to handle the logic and execution of the complicating factor and the system of multiple days separately from the main dialogue manager, which will only handle moving through and between dialogue nodes. Below is an image of the graph. It is triggered in the DialogueManager script on line 391, in the method SelectedOption().

<img width="850" height="280" alt="Screenshot 2026-05-14 215126" src="https://github.com/user-attachments/assets/0af0d222-6ee6-4a8c-8ad3-7cb928fbbea0" />


I would like my project to be graded on ScriptableObjects. This can be found in the dialogue system, as it transitions between dialogue nodes, as well as in the relationship system, which uses ScriptableObjects to create relationship variables that are altered in the dialogue nodes. The values of these relationship variables at the end of the day determine new changes that appear in the next day.

## Milestone 3 Devlog
Milestone 3 Devlog goes here.
## Milestone 4 Devlog
Milestone 4 Devlog goes here.
## Final Devlog
Final Devlog goes here.
## Open-source assets
- Cite any external assets used here!
