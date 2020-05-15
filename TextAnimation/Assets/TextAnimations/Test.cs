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
                new TextAnimationMove (),
                new TextAnimationTime (1f),
                new TextAnimationVecMax (new Vector3 (-4.1f, 0f, -4f)),
                ob
            ));
        }
        List<TextAnimator> ta = new List<TextAnimator> ();
        foreach (TextAnimationHash tah in t) {
            ta.Add (new TextAnimator (tests, tah));
        }

        StartCoroutine (test (ta.ToArray ()));
    }

    private IEnumerator test (TextAnimator[] t) {
        while (true) {
            yield return StartCoroutine (TextAnimator.PlayLoop (t));
        }
    }
}