using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour {
    public GameObject tests;
    private void Start () {

        TextAnimationHash rol1 = new TextAnimationHash (
            new TextAnimationRoll (),
            new TextAnimationTime (1f),
            new TextAnimationAngle (180f),
            new easeLinear()
        );
        TextAnimationHash rol2 = new TextAnimationHash (
            new TextAnimationRoll (),
            new TextAnimationTime (1f),
            new TextAnimationAngle (180f),
            new easeInSine()
        );

        TextAnimator[] t3 = new TextAnimator[] {
            new TextAnimator (tests, rol1),
            new TextAnimator (tests, rol2)
        };
        StartCoroutine (test (t3));
    }

    private IEnumerator test (TextAnimator[] t) {
        while (true) {
            yield return StartCoroutine (TextAnimator.Play (t));
        }
    }
}