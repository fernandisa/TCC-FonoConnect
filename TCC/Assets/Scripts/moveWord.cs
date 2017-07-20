using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveWord : MonoBehaviour {

	public float speed, x; // a velocidade(speed) tem q ser negativa p a barrier andar p esquerda
	public static bool colidedWord;
	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {
		x = transform.position.x;
		x += speed * Time.deltaTime; //velocidade baseada no tempo e n em qntos cm por quadro
		transform.position = new Vector3(x,transform.position.y); //ganhando uma nova posição

		if (x <= -7)
		{
			Destroy (transform.gameObject);
			Debug.Log ("Objeto destruido");
		}
		// só vai somar ponto se ele ir p tela get and set text e acertar a pronúncia
	}

	void OnTriggerEnter2D ()
	{
		Debug.Log ("Bateu na PALAVRA");
		colidedWord = true;
	}
}