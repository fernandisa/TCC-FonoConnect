using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveOffset : MonoBehaviour {

	public Material currentMaterial;
	public float speed;
	private float offSet;
	// Use this for initialization
	void Start () {
		currentMaterial = GetComponent<Renderer>().material; //carregando os materiais existentes no renderer onde o script se encontra
	}
	
	// Update is called once per frame
	void Update () {
		offSet += speed * Time.deltaTime; //corrigir a velocidade p ficar a msm em 30 ou 60 frames
		currentMaterial.SetTextureOffset("_MainTex", new Vector2(offSet, 0));
	}
}
