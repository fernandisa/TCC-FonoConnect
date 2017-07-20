using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveBarrier : MonoBehaviour {

	public float speed, x; // a velocidade(speed) tem q ser negativa p a barrier andar p esquerda
	public GameObject Player;
	public bool pontuado;
	public static bool colidedBarrier;
	// Use this for initialization
	void Start () {
		Player = GameObject.Find ("Player") as GameObject;
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

		if (x < Player.transform.position.x && pontuado == false) // se a posicao do player tiver maior q a posicao do x(barreira), então soma 1 pt
		{
			pontuado = true; //p n acontecer mais d uma vez a pt até ele ser destruído 
			playerController.pontuacao++; // soma mais 1 na pontuacao
		}

	
	}

	void OnTriggerEnter2D ()
	{
		Debug.Log ("Bateu na BARREIRA");
		colidedBarrier = true;
	}
}
