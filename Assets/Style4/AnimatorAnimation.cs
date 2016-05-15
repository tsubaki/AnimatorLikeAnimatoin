using UnityEngine;
using System.Collections;

public class AnimatorAnimation : MonoBehaviour {

    [HideInInspector, SerializeField]
    RuntimeAnimatorController controller;

    [SerializeField]
    AnimationClip[] clips;

    AnimatorOverrideController overrideController;

    void Start()
    {
        overrideController = new AnimatorOverrideController();
        overrideController.runtimeAnimatorController = controller;

        var animator = gameObject.GetComponent<Animator>();
        if( animator == null)
        {
            animator = gameObject.AddComponent<Animator>();
        }
        animator.runtimeAnimatorController = overrideController;

        ChangeAnimation(0);
    }

    public void ChangeAnimation(int id)
    {
        overrideController["Clip"] = clips[id]; ;
    }
}
