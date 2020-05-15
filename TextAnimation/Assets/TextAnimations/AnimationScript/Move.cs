using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour {
    private readonly float TimeSpan = 0.02f;
    public IEnumerator move (float Time, Vector3 VecMax, easetype ease) {
        float NowTime = 0f;
        Vector3 nowpos = this.gameObject.transform.localPosition;
        Vector3 ans = VecMax;
        Vector3 Sabun = VecMax - this.gameObject.transform.localPosition;
        //easeを取得
        Func<float, float, float> Ease = new EaseSwith (ease.paramator).get ();
        while (NowTime < Time) {
            this.gameObject.transform.localPosition = nowpos + Ease (NowTime, Time) * Sabun;
            NowTime += TimeSpan;
            yield return new WaitForSecondsRealtime (TimeSpan);
        }
        this.gameObject.transform.localPosition = ans;
        //必ず
        Destroy (this.gameObject.GetComponent<Move> ());
    }
}