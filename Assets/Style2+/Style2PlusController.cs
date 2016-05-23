﻿using UnityEngine;
using System.Collections;

public class Style2PlusController : MonoBehaviour
{
	[SerializeField]
	Animator[] animators;

	static int runningHash = Animator.StringToHash ("Running");

	public bool IsRunning {
		set {
			foreach (var animator in animators) {
				animator.SetFloat (runningHash, value ? 1 : 0);
			}
		}
	}
}
