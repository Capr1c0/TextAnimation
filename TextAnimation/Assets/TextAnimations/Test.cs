using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour {
    public GameObject tests;
    private void Start () {
        TextAnimationHash res1 = new TextAnimationHash (
            new TextAnimationRescale (),
            new TextAnimationTime (0.2f),
            new TextAnimationVecMax (new Vector3 (5f, 5f, 5f)),
            new TextAnimationVecMin (new Vector3 (1f, 1f, 1f))
        );
        TextAnimationHash res2 = new TextAnimationHash (
            new TextAnimationRescale (),
            new TextAnimationTime (0.2f),
            new TextAnimationVecMax (new Vector3 (1f, 1f, 1f)),
            new TextAnimationVecMin (new Vector3 (5f, 5f, 5f))
        );

        TextAnimationHash rol1 = new TextAnimationHash (
            new TextAnimationRoll (),
            new TextAnimationTime (0.2f),
            new TextAnimationAngle (180f)
        );
        TextAnimationHash rol2 = new TextAnimationHash (
            new TextAnimationRoll (),
            new TextAnimationTime (0.2f),
            new TextAnimationAngle (-180f)
        );
        TextAnimationHash m1 = new TextAnimationHash (
            new TextAnimationMove (),
            new TextAnimationTime (0.5f),
            new TextAnimationVecMax (new Vector3 (5f, 5f, 0f))
        );
        TextAnimationHash m2 = new TextAnimationHash (
            new TextAnimationMove (),
            new TextAnimationTime (0.5f),
            new TextAnimationVecMax (new Vector3 (-5f, -5f, 0f))
        );

        TextAnimationHash c1 = new TextAnimationHash (
            new TextAnimationColorChange (),
            new TextAnimationTime (0.5f),
            new TextAnimationName ("_Color"),
            new TextAnimationColor (new Color (0f, 0f, 0f, 0.5f))
        );
        TextAnimationHash c2 = new TextAnimationHash (
            new TextAnimationColorChange (),
            new TextAnimationTime (0.5f),
            new TextAnimationName ("_Color"),
            new TextAnimationColor (new Color (1f, 1f, 1f, 1f))
        );

        TextAnimator[] t = new TextAnimator[] {
            new TextAnimator (tests, res1),
            new TextAnimator (tests, m1),
            new TextAnimator (tests, rol1),
            new TextAnimator (tests, c1),
            new TextAnimator (tests, res2),
            new TextAnimator (tests, m2),
            new TextAnimator (tests, rol2),
            new TextAnimator (tests, c2),
        };
        StartCoroutine (TextAnimator.PlayLoop (t));
    }
}