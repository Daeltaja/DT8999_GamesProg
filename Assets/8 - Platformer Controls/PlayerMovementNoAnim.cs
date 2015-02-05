using UnityEngine;
using System.Collections;

public class PlayerMovementNoAnim : MonoBehaviour {

	public float moveSpeed = 6f;
	bool grounded = false;
	public Transform groundCheck;
	public LayerMask whatIsGround;
	float groundRadius = 0.2f;
	public float jumpforce = 700f;
	
	public GameObject enemy;
	EnemyStats eStats;
	
	void Start()
	{
		eStats = enemy.GetComponent<EnemyStats>();
		eStats.TakeDamage(10);
		
	}
	
	void FixedUpdate () 
	{
		float move = Input.GetAxis ("Horizontal");
		rigidbody2D.velocity = new Vector2(move * moveSpeed, rigidbody2D.velocity.y); //set the velocity of our character to 
		
		grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround); //Physics2D.OverlapCircle returns true if it touches colliders in the ground layer
		if(grounded && Input.GetKeyDown (KeyCode.Space))
		{
			rigidbody2D.AddForce(new Vector2(0, jumpforce));
		}
	}
}
