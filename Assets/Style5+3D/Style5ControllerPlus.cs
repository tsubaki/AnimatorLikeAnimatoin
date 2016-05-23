using UnityEngine;
using System.Collections;

namespace AnimatorLikeAnimation.Style5
{
	public class Style5ControllerPlus : MonoBehaviour
	{
		int currentAnimation;
		[SerializeField] Style5Animation target;
		[SerializeField] AnimationClip[] animations;

		void Awake ()
		{
			target.Setup (animations);
		}

		public void PlayNextAnimation ()
		{
			currentAnimation++;
			if (currentAnimation >= animations.Length) {
				currentAnimation = 0;
			}
			var hash = target.GetAnimationStateHashFromClipsName (animations [currentAnimation].name);
			target.GetComponent<Animator> ().CrossFadeInFixedTime (hash, 0.6f);
		}
	}
}