﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	private float speed = 10.0f;
	private Vector3 direction;
	public Vector3 Direction {set { direction = value;}}
	private SpriteRenderer sprite;

	void Awake()
	{
		sprite = GetComponentInChildren<SpriteRenderer>();
	}

	void Start()
	{
		Destroy (gameObject, 1.5f);
	}

	void Update()
	{
		transform.position = Vector3.MoveTowards (transform.position, transform.position + direction, speed * Time.deltaTime);
	}
}
