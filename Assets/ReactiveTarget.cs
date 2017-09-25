using UnityEngine;
using System.Collections;

public class ReactiveTarget : MonoBehaviour {

    private EnemyInfo ei;

    private void Start() {
        ei = GetComponentInParent<EnemyInfo>();
    }

    public void ReactToHit(float k) {
        if (ei.hp <= 0) {
            ei.Death();
        }
        ei.hp -= k * 0.1f * ei.maxhp;
        Debug.Log("Health:" + ei.hp);
    }


}
