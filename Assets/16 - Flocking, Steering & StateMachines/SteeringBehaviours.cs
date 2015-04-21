using UnityEngine;
using System.Collections.Generic;

/*
Weclome to Steering Behaviours with flocking! In this script, we add flocking behaviours, as well as a way to regulate the max force for each boid
*/

public class SteeringBehaviours : MonoBehaviour {

	public Vector3 force; //force - can be applied in any direction right?
	public Vector3 velocity; //direction 
	public float mass = 1f; //weight of our agent
	public float maxSpeed = 5f; //how fast it can travel
	public GameObject target; //something to steer towards!
	public Vector3 seekTargetPos;
	public bool seekEnabled, fleeEnabled, pursueEnabled, arriveEnabled, pathFollowEnabled, offsetPursuitEnabled, seperationEnabled, cohesionEnabled, alignmentEnabled; //toggle which steering behaviour you want on in the inspector!
	public Vector3 offsetPursuitOffset;
	Path path = new Path();
	private List<GameObject> tagged  = new List<GameObject>();
	public float overlapRadius = 5f;
	public float maxForce = 100f;
	public float seperationWeight = 1f, cohesionWeight = 1f, alignmentWeight = 1f; //weights we can give to our flocking behaviours (or any other behaviours at that!)
	
	void Start()
	{
		path.CreatePath(); //access the path instance and call the CreatePath method
		offsetPursuitOffset = transform.position; //set the offsetPursuitOffset vector to the starting position of each follower (it's easier 
	}
	
	public void TurnOffAll()
	{
		seekEnabled = false;
		fleeEnabled = false;
		pursueEnabled = false;
		arriveEnabled = false;
		pathFollowEnabled = false;
		offsetPursuitEnabled = false;
		seperationEnabled = false;
		cohesionEnabled = false;
		alignmentEnabled = false;
	}
	
	// Update is called once per frame
	void Update () 
	{
		ForceIntegrator();
	}

	void ForceIntegrator()
	{
		Vector3 accel = force / mass; //our accell is the accumulated force / our mass, so 
		velocity = velocity + accel * Time.deltaTime; //add the accel to our velocity over time
		transform.position = transform.position + velocity * Time.deltaTime; //set our position to our position + the velocity over time
		force = Vector3.zero; //each frame, we find the difference between self and target, and add the different to the forceAcc. We don't want this adding up to itself, so we reset it each frame and only add force once each frame to the required direction
		if(velocity.magnitude > float.Epsilon) //if we have speed
		{
			transform.forward = Vector3.Normalize(velocity); //set our forward direction to use our velocity (difference between us and target) so to always point at target
		}
		velocity *= 0.99f; //damping! each frame set veloc to 0.99 of itself, so it can slow down 
		force = CalculateWeightedPrioritised(); //return the combined steering force from enabled behaviours to our force
		NoOverlap(); //boids can't overlap
	}
	
	Vector3 CalculateWeightedPrioritised() //weight and calculate the combined forces from active steering behaviours. 
	{
		Vector3 steeringForce = Vector3.zero;
		if(seekEnabled)
		{
			force = Seek(seekTargetPos) * 0.8f;
			if(AccumulateForce(ref steeringForce, force) == false) //ref is a reference type value. We pass steeringForce to AccumulateForce, the runningTotal in that method is calculated, and returned to ref steeringForce. We also pass in the force we want to add (notice the line above, where force = SteeringBehaviour(target) etc
			{
				return steeringForce; //return the method, only returning the steeringForce at THIS POINT
			}
		}
		if(fleeEnabled)
		{
			force = Flee(target.transform.position) * 0.6f;
			if(AccumulateForce(ref steeringForce, force) == false) //if the code gets this far and Seek is also active, then we are updating steeringForce with not only the Flee force, but also the Seek force (assuming there is remaining force)
			{
				return steeringForce; 
			}
		}
		if(arriveEnabled)
		{
			force = Arrive(target.transform.position) * 0.3f; 
			if(AccumulateForce(ref steeringForce, force) == false)
			{
				return steeringForce;
			}
		}
		if(pursueEnabled)
		{
			force = Pursue(target) * 0.3f;
			if(AccumulateForce(ref steeringForce, force) == false)
			{
				return steeringForce;
			}
		}
		if(offsetPursuitEnabled)
		{
			force = OffsetPursuit(offsetPursuitOffset) * 0.6f;
			if(AccumulateForce(ref steeringForce, force) == false)
			{
				return steeringForce;
			}
		}
		if(pathFollowEnabled)
		{
			force = PathFollow() * 0.6f;
			if(AccumulateForce(ref steeringForce, force) == false)
			{
				return steeringForce;
			}
		}
		int taggedCount = 0;
		if(seperationEnabled || cohesionEnabled || alignmentEnabled)
		{
			taggedCount = TagNeighbours(50);
		}	
		if(seperationEnabled && taggedCount > 0) 
		{
			force = Seperation() * seperationWeight;
			if(AccumulateForce(ref steeringForce, force) == false)
			{
				return steeringForce; //running total
			}
		}
		if(cohesionEnabled && taggedCount > 0)
		{
			force = Cohesion() * cohesionWeight;
			if(AccumulateForce(ref steeringForce, force) == false)
			{
				return steeringForce; //running total
			}
		}
		if(alignmentEnabled && taggedCount > 0)
		{
			force = Alignment() * alignmentWeight;
			if(AccumulateForce(ref steeringForce, force) == false)
			{
				return steeringForce; //running total
			}
		}
	 	return steeringForce; //RETURN THE ACCULUMALTED FORCE VALUE FROM AccumulateForce() (This value is being read from runningTotal in that method)
	}
	
