using UnityEngine;
using System.Collections;

namespace AnimatorLikeAnimation.Style1
{
	public class Style1Controller : MonoBehaviour
	{

		[SerializeField]
		Animator[] animators;

		static int isRunningHash = Animator.StringToHash ("IsRunning");

		public bool IsRunning {
			set {
				foreach (var animator in animators) {
					animator.SetBool (isRunningHash, value);
				}
			}
		}
	}
}