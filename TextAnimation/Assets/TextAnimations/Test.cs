using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour {
    public GameObject tests;
    private void Start () {
        List<object> ease = new List<object> () {
            new easeLinear (),
            new easeInSine (),
            new easeOutSine (),
            new easeInOutSine (),
            new easeInQuad (),
            new easeOutQuad (),
            new easeInOutQuad (),
            new easeInCubic (),
            new easeOutCubic (),
            new easeInOutCubic (),
            new easeInQuart (),
            new easeOutQuart (),
            new easeInOutQuart (),
            new easeInQuint (),
            new easeOutQuint (),
            new easeInOutQuint (),
            new easeInExpo (),
            new easeOutExpo (),
            new easeInOutExpo (),
            new easeInCirc (),
            new easeOutCirc (),
            new easeInOutCirc (),
            new easeInBack (),
            new easeOutBack (),
            new easeInOutBack (),
            new easeInElastic (),
            new easeOutElastic (),
            new easeInOutElastic (),
            new easeInBounce (),
            new easeOutBounce (),
            new easeInOutBounce ()
        };
        List<TextAnimationHash> t = new List<TextAnimationHash> ();
        foreach (object ob in ease) {
            t.Add (new TextAnimationHash (
                new TextAnimationRescale (),
                new TextAnimationTime (1f),
                new TextAnimationAngle (360f),
                new TextAnimationVecMin (new Vector3 (1f, 1f, 1f)),
                new TextAnimationVecMax (new Vector3 (2f, 2f, 2f)),
                ob
            ));
        }
        List<TextAnimationHash> t2 = new List<TextAnimationHash> ();
        foreach (object ob in ease) {
            t2.Add (new TextAnimationHash (
                new TextAnimationRoll (),
                new TextAnimationTime (1f),
                new TextAnimationAngle (360f),
                new TextAnimationVecMin (new Vector3 (1f, 1f, 1f)),
                new TextAnimationVecMax (new Vector3 (2f, 2f, 2f)),
                ob
            ));
        }
        List<TextAnimator> ta = new List<TextAnimator> ();
        foreach (TextAnimationHash tah in t) {
            ta.Add (new TextAnimator (tests, tah));
        }
        List<TextAnimator> ta2 = new List<TextAnimator> ();
        foreach (TextAnimationHash tah in t2) {
            ta2.Add (new TextAnimator (tests, tah));
        }

        StartCoroutine (test (ta.ToArray (), ta2.ToArray ()));
    }

    private IEnumerator test (TextAnimator[] t1, TextAnimator[] t2) {
        while (true) {
            for (int i = 0; i < t1.Length; i++) {
                yield return StartCoroutine (TextAnimator.PlayMultiple (t1[i], t2[i]));
                yield return new WaitForSecondsRealtime(0.5f);
            }
        }
    }
}