using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Mono.Data.Sqlite; 
using System.Data; 
//using System;

public class editTextMesh : MonoBehaviour {

	public static string displayText;
	private TextMesh testMesh;

	// Use this for initialization
	void Start () {
		testMesh = GetComponent<TextMesh>();
		testMesh.text = spawnController.palavra;
	}
		
		
	}

