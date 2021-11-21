using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PongController : MonoBehaviour
{
	public float pongSpeed = 0.02f;
	public GameObject pong2;
	private Vector3 moveVector;

	// Start is called before the first frame update
	void Start()
    {
        moveVector = new Vector3(0, pongSpeed, 0);

	}

	// Update is called once per frame
	void Update()
    {
		if (Input.GetKey(KeyCode.UpArrow) && transform.position.y <=3.6)
		{
			transform.position += moveVector;
			pong2.transform.position -= moveVector;
		}

		if (Input.GetKey(KeyCode.DownArrow) && transform.position.y >= -3.6)
		{
			transform.position -= moveVector;
			pong2.transform.position += moveVector;
		}
	}
}
