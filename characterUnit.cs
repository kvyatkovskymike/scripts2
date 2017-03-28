using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterUnit : unit {

	[SerializeField]
	private int lives = 7;
	[SerializeField]
	private float speed = 3.0f;
	[SerializeField]
	private float jumpForce = 15.0f;
	[SerializeField]
	private bool isGrounded = false;
	[SerializeField]
	private SpriteRenderer sprite;
	private Bullet bullet;

	private CharState State
	{
		get{ return (CharState)animator.GetInteger ("State");}
		set { animator.SetInteger ("State", (int)value);}
	}


	new private Rigidbody2D rigidbody;
	private Animator animator;


	private void Awake()
	{
		rigidbody = GetComponent<Rigidbody2D> ();
		animator = GetComponent<Animator> ();
		sprite = GetComponentInChildren<SpriteRenderer> ();

		bullet = Resources.Load<Bullet> ("bullet");


	}
	private void FixUpdate()
	{
		checkGround();
	}
	private void Update ()
	{
		State = CharState.Stage;
		if (Input.GetButton ("Fire"))
			Shoot ();
		if(Input.GetButton ("Horizontal"))
			Run ();
		if(isGrounded && Input.GetButtonDown ("Jump"))
			Jump ();
	}



	private void Run()
	{
		Vector3 direction = transform.right*Input.GetAxis("Horizontal");

		transform.position = Vector3.MoveTowards (transform.position, transform.position + direction, speed * Time.deltaTime);

		sprite.flipX = direction.x < 0.0f;
		State = CharState.Run;
	}
	private void Jump()
	{
		rigidbody.AddForce (transform.up * jumpForce, ForceMode2D.Impulse);
	}

	private void Shoot()
	{
		Vector3 position = transform.position; position.y += 0.5f; position.x += 0.2f;
		Bullet newBullet = Instantiate (bullet, position, bullet.transform.rotation) as Bullet;
		newBullet.Direction = newBullet.transform.right * (sprite.flipX ? -1.0f : 1.0f);
	}
	private void checkGround()
	{
		Collider2D[] colliders = Physics2D.OverlapCircleAll (transform.position, 0.3f);

		isGrounded = colliders.Length > 1;
	}
	public enum CharState
	{
		Stage,
		Run

	}

}
