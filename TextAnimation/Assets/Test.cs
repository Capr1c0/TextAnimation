using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour {
    public GameObject tests;
    private void Start () {
        TextAnimationHash t = new TextAnimationHash (
            new TextAnimationRescale (),
            new TextAnimationTime (10),
            new TextAnimationAngle (180f),
            new TextAnimationVecMax (new Vector3 (10f, 10f, 10f)),
            new TextAnimationVecMin (new Vector3 (0f, 0f, 0f))
        );
        TextAnimator ta = new TextAnimator (tests, t);
        StartCoroutine (ta.Play ());
    }
}