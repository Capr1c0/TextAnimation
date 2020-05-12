using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TEMPLATE : MonoBehaviour {
    private readonly float TimeSpan = 0.02f;
    public IEnumerator noise (float Time, int Count) {
        float NowTime = 0f;
        
        while (NowTime < Time) {

            
            NowTime += TimeSpan;
            yield return new WaitForSeconds (TimeSpan);
        }
        //必ず
        Destroy (this.gameObject.GetComponent<TEMPLATE> ());
    }
}