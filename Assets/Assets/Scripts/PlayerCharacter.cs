using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerCharacter : MonoBehaviour {


    public float health = 1000f;
    public float healthbar = 1000f;
    public Text lose;

    // Update is called once per frame
    void Update() {
        if (health <= 0) {
            Time.timeScale = 0;
            lose.text = "YOU LOSE";
        }
    }

    void OnGUI() {
        healthbar = GUI.VerticalScrollbar(new Rect(Screen.width - 50, Screen.height / 3, 60, 700), 0, health, 0f, 500);
    }
}
