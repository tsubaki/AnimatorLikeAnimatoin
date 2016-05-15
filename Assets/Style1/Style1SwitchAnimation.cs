using UnityEngine;
using System.Collections;

public class Style1SwitchAnimation : MonoBehaviour {

    [SerializeField]
    Animator[] animators;

    static int isRunningHash = Animator.StringToHash("IsRunning");

    public bool IsRunning {
        set
        {
            foreach (var animator in animators)
            {
                animator.SetBool(isRunningHash, value);
            }
        }
    }
}
