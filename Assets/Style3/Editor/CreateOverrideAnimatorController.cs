using UnityEngine;
using System.Collections;
using UnityEditor;

namespace AnimatorLikeAnimation.Style3
{
	public class CreateOverrideAnimatorController : EditorWindow
	{
		[MenuItem ("GameObject/AddOverrideAnimationController")]
		static void Export ()
		{
			var window = CreateOverrideAnimatorController.GetWindow<CreateOverrideAnimatorController> ();
			window.Show ();
		}

		[SerializeField]
		private RuntimeAnimatorController animationController = null;

		void OnGUI ()
		{
			animationController = EditorGUILayout.ObjectField (animationController, typeof(RuntimeAnimatorController), true) as RuntimeAnimatorController;

			if (GUILayout.Button ("Create")) {
				for (int i = 0; i < Selection.gameObjects.Length; i++) {
					var controller = new AnimatorOverrideController ();
					controller.runtimeAnimatorController = animationController;

					var obj = Selection.gameObjects [i];
					var animator = obj.GetComponent<Animator> ();
					if (animator == null)
						continue;

					obj.GetComponent<Animator> ().runtimeAnimatorController = controller;
				}
			}
		}

	}
}