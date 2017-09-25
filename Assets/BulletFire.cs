using UnityEngine;
using System.Collections;

public class BulletFire : MonoBehaviour {

    [SerializeField] private GameObject bulletPrefab;
    private GameObject _bullet;

    // Update is called once per frame
    void Update() {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;
        if (Physics.SphereCast(ray, 0.75f, out hit)) {
            //Debug.Log(hit.collider);
            GameObject hitObject = hit.transform.gameObject;
            if (hitObject.CompareTag("Player")) {
                if (_bullet == null) {
                    _bullet = Instantiate(bulletPrefab) as GameObject;
                    _bullet.transform.position = transform.TransformPoint(Vector3.forward * 1.5f);
                    _bullet.transform.rotation = transform.rotation;
                }
            }
        }
    }
}
