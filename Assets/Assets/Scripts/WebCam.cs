using UnityEngine;
using System.Collections;

public class WebCam : MonoBehaviour
{

    void Start()
    {
        WebCamDevice[] devices = WebCamTexture.devices;
        string backCamName = "";
        int len = devices.Length;
        for (int i = 0; i < len; i++)
        {
            Debug.Log("Device:" + devices[i].name + "IS FRONT FACING:" + devices[i].isFrontFacing);

            if (!devices[i].isFrontFacing)
            {
                backCamName = devices[i].name;
            }
        }

        WebCamTexture webcamTexture = new WebCamTexture(backCamName, Screen.width, Screen.height);
        Renderer renderer = GetComponent<Renderer>();
        renderer.material.mainTexture = webcamTexture;
        webcamTexture.Play();
    }

}
