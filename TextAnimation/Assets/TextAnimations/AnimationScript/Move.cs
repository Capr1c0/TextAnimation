using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour {
    private readonly float TimeSpan = 0.02f;
    public IEnumerator move (float Time, Vector3 VecMax) {
        float NowTime = 0f;
        Vector3 ans = this.gameObject.transform.localPosition + VecMax;
        Vector3 Sabun = VecMax /  (Time / TimeSpan);
        while (NowTime < Time) {
            this.gameObject.transform.localPosition+=Sabun;
            NowTime += TimeSpan;
            yield return new WaitForSeconds (TimeSpan);
        }
        this.gameObject.transform.localPosition = ans;
        //必ず
        Destroy (this.gameObject.GetComponent<Move> ());
    }
}