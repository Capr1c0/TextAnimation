using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorChange : MonoBehaviour {
    private readonly float TimeSpan = 0.02f;
    public IEnumerator colorchange (float Time, string PropertyName, Color color) {
        float NowTime = 0f;
        Color Now;
        if (this.gameObject.GetComponent<RawImage> () != null) {
            Now = this.gameObject.GetComponent<RawImage> ().color;
        } else if (this.gameObject.GetComponent<Text> () != null) {
            Now = this.gameObject.GetComponent<Text> ().color;
        } else {
            Now = this.gameObject.GetComponent<Renderer> ().material.GetColor (PropertyName);
        }
        Color sabun = (color - Now) / (Time / TimeSpan);
        while (NowTime < Time) {
            Now += sabun;
            if (this.gameObject.GetComponent<RawImage> () != null) {
                this.gameObject.GetComponent<RawImage> ().color = Now;
            } else if (this.gameObject.GetComponent<Text> () != null) {
                this.gameObject.GetComponent<Text> ().color = Now;
            } else {
                this.gameObject.GetComponent<Renderer> ().material.SetColor (PropertyName, Now);
            }
            NowTime += TimeSpan;
            yield return new WaitForSeconds (TimeSpan);
        }

        if (this.gameObject.GetComponent<RawImage> () != null) {
            this.gameObject.GetComponent<RawImage> ().color = color;
        } else if (this.gameObject.GetComponent<Text> () != null) {
            this.gameObject.GetComponent<Text> ().color = color;
        } else {
            this.gameObject.GetComponent<Renderer> ().material.SetColor (PropertyName, color);
        }
        //必ず
        Destroy (this.gameObject.GetComponent<ColorChange> ());
    }
}