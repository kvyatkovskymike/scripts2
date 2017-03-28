using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class loadLevel : MonoBehaviour{
	[SerializeField]
	public int LevelToLoad = 1;

	private gameMaster gm;

	void Start()
	{
		gm = GameObject.FindGameObjectWithTag ("GameMaster").GetComponent<gameMaster>();
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.CompareTag ("Player")) 
		{
			
			if (Input.GetKeyDown ("e")) {
				Application.LoadLevel ("office1");
			}
		}
	}

	void OnTriggerStay2D(Collider2D col)
	{
		if (col.CompareTag ("Player")) {
			if (Input.GetKeyDown ("e")) {
				Application.LoadLevel ("office1");
			}
		}
	}

	void OnTriggerExit2D(Collider2D col)
	{
		if (col.CompareTag ("Player")) {
			
		}
	}



}
