﻿using UnityEngine;
using System.Collections;

public class Roaming : MonoBehaviour {

	Vector3 newpos = new Vector3();
	Quaternion newrot = new Quaternion();

	// Use this for initialization
	void Start () {
		SocketDispatch.On ("GVR", handleMocap);
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = newpos;
		transform.rotation = newrot;
	}

	void handleMocap(Google.Protobuf.VRCom.MocapSubject head) {
		// the data coming in is OpenGL convention, X Right, Y UP, Z Backward
		// Unity is the same but with Z pointing forward.
		newpos.Set (head.Pos.X/1000, head.Pos.Y/1000, -head.Pos.Z/1000);
		newrot.Set (head.Rot.X, head.Rot.Y, head.Rot.Z, -head.Rot.W);

	}
}