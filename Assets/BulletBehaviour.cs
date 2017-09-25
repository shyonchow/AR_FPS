using UnityEngine;
using System.Collections;

public class BulletBehaviour : MonoBehaviour {

    public float speed = 10.0f;
    private int damage = 10;
    private PlayerCharacter player;

    // Update is called once per frame
    void Update() {
        transform.Translate(0, 0, speed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            player = other.GetComponentInParent<PlayerCharacter>();

            player.health -= damage;

            Debug.Log(player.health);
        }

        Destroy(this.gameObject);
    }
}
