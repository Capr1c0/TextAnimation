using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChange : MonoBehaviour {
    private readonly float TimeSpan = 0.02f;
    public IEnumerator colorchange (float Time, string PropertyName, Color color) {
        float NowTime = 0f;
        Color Now = this.gameObject.GetComponent<Renderer> ().material.GetColor (PropertyName);
        Color sabun = (color - Now) / (Time / TimeSpan);
        while (NowTime < Time) {
            Now += sabun;
            this.gameObject.GetComponent<Renderer> ().material.SetColor (PropertyName, Now);
            NowTime += TimeSpan;
            yield return new WaitForSeconds (TimeSpan);
        }
        this.gameObject.GetComponent<Renderer> ().material.SetColor (PropertyName, color);
        //必ず
        Destroy (this.gameObject.GetComponent<ColorChange> ());
    }
}