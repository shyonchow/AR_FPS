using UnityEngine;
using System.Collections;

public class Carousel : MonoBehaviour {

    public float speed;
    //private Quaternion qTo;
    private float timeElapsed = 0.0f;
    //public float maxRotate;

    void Start() {
        //qTo = Quaternion.Euler(new Vector3(Random.Range(-30.0f, 30.0f), Random.Range(-90.0f, 90.0f), Random.Range(-30.0f, 30.0f)));
    }



    public void RotateAround(float q, float t) {
        Quaternion qTo = transform.rotation;
        qTo.y = q;
        StartCoroutine(WaitMove(qTo, t));
    }

    private IEnumerator WaitMove(Quaternion q, float t) {
        yield return new WaitForSeconds(0.75f);
        transform.rotation = Quaternion.Slerp(transform.rotation, q, t);
    }

    // Update is called once per frame
    void Update() {

        //timeElapsed += Time.deltaTime;

        //float y = transform.rotation.eulerAngles.y;
        //Debug.Log(y);

        //if (timeElapsed >= timer) {
        //    qTo = Quaternion.Euler(new Vector3(Random.Range(-30.0f, 30.0f), Random.Range(-15.0f, 15.0f), Random.Range(-30.0f, 30.0f)));
        //    timeElapsed = 0.0f;
        //}

        //transform.rotation = Quaternion.Slerp(transform.rotation, qTo, Time.deltaTime * speed);
        float x = 0.75f * Mathf.Sin(5f * Time.time);
        float z = 0.75f * Mathf.Sin(5 * (Time.time + (Mathf.PI / 2)));
        float y = speed * Time.deltaTime;
        transform.Rotate(x, y, z);
        //Debug.Log("Y speed:" + y)

    }
}
