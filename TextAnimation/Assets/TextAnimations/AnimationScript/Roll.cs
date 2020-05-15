using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Roll : MonoBehaviour {
    private readonly float TimeSpan = 0.02f;
    public IEnumerator roll (float Time, float Angle, easetype ease) {
        this.gameObject.transform.localEulerAngles = new Vector3 (0f, 0f, Angle);
        float NowTime = 0f;
        //easeを取得
        Func<float, float, float> Ease = new EaseSwith (ease.paramator).get ();
        float AngleSpan = Angle - Ease (NowTime, Time) * Angle;
        while (NowTime < Time) {
            //再計算
            AngleSpan = Angle - Ease (NowTime, Time) * Angle;
            this.gameObject.transform.localEulerAngles = new Vector3 (0f, 0f,
                AngleSpan
            );
            NowTime += TimeSpan;
            yield return new WaitForSecondsRealtime (TimeSpan);
        }
        this.gameObject.transform.localEulerAngles = new Vector3 (0f, 0f, 0f);

        //必ず
        Destroy (this.gameObject.GetComponent<Roll> ());
    }
}