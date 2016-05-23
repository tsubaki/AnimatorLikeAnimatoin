using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace AnimatorLikeAnimation.Style5
{
	[RequireComponent (typeof(Animator))]
	public class Style5Animation : MonoBehaviour
	{
		[SerializeField]
		AnimationClip[] clips;

		Dictionary<string, int> clipNameToHash = new Dictionary<string, int> ();

		static int[] ClipHashs;
		const int maxumClipSize = 4;

		static Style5Animation ()
		{
			ClipHashs = new int[maxumClipSize];
			for (int i = 0; i < ClipHashs.Length; i++) {
				ClipHashs [i] = Animator.StringToHash (string.Format ("BaseClip{0}", i + 1));
			}
		}

		void Start ()
		{
			if (clips == null)
				return;
			Setup (clips);
		}

		public void Setup (AnimationClip[] animationClips)
		{
			clips = animationClips;
			clipNameToHash.Clear ();

			var runtimeController = Resources.Load<RuntimeAnimatorController> (string.Format ("BaseController{0}Clip", clips.Length));
			var overrideAnimatorController = new AnimatorOverrideController ();
			overrideAnimatorController.runtimeAnimatorController = runtimeController;

			var overrideClips = overrideAnimatorController.clips;
			for (int i = 0; i < clips.Length; i++) {
				overrideClips [i].overrideClip = clips [i];
				clipNameToHash.Add (clips [i].name, ClipHashs [i]);
			}
			overrideAnimatorController.clips = overrideClips;

			var animator = GetComponent<Animator> ();
			animator.runtimeAnimatorController = overrideAnimatorController;
		}

		public int GetAnimationStateHashFromClipsName (string clipName)
		{
			return clipNameToHash [clipName];
		}
	}
}