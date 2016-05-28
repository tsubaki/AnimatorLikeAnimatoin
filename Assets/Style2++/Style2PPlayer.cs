using UnityEngine;
using System.Collections;

public class Style2PPlayer : MonoBehaviour
{
	void Update ()
	{
		Vector2 velocity = GetComponent<Rigidbody2D> ().velocity;
		if (Input.GetKeyDown (KeyCode.Space)) {
			velocity.y = 5;
		}

		velocity.x = Input.GetAxis ("Horizontal");
		GetComponent<Rigidbody2D> ().velocity = velocity;
	}
}
