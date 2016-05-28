using UnityEngine;
using System.Collections;

public class Style2PlayerBehavour : StateMachineBehaviour
{
	[SerializeField]
	LayerMask mask;

	static int ySpeedHash = Animator.StringToHash ("y speed");
	static int xSpeedHash = Animator.StringToHash ("x speed");
	static int distanceFromGround = Animator.StringToHash ("distance from ground");
	static int landingTimeHash = Animator.StringToHash ("landing time");

	public float landingTime { get; set; }

	override public void OnStateUpdate (Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		var transform = animator.transform;
		var rigidbody2d = animator.GetComponent<Rigidbody2D> ();
        var hit =  Physics2D.CircleCast(transform.position, 0.15f, transform.up * -1, 5, mask);

		if (hit.distance > 0.6f) {
			landingTime = 1f;
		}

		if (rigidbody2d.velocity.x != 0) {
			landingTime = 0;
		}
		landingTime -= Time.deltaTime;

		animator.SetFloat (xSpeedHash, Mathf.Abs (rigidbody2d.velocity.x));
		animator.SetFloat (ySpeedHash, rigidbody2d.velocity.y);
		animator.SetFloat (distanceFromGround, hit.distance);
		animator.SetFloat (landingTimeHash, landingTime);

		if (rigidbody2d.velocity.x != 0) {
			animator.GetComponent<SpriteRenderer> ().flipX = rigidbody2d.velocity.x < 0;
		}
	}
}
