# EndlessRunnerTemplate
A fast made endless runner template that could be an example of how to Implement Solid Principles With Unity Development.
The scripts in this object are small, responsible for one thing, and can be used more one time at the most.
We have only one singleton for MuliInput(which responsible to handle multiplatform Inputs).
Instead of hard connections between scripts to get a value of something I used scriptable objects to store and access variables between any script.
For example, you will find RewardController.cs on Player gameo bject which is responsible for update score value and UpdateTextUIWithInt.cs on Score text gameobjet which is responsible for update score text and no hard connection between them UpdateTextUIWithInt.cs not even know who updates the score.
I used the observer design pattern but with the implementation of scriptable objects that's mean instead of  an event belongs to a custom script, any script can raise any event and any object can listen to any event that makes everything Modular, testable ,and scalable.
For example, PlayerDeath.cs on player game object raise OnPlayerDeath game event and the canvas can listen to this event by GameEventListener.cs and activate the end panel.
This gives me huge flexibility in debugging things at any time, I hadn't to wait till the player death to test this canvas I can select the OnplayerDeath game event from assets and just click Raise.
