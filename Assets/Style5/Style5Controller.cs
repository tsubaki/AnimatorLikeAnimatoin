using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace AnimatorLikeAnimation.Style5
{
	public class Style5Controller : MonoBehaviour
	{
		[SerializeField]
		Target[] targets;

		[System.Serializable]
		class Target
		{
			int currentAnimation;
			[SerializeField] Style5Animation target;
			[SerializeField] string[] animations;

			public void PlayNextAnimation ()
			{
				currentAnimation++;
				if (currentAnimation >= animations.Length) {
					currentAnimation = 0;
				}
				var hash = target.GetAnimationStateHashFromClipsName (animations [currentAnimation]);
				target.GetComponent<Animator> ().Play (hash);
			}
		}

		public void OnClickGoNextAnimation ()
		{
			for (int i = 0; i < targets.Length; i++) {
				targets [i].PlayNextAnimation ();
			}
		}
	}
}