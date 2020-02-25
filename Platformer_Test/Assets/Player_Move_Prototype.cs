using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Move_Prototype : MonoBehaviour {

	private Rigidbody2D playerBody;
	private BoxCollider2D playerCollider;
	private int speedModifier;
	private int jumpModifier;
	private bool facingRight;
	private float moveX;
	private float moveY;

	// Start is called before the first frame update
	void Start() {
		playerBody = transform.GetComponent<Rigidbody2D>();
		playerCollider = transform.GetComponent<BoxCollider2D>();
		speedModifier = 3;
		jumpModifier = 200;
		facingRight = true;
	}

	// Update is called once per frame
	void Update() {
		move();

	}

	private void move() {
		// Controls
		moveX = Input.GetAxis("Horizontal");
		if( Input.GetButtonDown("Jump") && isGrounded() )
			jump();
		// Player orientation
		if( (moveX < 0 && facingRight) ||
			(moveX > 0 && !facingRight) )
			flip();
		// Physics
		playerBody.velocity = new Vector2(moveX * speedModifier, gameObject.GetComponent<Rigidbody2D>().velocity.y);
	}

	private void flip() {
		facingRight = !facingRight;
		Vector2 localScale = gameObject.transform.localScale;
		localScale.x *= -1;
		transform.localScale = localScale;
	}

	private bool isGrounded()
	{
		return true;
	}

	private void jump() {
		gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpModifier);
	}
}
