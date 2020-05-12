﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Animation Roll
public class TextAnimationRoll { }
//Animation Rescale
public class TextAnimationRescale { }

//Time
public class TextAnimationTime {
    public float Time { get; set; }
    public TextAnimationTime (string t) { Time = float.Parse (t); }
    public TextAnimationTime (int t) { Time = (float) t; }
    public TextAnimationTime (float t) { Time = t; }
}

//Angle
public class TextAnimationAngle {
    public float Angle { get; set; }
    public TextAnimationAngle (string arg) { Angle = float.Parse (arg); }
    public TextAnimationAngle (int arg) { Angle = (float) arg; }
    public TextAnimationAngle (float arg) { Angle = arg; }
}

//VecMin
public class TextAnimationVecMin {
    public Vector3 Min { get; set; }
    public TextAnimationVecMin (Vector3 arg) { Min = arg; }
}

//VecMax
public class TextAnimationVecMax {
    public Vector3 Max { get; set; }
    public TextAnimationVecMax (Vector3 arg) { Max = arg; }
}

public class TextAnimationHash {
    public object[] paramators;
    public TextAnimationHash (params object[] ob) {
        paramators = ob;
    }
}

public class TextAnimator {
    private GameObject Target;
    private object AnimationType = new TextAnimationRoll ();
    private float Time = 1f;
    private float Angle = 45f;
    private Vector3 VecMin = new Vector3 (0f, 0f, 0f);
    private Vector3 VecMax = new Vector3 (0f, 0f, 0f);
    public TextAnimator (GameObject g, TextAnimationHash hash) {
        Target = g;
        //Type判定
        foreach (object ob in hash.paramators) {
            switch (ob) {
                //Animation
                case TextAnimationRoll r:
                    AnimationType = r;
                    break;
                case TextAnimationRescale r:
                    AnimationType = r;
                    break;

                    //Arg
                case TextAnimationTime t:
                    Time = t.Time;
                    break;
                case TextAnimationAngle a:
                    Angle = a.Angle;
                    break;
                case TextAnimationVecMin v:
                    VecMin = v.Min;
                    break;
                case TextAnimationVecMax v:
                    VecMax = v.Max;
                    break;

                default:
                    break;
            }
        }
    }

    public IEnumerator Play () {
        switch (AnimationType) {
            case TextAnimationRoll tmp:
                Roll roll = Target.AddComponent<Roll> ();
                yield return roll.roll (Time, Angle);
                break;
            case TextAnimationRescale tmp:
                Rescale rescale = Target.AddComponent<Rescale> ();
                yield return rescale.rescale (Time, VecMin, VecMax);
                break;
            default:
                break;
        }
    }

    public IEnumerator PlayMultiple (params TextAnimator[] textAnimators) {
        List<IEnumerator> WaitComand = new List<IEnumerator> ();
        for (int i = 0; i < textAnimators.Length; i++) {
            WaitComand.Add (textAnimators[i].Play ());
        }
        yield return WaitComand;
    }
}