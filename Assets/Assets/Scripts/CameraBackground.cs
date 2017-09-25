using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CameraBackground : MonoBehaviour {
    private RawImage _image;
    private WebCamTexture _cam;
    private AspectRatioFitter _arf;

    void Start() {
        _arf = GetComponent<AspectRatioFitter>();
        _image = GetComponent<RawImage>();

        WebCamDevice[] devices = WebCamTexture.devices;
        var deviceName = devices[0].name;
        //int len = devices.Length;
        //for (int i = 0; i < len; i++)
        //{
        //    Debug.Log(i + "th device" + devices[i].name);
        //}
        _cam = new WebCamTexture(deviceName, Screen.width, Screen.height);
        _image.texture = _cam;
        _cam.Play();
    }

    void Update() {
        if (_cam.width < 100) {
            return;
        }

        float cwNeeded = -_cam.videoRotationAngle;
        if (_cam.videoVerticallyMirrored) {
            cwNeeded += 180f;

        }
        _image.rectTransform.localEulerAngles = new Vector3(0f, 0f, cwNeeded);

        float videoRatio = (float) _cam.width / (float) _cam.height;
        _arf.aspectRatio = videoRatio;

    }

}
