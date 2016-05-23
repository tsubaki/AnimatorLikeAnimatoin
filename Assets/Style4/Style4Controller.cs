using UnityEngine;
using System.Collections;

namespace AnimatorLikeAnimation.Style4
{
	public class Style4Controller : MonoBehaviour
	{
		[SerializeField]
		Style4Animation[] animations;

		enum PlayerAnimation
		{
			Idle = 0,
			Run = 1,
		}

		public bool IsRunning {
			set {
				int animtype = (int)(value ? PlayerAnimation.Run : PlayerAnimation.Idle);
				for (int i = 0; i < animations.Length; i++) {
					animations [i].ChangeAnimation (animtype);
				}
			}
		}
	}
}