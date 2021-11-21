using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
	public float ballSpeed = 0.02f;
	public EventSystemCustom eventSystem;

	float xDir = 1;
	float yDir = 1;

	float upBorder = 4.5f;
	float downBorder = -4.5f;
	float rightBorder = 10.2f;
	float leftBorder = -10.2f;

	Vector3 moveVec;

    // Start is called before the first frame update
    void Start()
    {
		transform.position = RandomPlace();
	}

	// Update is called once per frame
	void Update()
    {
		moveVec = new Vector3(xDir * ballSpeed, yDir * ballSpeed, 0);
		transform.position += moveVec;

		// if the ball hits downside or upside
		if(transform.position.y < downBorder && yDir < 0)
		{
			yDir *= -1;
		}

		if (transform.position.y > upBorder && yDir > 0)
		{
			yDir *= -1;
		}

		// check loose condition
		// then invoke the event
		if (transform.position.x >= rightBorder || transform.position.x <= leftBorder)
		{
			Debug.Log("decrease heart");
			eventSystem.OnHeartDecrease.Invoke();
			//StartCoroutine(Wait()); // doesn't work
			transform.position = RandomPlace();
		}
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "Pong1" && xDir > 0)
		{
			Debug.Log("triggered pong1!");
			xDir *= -1;
		}

		if (collision.gameObject.tag == "Pong2" && xDir < 0)
		{
			Debug.Log("triggered pong2!");
			xDir *= -1;
		}
	}

	Vector3 RandomPlace()
	{
		float ballPositon = Random.Range(-3.5f, 3.5f);
		return new Vector3(0, ballPositon, 0);
	}

	//IEnumerator Wait()
	//{
	//	yield return new WaitForSeconds(5);
	//}
}
