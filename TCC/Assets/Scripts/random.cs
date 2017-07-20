using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class random : MonoBehaviour {
	public static int posicao, posRandom;
	public float posA = -0.1f;    //-0.803f;
	public float posD = -0.5f;
	public static float y;
	public static int difRandom;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		posicao = Random.Range (1, 3); //chamar obj aleatório.. 2 op: baixo ou cima
		posRandom = Random.Range (1, 3); //sortear a posicao da barreira 
		y = Random.Range (posA, posD); //sortear p ver se vai em cima ou embaixo
	
	}
}
