using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

    public Transform player;
    private Transform origin;
    private Vector3 vTo;
    private float timer = 5;
    private float timeElapsed = 0f;
    private CharacterController controller;
    private Camera cam;
    private Carousel carousel;
    private Vector3 moveDiretion;

    void Start() {
        carousel = GetComponentInParent<Carousel>();
        cam = Camera.main;
        controller = GetComponent<CharacterController>();
        origin = this.GetComponent<Transform>();
        vTo = new Vector3(Random.Range(-75f, 75f), Random.Range(-20f, 20f), Random.Range(-75f, 75f));
    }

    void Update() {
        transform.LookAt(player);

        timeElapsed += Time.deltaTime;
        Vector3 delta = player.position - transform.position;
        Vector3 viewPos = cam.WorldToViewportPoint(transform.position);
        float t = timeElapsed / timer;
        t = t * t * t * (t * (6f * t - 15f) + 10f);

        if (timeElapsed >= timer) {
            vTo = new Vector3(Random.Range(-75f, 75f), Random.Range(-20f, 20f), Random.Range(-75f, 75f));
            if (Mathf.Abs(vTo.x) < 40) { vTo.x = 40; }
            if (Mathf.Abs(vTo.z) < 40) { vTo.z = 40; }
            timeElapsed = 0f;
        }

        if (viewPos.x >= 1 || viewPos.x <= 0 || viewPos.y >= 1 || viewPos.y <= 0) {
            //Debug.Log("Off Camera");
            carousel.RotateAround(cam.transform.parent.transform.rotation.y, t);
        }

        if (delta.magnitude > 100) {
            vTo = player.position - transform.position;
        } else if (delta.magnitude < 50) {
            vTo = cam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 60));
        }


        controller.Move(0.2f * vTo * Time.deltaTime);



        //Vector3 pos = transform.position;

        //transform.position = Vector3.Lerp(pos, vTo, t);


        //float tolerance = 15f;
        //Random.Range(0, 10);

        //if (Mathf.Abs(transform.position.x - origin.position.x) < tolerance) {
        //    //transform.Translate();
        //}

    }
}
