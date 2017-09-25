using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyChecker : MonoBehaviour {

    GameObject[] enemies;
    int len = 10;
    public Text winner;
    public Text score;



    // Update is called once per fram
    void Update() {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        len = enemies.Length;
        score.text = len.ToString();
        Debug.Log(len);
        if (len < 1) {
            winner.text = "YOU WIN";
        }

    }
}
