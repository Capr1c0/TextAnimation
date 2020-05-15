using System;
using UnityEngine;

public class easeLinear { }
public class easeInSine { }
public class easeOutSine { }
public class easeInOutSine { }
public class easeInQuad { }
public class easeOutQuad { }
public class easeInOutQuad { }
public class easeInCubic { }
public class easeOutCubic { }
public class easeInOutCubic { }
public class easeInQuart { }
public class easeOutQuart { }
public class easeInOutQuart { }
public class easeInQuint { }
public class easeOutQuint { }
public class easeInOutQuint { }
public class easeInExpo { }
public class easeOutExpo { }
public class easeInOutExpo { }
public class easeInCirc { }
public class easeOutCirc { }
public class easeInOutCirc { }
public class easeInBack { }
public class easeOutBack { }
public class easeInOutBack { }
public class easeInElastic { }
public class easeOutElastic { }
public class easeInOutElastic { }
public class easeInBounce { }
public class easeOutBounce { }
public class easeInOutBounce { }

public class EaseSwith {
    private object EaseObject;
    public EaseSwith (object ob) {
        EaseObject = ob;
    }
    public Func<float, float, float> get () {
        switch (EaseObject) {
            case easeLinear el:
                return (NowTime, TIME) => { float x = (NowTime / TIME); return x; };
                #region  easeSine
            case easeInSine eis:
                return (NowTime, TIME) => { float x = (NowTime / TIME); return (float) (1 - Math.Cos ((x * Math.PI) / 2)); };
            case easeOutSine eos:
                return (NowTime, TIME) => { float x = (NowTime / TIME); return (float) (Math.Sin ((x * Math.PI) / 2)); };
            case easeInOutSine eios:
                return (NowTime, TIME) => { float x = (NowTime / TIME); return (float) (-(Math.Cos (Math.PI * x) - 1) / 2); };
                #endregion
                #region  easeQuad
            case easeInQuad eiq:
                return (NowTime, TIME) => { float x = (NowTime / TIME); return (float) (x * x); };
            case easeOutQuad eoq:
                return (NowTime, TIME) => { float x = (NowTime / TIME); return (float) (1 - (1 - x) * (1 - x)); };
            case easeInOutQuad eioq:
                return (NowTime, TIME) => { float x = (NowTime / TIME); return (float) (x < 0.5 ? 2 * x * x : 1 - Math.Pow (-2 * x + 2, 2) / 2); };
                #endregion
                #region  easeCubic
            case easeInCubic eic:
                return (NowTime, TIME) => { float x = (NowTime / TIME); return (float) (x * x * x); };
            case easeOutCubic eoc:
                return (NowTime, TIME) => { float x = (NowTime / TIME); return (float) (1 - Math.Pow (1 - x, 3)); };
            case easeInOutCubic eioc:
                return (NowTime, TIME) => { float x = (NowTime / TIME); return (float) (x < 0.5 ? 4 * x * x * x : 1 - Math.Pow (-2 * x + 2, 3) / 2); };
                #endregion
                #region  easeQuart
            case easeInQuart eiq:
                return (NowTime, TIME) => { float x = (NowTime / TIME); return (float) (x * x * x * x); };
            case easeOutQuart eoq:
                return (NowTime, TIME) => { float x = (NowTime / TIME); return (float) (1 - Math.Pow (1 - x, 4)); };
            case easeInOutQuart eioq:
                return (NowTime, TIME) => { float x = (NowTime / TIME); return (float) (x < 0.5 ? 8 * x * x * x * x : 1 - Math.Pow (-2 * x + 2, 4) / 2); };
                #endregion
                #region  easeQuint
            case easeInQuint ciq:
                return (NowTime, TIME) => { float x = (NowTime / TIME); return (float) (x * x * x * x * x); };
            case easeOutQuint coq:
                return (NowTime, TIME) => { float x = (NowTime / TIME); return (float) (1 - Math.Pow (1 - x, 5)); };
            case easeInOutQuint cioq:
                return (NowTime, TIME) => { float x = (NowTime / TIME); return (float) (x < 0.5 ? 16 * x * x * x * x * x : 1 - Math.Pow (-2 * x + 2, 5) / 2); };
                #endregion
                #region  easeExpo
            case easeInExpo cie:
                return (NowTime, TIME) => { float x = (NowTime / TIME); return (float) (x == 0 ? 0 : Math.Pow (2, 10 * x - 10)); };
            case easeOutExpo coe:
                return (NowTime, TIME) => { float x = (NowTime / TIME); return (float) (x == 1 ? 1 : 1 - Math.Pow (2, -10 * x)); };
            case easeInOutExpo cioq:
                return (NowTime, TIME) => {
                    float x = (NowTime / TIME);
                    return (float) (x == 0 ?
                        0 :
                        x == 1 ?
                        1 :
                        x < 0.5 ? Math.Pow (2, 20 * x - 10) / 2 :
                        (2 - Math.Pow (2, -20 * x + 10)) / 2);
                };
                #endregion
                #region  easeCirc
            case easeInCirc eic:
                return (NowTime, TIME) => { float x = (NowTime / TIME); return (float) (1 - Math.Sqrt (1 - Math.Pow (x, 2))); };
            case easeOutCirc eoc:
                return (NowTime, TIME) => { float x = (NowTime / TIME); return (float) (Math.Sqrt (1 - Math.Pow (x - 1, 2))); };
            case easeInOutCirc eioc:
                return (NowTime, TIME) => {
                    float x = (NowTime / TIME);
                    return (float) (x < 0.5 ?
                        (1 - Math.Sqrt (1 - Math.Pow (2 * x, 2))) / 2 :
                        (Math.Sqrt (1 - Math.Pow (-2 * x + 2, 2)) + 1) / 2);
                };
                #endregion
                #region  easeBack
            case easeInBack eib:
                return (NowTime, TIME) => {
                    float x = (NowTime / TIME);
                    float c1 = 1.70158f;
                    float c3 = c1 + 1;
                    return (float) (c3 * x * x * x - c1 * x * x);
                };
            case easeOutBack eob:
                return (NowTime, TIME) => {
                    float x = (NowTime / TIME);
                    float c1 = 1.70158f;
                    float c3 = c1 + 1;
                    return (float) (1 + c3 * Math.Pow (x - 1, 3) + c1 * Math.Pow (x - 1, 2));
                };
            case easeInOutBack eiob:
                return (NowTime, TIME) => {
                    float x = (NowTime / TIME);
                    float c1 = 1.70158f;
                    float c2 = c1 * 1.525f;
                    return (float) (x < 0.5 ?
                        (Math.Pow (2 * x, 2) * ((c2 + 1) * 2 * x - c2)) / 2 :
                        (Math.Pow (2 * x - 2, 2) * ((c2 + 1) * (x * 2 - 2) + c2) + 2) / 2);
                };
                #endregion
                #region  easeElastic
            case easeInElastic cie:
                return (NowTime, TIME) => {
                    float x = (NowTime / TIME);
                    float c4 = (float) ((2 * Math.PI) / 3);
                    return (float) (x == 0 ?
                        0 :
                        x == 1 ?
                        1 :
                        -Math.Pow (2, 10 * x - 10) * Math.Sin ((x * 10 - 10.75) * c4));
                };
            case easeOutElastic coe:
                return (NowTime, TIME) => {
                    float x = (NowTime / TIME);
                    float c4 = (float) ((2 * Math.PI) / 3);
                    return (float) (x == 0 ?
                        0 :
                        x == 1 ?
                        1 :
                        Math.Pow (2, -10 * x) * Math.Sin ((x * 10 - 0.75) * c4) + 1);
                };
            case easeInOutElastic cioe:
                return (NowTime, TIME) => {
                    float x = (NowTime / TIME);
                    float c5 = (float) ((2 * Math.PI) / 4.5);
                    return (float) (x == 0 ?
                        0 :
                        x == 1 ?
                        1 :
                        x < 0.5 ?
                        -(Math.Pow (2, 20 * x - 10) * Math.Sin ((20 * x - 11.125) * c5)) / 2 :
                        (Math.Pow (2, -20 * x + 10) * Math.Sin ((20 * x - 11.125) * c5)) / 2 + 1);
                };
                #endregion
                #region  easeBounce
            case easeInBounce eib:
                return (NowTime, TIME) => {
                    float x = (NowTime / TIME);
                    Func<float, float> easeOutBounce_tmp = delegate (float x) {
                        float n1 = 7.5625f;
                        float d1 = 2.75f;
                        if (x < 1 / d1) {
                            return n1 * x * x;
                        } else if (x < 2 / d1) {
                            return n1 * (x -= 1.5f / d1) * x + 0.75f;
                        } else if (x < 2.5 / d1) {
                            return n1 * (x -= 2.25f / d1) * x + 0.9375f;
                        } else {
                            return n1 * (x -= 2.625f / d1) * x + 0.984375f;
                        }
                    };
                    return (float) (1 - easeOutBounce_tmp (1 - x));
                };
            case easeOutBounce eob:
                return (NowTime, TIME) => {
                    float x = (NowTime / TIME);
                    float n1 = 7.5625f;
                    float d1 = 2.75f;
                    if (x < 1 / d1) {
                        return n1 * x * x;
                    } else if (x < 2 / d1) {
                        return n1 * (x -= 1.5f / d1) * x + 0.75f;
                    } else if (x < 2.5 / d1) {
                        return n1 * (x -= 2.25f / d1) * x + 0.9375f;
                    } else {
                        return n1 * (x -= 2.625f / d1) * x + 0.984375f;
                    }
                };
            case easeInOutBounce eiob:
                return (NowTime, TIME) => {
                    float x = (NowTime / TIME);
                    Func<float, float> easeOutBounce_tmp = delegate (float x) {
                        float n1 = 7.5625f;
                        float d1 = 2.75f;
                        if (x < 1 / d1) {
                            return n1 * x * x;
                        } else if (x < 2 / d1) {
                            return n1 * (x -= 1.5f / d1) * x + 0.75f;
                        } else if (x < 2.5 / d1) {
                            return n1 * (x -= 2.25f / d1) * x + 0.9375f;
                        } else {
                            return n1 * (x -= 2.625f / d1) * x + 0.984375f;
                        }
                    };
                    return (float) (x < 0.5 ?
                        (1 - easeOutBounce_tmp (1 - 2 * x)) / 2 :
                        (1 + easeOutBounce_tmp (2 * x - 1)) / 2);
                };
                #endregion
                //default
            default:
                return (NowTime, TIME) => { float x = (NowTime / TIME); return (float) (x); };
        }
    }
}