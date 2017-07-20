using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class instantiate : MonoBehaviour {
	public Image imagem;
	// Use this for initialization
	void Start () {
		imagem.sprite = Resources.Load<Sprite>("Sprite/" + spawnController.palavra);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
