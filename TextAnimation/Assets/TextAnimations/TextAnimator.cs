using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Animation Roll
public class TextAnimationRoll { }
//Animation Rescale
public class TextAnimationRescale { }
//Animation Noise
// public class TextAnimationNoise { }
//Animation Move
public class TextAnimationMove { }
//Animation ColorChange
public class TextAnimationColorChange { }
//WaitCommand
public class TextAnimationWait { }

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

// //Count
// public class TextAnimationCount {
//     public int Count { get; set; }
//     public TextAnimationCount (int arg) { Count = arg; }
// }

// //RandomRnage
// public class TextAnimationRandomRnage {
//     public Vector2 RandomRnage { get; set; }
//     public TextAnimationRandomRnage (Vector2 arg) { RandomRnage = arg; }
// }

//Name
public class TextAnimationName {
    public string Name { get; set; }
    public TextAnimationName (string arg) { Name = arg; }
}

//Color
public class TextAnimationColor {
    public Color Color { get; set; }
    public TextAnimationColor (Color arg) { Color = arg; }
}

//easetype
public class easetype {
    public object paramator;
    public easetype (object ob) {
        paramator = ob;
    }
}

//Hash
public class TextAnimationHash {
    public object[] paramators;
    public TextAnimationHash (params object[] ob) {
        paramators = ob;
    }
}

public class TextAnimator : MonoBehaviour {
    private GameObject Target;
    private object AnimationType = new TextAnimationRoll ();
    private float Time = 1f;
    private float Angle = 45f;
    private Vector3 VecMin = new Vector3 (0f, 0f, 0f);
    private Vector3 VecMax = new Vector3 (0f, 0f, 0f);
    private int Count = 1;
    private Vector2 RandomRnage = new Vector2 (0f, 0f);
    public string Name = "";
    public Color Color = new Color (0f, 0f, 0f, 0f);
    public easetype easetype = new easetype (new easeLinear ());
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
                    // case TextAnimationNoise n:
                    //     AnimationType = n;
                    //     break;
                case TextAnimationMove m:
                    AnimationType = m;
                    break;
                case TextAnimationColorChange x:
                    AnimationType = x;
                    break;
                case TextAnimationWait w:
                    AnimationType = w;
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
                    // case TextAnimationCount c:
                    //     Count = c.Count;
                    //     break;
                    // case TextAnimationRandomRnage r:
                    //     RandomRnage = r.RandomRnage;
                    //     break;
                case TextAnimationName n:
                    Name = n.Name;
                    break;
                case TextAnimationColor c:
                    Color = c.Color;
                    break;
                case object o when o.GetType ().ToString ().Contains ("ease"):
                    //easetype
                    easetype = new easetype (o);
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
                yield return roll.roll (Time, Angle, easetype);
                break;
            case TextAnimationRescale tmp:
                Rescale rescale = Target.AddComponent<Rescale> ();
                yield return rescale.rescale (Time, VecMin, VecMax, easetype);
                break;
                // case TextAnimationNoise tmp:
                //     Noise noise = Target.AddComponent<Noise> ();
                //     yield return noise.noise (Time, Count, RandomRnage);
                //     break;
            case TextAnimationMove tmp:
                Move move = Target.AddComponent<Move> ();
                yield return move.move (Time, VecMax, easetype);
                break;
            case TextAnimationColorChange tmp:
                ColorChange ColorChange = Target.AddComponent<ColorChange> ();
                yield return ColorChange.colorchange (Time, Name, Color);
                break;
            case TextAnimationWait tmp:
                yield return new WaitForSecondsRealtime (Time);
                break;
            default:
                break;
        }
    }

    public static IEnumerator Play (params TextAnimator[] textAnimators) {
        for (int i = 0; i < textAnimators.Length; i++) {
            yield return (textAnimators[i].Play ());
        }
    }
    public static IEnumerator PlayLoop (params TextAnimator[] textAnimators) {
        while (true) {
            for (int i = 0; i < textAnimators.Length; i++) {
                yield return (textAnimators[i].Play ());
                //debug
                // yield return new WaitForSecondsRealtime (1f);
                //textAnimators[i].Target.transform.localPosition = new Vector3 (4.1f, 0f, -4f);
            }
        }
    }

    public static IEnumerator PlayMultiple (params TextAnimator[] textAnimators) {
        List<Coroutine> WaitComand = new List<Coroutine> ();
        for (int i = 0; i < textAnimators.Length; i++) {
            WaitComand.Add (CoroutineHandler.StartStaticCoroutine (textAnimators[i].Play ()));
        }
        foreach (Coroutine c in WaitComand) {
            yield return c;
        }
    }
}