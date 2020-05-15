using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Roll : MonoBehaviour {
    private readonly float TimeSpan = 0.02f;
    public IEnumerator roll (float Time, float Angle, easetype ease) {
        //this.gameObject.transform.localEulerAngles = new Vector3 (0f, 0f, Angle);
        Vector3 NowAngle = this.gameObject.transform.localEulerAngles;
        Vector3 AnsAngle = this.gameObject.transform.localEulerAngles + new Vector3 (0f, 0f, Angle);
        float NowTime = 0f;
        //easeを取得
        Func<float, float, float> Ease = new EaseSwith (ease.paramator).get ();
        float AngleSpan = Angle - Ease (NowTime, Time) * Angle;
        while (NowTime < Time) {
            //再計算
            AngleSpan = (Ease (NowTime, Time) * Angle) - Angle;
            Vector3 AddingAngle = new Vector3 (0f, 0f, AngleSpan);

            this.gameObject.transform.localEulerAngles = AnsAngle - AddingAngle;

            NowTime += TimeSpan;
            yield return new WaitForSecondsRealtime (TimeSpan);
        }
        this.gameObject.transform.localEulerAngles = new Vector3 (NowAngle.x, NowAngle.y, Angle + NowAngle.z);

        //必ず
        Destroy (this.gameObject.GetComponent<Roll> ());
    }
}