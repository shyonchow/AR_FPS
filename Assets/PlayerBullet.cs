using UnityEngine;
using System.Collections;

public class PlayerBullet : MonoBehaviour {
    //public Transform startPos;
    //public Transform endPos;
    public float speed = 10.0f;
    private Camera cam;
    private Rigidbody rb;

    void Start() {
        rb = GetComponent<Rigidbody>();
        cam = Camera.main;
        //endPos.position 
        //startPos.position = transform.position;
    }

    // Update is called once per frame
    void Update() {
        //Vector3 screenPos = cam.WorldToScreenPoint(rb.transform.position);
        ////Debug.Log("screen pos: " + screenPos);
        //if (Mathf.Abs(screenPos.x - Screen.width / 2) <= 5f && Mathf.Abs(screenPos.y - Screen.height / 2) <= 5f) {
        //    Destroy(this.gameObject);
        //}
        transform.Translate(0, 0, speed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other) {
        Debug.Log("Boundary: " + other.gameObject.name);
        Destroy(this.gameObject);
    }

    void OnCollisionEnter(Collision other) {
        Destroy(this.gameObject);
    }

    //    public void GetPoints(Vector3 point)
    //    {
    //        endPos.position = point;
    //    }
}