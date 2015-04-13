using UnityEngine;
using System.Collections;

/*
Weclome to Steering Behaviours! 
The idea is that we enact a force on an entity (or agent as we will refer to them as) to steer it in the direction of it's target
We have a ForceIntegrator function that handles the movement side of things
We also have Seek, Flee and Pursue steering behaviours in here. 
To test them out, toggle on and off the isSeeking and isPursuing bools on the inspector 
*/

public class SteeringBehavioursPlayer : MonoBehaviour {

	public Vector3 force; //force - can be applied in any direction right?
	public Vector3 velocity; //direction 
	public float mass = 1f; //weight of our agent
	public float maxSpeed = 5f; //how fast it can travel
	public GameObject target; //something to steer towards!
	public bool seekEnabled, fleeEnabled, pursueEnabled, arriveEnabled, pathFollowEnabled, offsetPursuitEnabled; //toggle which steering behaviour you want on in the inspector!
	public Vector3 offsetPursuitOffset;
	Path path = new Path();
	
	void Start()
	{
		path.CreatePath(); //access the path instance and call the CreatePath method
		offsetPursuitOffset = transform.position; //set the offsetPursuitOffset vector to the starting position of each follower (it's easier 
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
		if(seekEnabled)
		{
			force += Seek(target.transform.position); //Seek is a functon that returns a Vector3, and we also pass down our targets position
		}
		if(fleeEnabled)
		{
			force += Flee (target.transform.position);
		}
		if(pursueEnabled)
		{
			force += Pursue(target); //Pursue is a function that returns a Vector3, and we also pass down our target gameobject
		}
		if(arriveEnabled)
		{
			force += Arrive (target.transform.position);
		}
		if(pathFollowEnabled)
		{
			force += PathFollow ();
		}
		if(offsetPursuitEnabled) 
		{
			force += OffsetPursuit (offsetPursuitOffset); //return the offsetpursuit force, passing in the offset
		}
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
		Vector3 desPos = target.transform.position+(lookAhead * target.GetComponent<SteeringBehavioursPlayer>().velocity); //our final vector, we tell our agent to Seek the targets position with the added lookAhead value, multiplied by the targets velocity, so that the look ahead can always be calculated in the correct direction
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
	
	Vector3 PathFollow()
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
		desiredVel = desiredVel +(lookAhead * target.GetComponent<SteeringBehavioursPlayer>().velocity);
		return Arrive (desiredVel);
		
	}
}
