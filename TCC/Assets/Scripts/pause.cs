using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class pause : MonoBehaviour {
	public AudioSource audioL;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown (KeyCode.P) )
		{
			if (Time.timeScale == 1) {
				Time.timeScale = 0;
				audioL.enabled = false;
			} 
			else 
			{
				Time.timeScale = 1;
				audioL.enabled = true;
			}
					
				
		}
	}

}
