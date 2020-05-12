using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Noise : MonoBehaviour {
    private readonly float TimeSpan = 0.25f;
    private List<IEnumerator> Wait = new List<IEnumerator> ();
    public IEnumerator noise (float Time, int Count, Vector2 RandomRange) {
        for (int i = 0; i < Count; i++) {
            GameObject g = Instantiate (this.gameObject);
            g.transform.SetParent (this.gameObject.transform, false);
            Wait.Add (NoiseGen (g, RandomRange));
            yield return new WaitForSeconds (TimeSpan);
        }
        yield return Wait;
        //必ず
        Destroy (this.gameObject.GetComponent<Noise> ());
    }

    private IEnumerator NoiseGen (GameObject g, Vector2 RandomRange) {
        float span = 0.02f;
        float xmax = Random.Range (0, RandomRange.x);
        float ymax = Random.Range (0, RandomRange.y);
        g.transform.position = new Vector3 (
            g.transform.position.x - xmax,
            g.transform.position.y - ymax,
            g.transform.position.z
        );
        for (int i = 0; i < 10; i++) {
            g.transform.position = new Vector3 (
                g.transform.position.x - xmax,
                g.transform.position.y - ymax,
                g.transform.position.z
            );
            yield return new WaitForSeconds (span);

            g.transform.position = new Vector3 (
                g.transform.position.x + xmax,
                g.transform.position.y + ymax,
                g.transform.position.z
            );
            yield return new WaitForSeconds (span);
        }
        Destroy (g);
    }
}