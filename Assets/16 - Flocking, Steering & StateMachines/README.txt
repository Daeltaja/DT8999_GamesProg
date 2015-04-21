Hey!

So I have set up a little scenario here where the boids switch between 3 different states every 5 seconds.

States:
ChaseState
PatrolState
TrackState 

If you select the boids in the scene, you will notice that they have both the SteeringBehaviour and State Machine scripts attached.
For any boids or agents you want to control with steering behaviours and a state machine, they need both of these scripts.

The next step is to create any states you like. I created the 3 listed above. You do not add these manually to the boids in your scene, they are loaded on and off by the State Machine script.

We of course need some way to give our boids an initial state, so I created a GameManager script that takes care of this. It is attached to a GameManager gameobject in the scene.
In this script, I store all of the boids in an array. I also run a foreach loop, giving each boid a starting State. In this case, it is the ChaseState. 
For the leader, I gave it a PatrolState.
We also have it set up so that we have to pass over my gameobject, so that we can access it in the State itself (State.cs does not derive from Monobehaviour, so we can't access gameObject like we normally would, hence passing it over in the SwitchState method)
You will notice the boids and leader in the scene have no behaviours turned on by default. The States take care of that!

You can look through my 3 states and see how they work.

Each state has an Enter, Update and Exit.
In the Enter method, we turn on the steering behaviours we want. We can also find references to other gameobjects (such as a leader, target, whatever) at this point.
In the Update method, we check the condition for switching to a new state. In the example cases, I simply run a timer, that when it hits 5 seconds, it switches states.
You can of course run more complicated calculations here, such as boids that have field of view, or line of sight, which then switches state when an enemy comes into view.
In the Exit method, we simply turn off all steering behaviours associated with this state, as the new state will toggle on the ones it wants.
I wrote a simple TurnOfAll() method in the SteeringBehaviours script which disables all bools.

That's it! 

