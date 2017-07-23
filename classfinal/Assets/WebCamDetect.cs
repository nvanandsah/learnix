using UnityEngine;
using UnityEngine.Collections;
public class WebCamDetect : MonoBehaviour
{	public string Ishost = "You are the teacher";
	void OnGUI(){
		GUI.Label (new Rect (10, 10, 10, 10), Ishost);
	}
	public bool isSet = true;
	void Start()
	{	
		WebCamDevice[] devices = WebCamTexture.devices;
		Debug.Log ("Number of web cams connected: " + devices.Length);

		for (int i = 0; i < devices.Length; i++) {
			Debug.Log (i + " " + devices [i].name);
		}

		Renderer rend = this.GetComponentInChildren<Renderer> ();

		WebCamTexture mycam = new WebCamTexture ();
		string camName = devices [0].name;
		Debug.Log ("The webcam name is " + camName);
		mycam.deviceName = camName;
		rend.material.mainTexture = mycam;

		mycam.Play ();
		isSet = false;
	}
	void Update(){
		if (!Network.isServer) {
			Debug.Log ("Student entered the class");
			Ishost = "You are Studnet";
		}
	}
}