using UnityEngine;
using System.Collections;

namespace AnimatorLikeAnimation.Style4
{
	public class Style4Animation : MonoBehaviour
	{
		[SerializeField]
		RuntimeAnimatorController controller;

		[SerializeField]
		AnimationClip[] clips;

		AnimatorOverrideController overrideController;

		void Awake ()
		{
			overrideController = new AnimatorOverrideController ();
			overrideController.runtimeAnimatorController = controller;

			var animator = gameObject.GetComponent<Animator> ();
			if (animator == null) {
				animator = gameObject.AddComponent<Animator> ();
			}
			animator.runtimeAnimatorController = overrideController;

			ChangeAnimation (0);
		}

		public void ChangeAnimation (int id)
		{
			overrideController ["Clip"] = clips [id];
		}
	}
}

