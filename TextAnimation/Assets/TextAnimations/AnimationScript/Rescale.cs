using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Rescale : MonoBehaviour {
    private readonly float TimeSpan = 0.02f;
    public IEnumerator rescale (float Time, Vector3 min, Vector3 max, easetype ease) {
        float NowTime = 0f;
        if (this.gameObject.GetComponent<RectTransform> () == null || min.z == 9999f && max.z == 9999f) {
            this.gameObject.transform.localScale = min;
        } else {
            this.gameObject.GetComponent<RectTransform> ().sizeDelta = new Vector2 (min.x, min.y);
        }
        Vector3 Sabun = max - min;
        //easeを取得
        Func<float, float, float> Ease = new EaseSwith (ease.paramator).get ();
        while (NowTime < Time) {
            if (this.gameObject.GetComponent<RectTransform> () == null || min.z == 9999f && max.z == 9999f) {
                this.gameObject.transform.localScale = min + Ease (NowTime, Time) * Sabun;
            } else {
                this.gameObject.GetComponent<RectTransform> ().sizeDelta = min + Ease (NowTime, Time) * Sabun;
            }
            NowTime += TimeSpan;
            yield return new WaitForSecondsRealtime (TimeSpan);
        }
        if (this.gameObject.GetComponent<RectTransform> () == null || min.z == 9999f && max.z == 9999f) {
            this.gameObject.transform.localScale = max;
        } else {
            this.gameObject.GetComponent<RectTransform> ().sizeDelta = max;
        }
        //必ず
        Destroy (this.gameObject.GetComponent<Rescale> ());
    }
}