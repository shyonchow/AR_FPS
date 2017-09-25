using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EnemyInfo : MonoBehaviour {

    public float hp;
    public float maxhp;
    //public ParticleSystem boom;
    //public AudioSource boom2;
    //public AudioClip sound;
    public GameObject ship;


    public void Death() {

        StartCoroutine(Die());
    }
    private IEnumerator Die() {
        //boom.Play();
        //boom2.PlayOneShot(sound);

        yield return new WaitForSeconds(0.5f);

        Destroy(ship);


    }

}
