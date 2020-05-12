using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Roll : MonoBehaviour {
    private readonly float TimeSpan = 0.02f;
    public IEnumerator roll (float Time, float Angle ) {
        float AngleSpan = Angle / (Time / TimeSpan);
        this.gameObject.transform.localEulerAngles = new Vector3 (0f, 0f, Angle);
        float NowTime = 0f;
        while (NowTime < Time) {
            this.gameObject.transform.localEulerAngles = new Vector3 (0f, 0f,
                this.gameObject.transform.localEulerAngles.z - AngleSpan
            );
            NowTime += TimeSpan;
            yield return new WaitForSeconds (TimeSpan);
        }
        this.gameObject.transform.localEulerAngles = new Vector3 (0f, 0f, 0f);

        //必ず
        Destroy(this.gameObject.GetComponent<Roll>());
    }
}