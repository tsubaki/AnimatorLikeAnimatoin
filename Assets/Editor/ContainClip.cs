using UnityEngine;
using System.Collections;
using UnityEditor;
using UnityEditorInternal;
using System.Collections.Generic;

namespace AnimationClipExtensions
{
	public class ContainClip : EditorWindow
	{

		private UnityEditor.Animations.AnimatorController controller;
		List<AnimationClip> clipList = new List<AnimationClip> ();

		[SerializeField]
		string clipName;

		Vector2 scroll;

		[MenuItem ("Assets/Add AnimationClip")]
		static void CreateWindow ()
		{
			var window = ContainClip.GetWindow (typeof(ContainClip)) as ContainClip;
			if (Selection.activeObject is UnityEditor.Animations.AnimatorController)
				window.controller = Selection.activeObject as UnityEditor.Animations.AnimatorController;
			window.RefleshClipList (window.controller);
		}

		void OnGUI ()
		{
			EditorGUILayout.LabelField ("target clip");
			EditorGUI.BeginChangeCheck ();
			controller = EditorGUILayout.ObjectField (controller, typeof(UnityEditor.Animations.AnimatorController), false) as UnityEditor.Animations.AnimatorController;
			if (EditorGUI.EndChangeCheck ()) {
				RefleshClipList (controller);
			}

			if (controller == null)
				return;

			EditorGUILayout.Space ();
			EditorGUILayout.HelpBox ("Type a new clip name", MessageType.None);
			EditorGUILayout.BeginVertical ("box");

			clipName = EditorGUILayout.TextField (clipName);

			if (clipList.Exists (item => item.name == clipName) || string.IsNullOrEmpty (clipName)) {
				//EditorGUILayout.LabelField ("can't create duplicate name or empty");
			} else {
				if (GUILayout.Button ("Add Clip")) {
					AddClip (clipName);
					clipName = string.Empty;
					RefleshClipList (controller);
					Repaint ();
				}
			}
			EditorGUILayout.EndVertical ();
			if (clipList.Count == 0)
				return;

			EditorGUILayout.Space ();

			using (var scrollView = new EditorGUILayout.ScrollViewScope (scroll)) {
				scroll = scrollView.scrollPosition;
				EditorGUILayout.HelpBox ("clips", MessageType.None);
				EditorGUILayout.BeginVertical ("box");

				foreach (var removeClip in clipList.ToArray()) {
					EditorGUILayout.BeginHorizontal ();

					EditorGUILayout.LabelField (removeClip.name);
					if (GUILayout.Button ("Remove Clip", GUILayout.Width (100))) {
						RemoveClip (removeClip);
						RefleshClipList (controller);
					}
					EditorGUILayout.EndHorizontal ();
				}
				EditorGUILayout.EndVertical ();


			}
		}

		void RefleshClipList (UnityEditor.Animations.AnimatorController controller)
		{
			if (controller == null)
				return;

			clipList.Clear ();

			var allAsset = AssetDatabase.LoadAllAssetsAtPath (AssetDatabase.GetAssetPath (controller));
			foreach (var asset in allAsset) {
				if (asset is AnimationClip) {
					var removeClip = asset as AnimationClip;
					if (!clipList.Contains (removeClip)) {
						clipList.Add (removeClip);
					}
				}
			}
		}

		void AddClip (string clipName)
		{
			AnimationClip animationClip = UnityEditor.Animations.AnimatorController.AllocateAnimatorClip (clipName);
			AssetDatabase.AddObjectToAsset (animationClip, controller);
			AssetDatabase.ImportAsset (AssetDatabase.GetAssetPath (controller));
			AssetDatabase.Refresh ();
		}

		void RemoveClip (AnimationClip clip)
		{

			Object.DestroyImmediate (clip, true);
			AssetDatabase.ImportAsset (AssetDatabase.GetAssetPath (controller));
		}
	}
}