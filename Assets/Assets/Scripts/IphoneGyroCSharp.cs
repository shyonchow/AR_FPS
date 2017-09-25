using UnityEngine;
using System.Collections;

public class IphoneGyroCSharp : MonoBehaviour {

	private bool gyroBool;
	private Gyroscope gyro;
	private Quaternion rotFix;
	//public AndroidBridge androidBridge;
	//private Converter converter;
	Transform originalParent;
	GameObject camParent ;
	// Use this for initialization
	void Start () {

	//	converter = new Converter();
	//	androidBridge = GameObject.Find ("Native_Bridge").GetComponent<AndroidBridge> ();
	//	androidBridge.ReadBluetooth ();
		originalParent = transform.parent; // check if this transform has a parent
		camParent = new GameObject ("camParent"); // make a new parent
		Input.gyro.enabled = true;
		//	Screen.orientation = ScreenOrientation.Portrait;
			

	//	if (!PlayerPrefs.HasKey ("DiamondToolCaliberator")){
	//		PlayerPrefs.SetString("DiamondToolCaliberator","90,0,0");
	//	} 	    

		Intialize ();
	
	}

	public void Intialize(){
		if (Screen.orientation == ScreenOrientation.LandscapeLeft) {
		//	camParent.transform.eulerAngles = converter.StringToVector(PlayerPrefs.GetString("DiamondToolCaliberator"));
			camParent.transform.eulerAngles = new Vector3(90,0,0);
		} 
		else if (Screen.orientation == ScreenOrientation.Portrait) {
		//	camParent.transform.eulerAngles = converter.StringToVector(PlayerPrefs.GetString("DiamondToolCaliberator"));
			camParent.transform.eulerAngles = new Vector3(90,0,0);
			
		}
		
		if (Screen.orientation == ScreenOrientation.LandscapeLeft) {
			rotFix = new Quaternion (0f, 0f, 1f, 0f);
			//rotFix = new Quaternion (0f, 0f, 0.7071f, 0.7071f);
		} else if (Screen.orientation == ScreenOrientation.Portrait) {
			rotFix = new Quaternion (0f, 0f, 1f, 0f);
		}
		
		camParent.transform.position = transform.position; // move the new parent to this transform position
		transform.parent = camParent.transform; // make this transform a child of the new parent
		camParent.transform.parent = originalParent;
	}


	// Update is called once per frame
	void Update () {

	//Quaternion camRot = androidBridge.quaternion * rotFix;
		Quaternion camRot = Input.gyro.attitude * rotFix;
			transform.localRotation = camRot;

	}
}
