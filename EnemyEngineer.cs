using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyEngineer : MonoBehaviour {
	[SerializeField]
	public float speed = 0.5f;
	public bool CheckEnemy = false;
	private SpriteRenderer sprite;
	// Use this for initialization

	public void Awake() 
	{
		sprite = GetComponentInChildren<SpriteRenderer> ();
	}

	public void OnTriggerEnter2D(Collider2D col)
	{
		if (col.CompareTag ("Player")) 
		{
			CheckEnemy = true;
		}
	}

	public void Move()
	{
	Vector3 direction = transform.right;

	transform.position = Vector3.MoveTowards (transform.position, transform.position + direction, speed * Time.deltaTime);

	sprite.flipX = direction.x < 0.0f;
	}
	// Update is called once per frame
	void Update () 
	{
		Move ();
		if (CheckEnemy = true) 
		{
			
		}
	}
}
