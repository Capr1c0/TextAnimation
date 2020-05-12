using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rescale : MonoBehaviour {
    private readonly float TimeSpan = 0.02f;
    public IEnumerator rescale (float Time, Vector3 min, Vector3 max) {
        float NowTime = 0f;
        this.gameObject.transform.localScale = min;
        Vector3 VecSpan = (max - min) / (Time / TimeSpan);
        while (NowTime < Time) {
            this.gameObject.transform.localScale += VecSpan;
            NowTime += TimeSpan;
            yield return new WaitForSeconds (TimeSpan);
        }
        this.gameObject.transform.localScale = max;
        //必ず
        Destroy (this.gameObject.GetComponent<Rescale> ());
    }
}