using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{

    public void loadLevel(string name)
    {
        Application.LoadLevel(name);
    }

    //public void QuitRequest()
    //{
    //    Debug.Log("Quit requested");
    //    Application.Quit();
    //}

}
