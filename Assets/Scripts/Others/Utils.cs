using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Utils
{
    public static IEnumerator PlayAnimAndChangeStateAfter(GameObject parent, Animator animator, string clipName,
        bool activeStateAfter = true)
    {
        animator.Play(clipName);

        var animationLength = animator.GetCurrentAnimatorStateInfo(0).length;
        yield return new WaitForSeconds(animationLength);

        parent.SetActive(activeStateAfter);
    }
}
