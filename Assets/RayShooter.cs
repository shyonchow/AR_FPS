using UnityEngine;
using System.Collections;

public class RayShooter : MonoBehaviour {
    [SerializeField] private GameObject bulletPrefab;
    private GameObject _bullet;
    public LayerMask lm;
    private Camera _cam;
    public float damage;
    public float critical;
    public Transform target;
    //private PlayerBullet bulletFn;

    // Use this for initialization
    void Start() {
        //bulletFn = bulletPrefab.GetComponent<PlayerBullet>();
        _cam = Camera.main;
        transform.LookAt(target.position);
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetMouseButtonDown(0))
        //if (Input.touchCount == 1)
        {
            //  Touch touch = Input.GetTouch(0);


            // if (touch.phase == TouchPhase.Began)
            //{
            Vector3 point = new Vector3(_cam.pixelWidth / 2, _cam.pixelHeight / 2, 0);
            Ray ray = _cam.ScreenPointToRay(point);
            RaycastHit hit;
            _bullet = Instantiate(bulletPrefab) as GameObject;
            _bullet.transform.position = transform.TransformPoint(Vector3.forward * 1.5f);
            _bullet.transform.forward = transform.forward;
            _bullet.transform.parent = transform.parent;
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, lm)) {
                Debug.Log("Enemy hit: " + hit.collider.gameObject.name);
                GameObject hitObject = hit.transform.gameObject;
                ReactiveTarget target = hitObject.GetComponent<ReactiveTarget>();
                //bulletFn.GetPoints(hit.point);

                if (target != null) {
                    if (true) {
                        target.ReactToHit(damage);
                    } else if (hitObject.name == "8") {
                        target.ReactToHit(critical);
                    }
                }
                //StartCoroutine(HitIndicate(hit.point));
            }
        }
    }



    private IEnumerator HitIndicate(Vector3 pos) {
        GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube.transform.position = pos;

        yield return new WaitForSeconds(0.1f);

        Destroy(cube);
    }
}