	bool AccumulateForce(ref Vector3 runningTotal, Vector3 force) //This method takes the force from the above method (eg. force = Seek(target.transform.position)) and passes it down to be checked against the remaining force available. 
	{
		float soFar = runningTotal.magnitude; //soFar is the runningTotal sum
		float remaining = maxForce - soFar; 
		if(remaining <= 0) //if there is 0 force remaining, return false, and add no more forces
		{
			return false;
		}
		float toAdd = force.magnitude; //we store the passed forces magnitude in toAdd
		if(toAdd < remaining) //if toAdd is less than what is remaining
		{
			runningTotal += force; //add the passed force to the running total
		}
		else //otherwise
		{
			runningTotal += force.normalized * remaining; //take the PART of toAdd that will bring us up to maxForce and add that to runningTotal, effectively chopping off or truncating the rest (this is why we use remaining)
		}
		return true; //return true! we can add more force
	}
	
	Vector3 Seek(Vector3 target) //This is the Seek behaviour! It returns a Vector3 to the force, which is where we steer this agent towards
	{
		Vector3 desiredVel = target - transform.position; //first we find the desired Velocity - the different between the target and ourselves. This is the vector we need to add force to, which will steer us towards our target
		desiredVel.Normalize(); //let's normalize the vector, so that it keeps it's direction but is of max length 1, so we have control over it's speed (To normalize, divide each x, y, z of the vector by it's own magnitude. Magnitude is calculated by adding the squared values of x,y,z together, then getting the squared root of the result. So (5, 0, 5) = (25, 0, 25) = 50. Square root of 50 is 7.04. This is the magnitude. To normalize, (5 / 7.04, 0 / 7.04, 5 / 7.04) = (0.71, 0, 0.71) Try one yourself!
		desiredVel *= maxSpeed; //we then multiply our normalized vector by maxSpeed to make it move faster
		return desiredVel - velocity; //we return the difference of our desired velocity and velocity so that we are steered in the direction of the targets direction
	}
	
	Vector3 Flee(Vector3 target) //flee is just the opposite of Seek. We create an Vector3 to steer the agent in the opposite direction
	{
		Vector3 desiredVel = target - transform.position; //same as flee
		float distance = desiredVel.magnitude; //we now create a distance float, which tracks the distance between agent and target using the magnitude of the vector (distance)
		if(distance < 4f) //if the distance between the two is less than 4 units, Flee!
		{
			desiredVel.Normalize();
			desiredVel *= maxSpeed;
			return velocity - desiredVel; //we create our opposing force here, notice how we flipped the vectors compared to Seek
		}
		else //if our agent and target are greater than 4 units apart
		{
			return Vector3.zero; //return a 0,0,0 vector (we don't want to move!)
		}
	}
	
	Vector3 Pursue(GameObject target) //Pursue is useful for calculating a future interception position of a target. It is used in conjunction with Seek!
	{
		Vector3 desiredVel = target.transform.position - transform.position; //same as Seek and Flee
		float distance = desiredVel.magnitude; //find the distance between agent and target
		float lookAhead = distance / maxSpeed; //we want to add a bit of distance onto the position we track, so we divide distance by maxSpeed ensuring it always scales as they change
		Vector3 desPos = target.transform.position+(lookAhead * target.GetComponent<SteeringBehaviours>().velocity); //our final vector, we tell our agent to Seek the targets position with the added lookAhead value, multiplied by the targets velocity, so that the look ahead can always be calculated in the correct direction
		return Seek (desPos); //we return our vector to Seek, which then runs the normal Seek code
	}
	
