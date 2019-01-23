# TNM095-AI-Flocking

Duck Flocking Simulation using Craig Reynold's **Boids algorithm** (Ref: https://www.red3d.com/cwr/boids/) implemented in Unity.
The aim of the project was to learn more about how to implement artificial behaviour to use e.g. in games or simulations.  

In addition to the flocking implementation, the project includes a simple **finite-state machine** implementation that can be built upon or extended to create more complex behaviour. 

The current behaviour of the ducks in the simulation includes:
- flocking (walking around aimlessly)
- targetting food
- avoiding enemies (the player)

**Demo image of resulting flocking:**
<br/>
<br/>
![demo of ducks](/DemoAssets/Flocking.png)
<br/>

**Demo image of state machine in action:**
<br/>
![demo of ducks and state machine](/DemoAssets/DemoPic2.png)

The player (white sphere) is moving towards the right, making the boids that it is moving towards enter the "flee" state. This is represented by the gizmo (wired sphere) changing color from green to red, as shown in the left image. 
