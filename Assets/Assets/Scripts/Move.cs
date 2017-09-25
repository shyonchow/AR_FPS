using UnityEngine;
using System.Collections;

public class Move : MonoBehaviour
{

    private float speed = 1f;
    public Transform origin;


    // Update is called once per frame
    void Update()
    {
        transform.Translate(speed * Time.deltaTime, 0, 0);
        Vector3 target = new Vector3(origin.position.x, transform.position.y, origin.position.z);
        transform.LookAt(target);
    }
}