	Vector3 Arrive(Vector3 targetPos) //
	{
		Vector3 toTarget = targetPos - transform.position;
		float distance = toTarget.magnitude;
		if(distance <= 1f)
		{
			return Vector3.zero;
		}
		float slowingDistance = 8.0f; //at what radius from the target do we want to start slowing down
		float decelerateTweaker = maxSpeed / 10f; //how fast or slow we want to decelerate
		float rampedSpeed = maxSpeed * (distance / slowingDistance * decelerateTweaker); //ramped speed scales based on the distance to our target 
		float newSpeed = Mathf.Min (rampedSpeed, maxSpeed); //returns the smaller of the two speeds
		Vector3 desiredVel = newSpeed * toTarget.normalized; //use the newSpeed * by the normalized toTarget vector
		return desiredVel - velocity; //return the difference between desiredVel and our velocity and apply a force to it
	}
	
	Vector3 PathFollow() //Make sure you have the PATH script in your project :)
	{
		float distance = (transform.position - path.NextWaypoint()).magnitude;
		if(distance < 0.5f)
		{
			path.AdvanceWaypoint();
		}
		if(!path.looped && path.IsLastCheckpoint())
		{
			return Arrive (path.NextWaypoint());
		}
		else
		{
			return Seek (path.NextWaypoint());
		}
	}
	
	Vector3 OffsetPursuit(Vector3 offset)
	{
		Vector3 desiredVel = Vector3.zero;
		desiredVel = target.transform.TransformPoint(offset);
		float distance = (desiredVel - transform.position).magnitude;
		float lookAhead = distance / maxSpeed; //the lookAhead is how much we should look in front of our target. The distance scales obviously, so we divide it by our maxSpeed to ensure we are looking ahead a relative amount to our distance from our target
		desiredVel = desiredVel +(lookAhead * target.GetComponent<SteeringBehaviours>().velocity);
		return Arrive (desiredVel);
	}
	
	Vector3 Seperation() //this boid checks to see if there are any boids in it's radius. If so, a force is created to steering away the boids from this boid
	{
		Vector3 steeringForce = Vector3.zero;
		for(int i = 0; i < tagged.Count; i++)
		{
			GameObject entity = tagged[i];
			if(entity != null)
			{
				Vector3 toEntity = this.transform.position - entity.transform.position;
				toEntity.Normalize();
				float distance = toEntity.magnitude;
				steeringForce += toEntity / distance;
			}
		}
		return steeringForce;
	}
	 
	Vector3 Cohesion() //this boid checks to see if there are any boids in it's radius. If so, this boid adds up the position of all of the boids, then divides that by the number of boids, and finally, seeks towards that position, otherwise known as the centerOfMass.
	{
		Vector3 steeringForce = Vector3.zero;
		Vector3 centerOfMass = Vector3.zero;
		int taggedCount = 0;
		foreach(GameObject boid in tagged)
		{
			centerOfMass += boid.transform.position;
			taggedCount ++;
		}
		if(taggedCount > 0)
		{
			centerOfMass /= taggedCount;
			if(centerOfMass.magnitude == 0)
			{
				steeringForce = Vector3.zero;
			}
			else
			{
				steeringForce = Seek (centerOfMass);
				steeringForce.Normalize();
			}
		}
		return steeringForce;
	}
	
	Vector3 Alignment() //This boid checks other boids in it's radius, adds all of their forward vectors together, divides by the number of boids, then adds a force to ourselves to steer in the same direction
	{
		Vector3 steeringForce = Vector3.zero;
		int taggedCount = 0;
		foreach(GameObject boid in tagged)
		{
			steeringForce += boid.transform.forward;
			taggedCount++;
		}
		if(taggedCount > 0)
		{
			steeringForce /= taggedCount;
		}
		return steeringForce;
	}
	
	int TagNeighbours(float radius) //find boids in the neighbourhood radius
	{
		tagged.Clear ();
		GameObject[] allDaBoids = GameObject.FindGameObjectsWithTag("Boid");
		foreach(GameObject boid in allDaBoids)
		{
			if(boid != this.gameObject)
			{
				if((this.transform.position - boid.transform.position).magnitude < radius)
				{
					tagged.Add (boid);
				}
			}
		}
		return tagged.Count;
	}
	
	void NoOverlap() //make sure our boids can't overlap with each other
	{
		foreach(GameObject boid in tagged)
		{
			Vector3 toOther = boid.transform.position - transform.position;
			float distance = toOther.magnitude;
			toOther.Normalize();
			float overlap = overlapRadius + boid.GetComponent<SteeringBehaviours>().overlapRadius - distance;
			if(overlap >= 0)
			{
				boid.transform.position = boid.transform.position + toOther * overlap;
			}
		}
	}
}
