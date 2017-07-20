using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class configuracoes : MonoBehaviour {

	public Text msgAtualizado;
	// Use this for initialization
	void Start () {
		if (configurarPaciente.atualizada) {
			msgAtualizado.color = Color.green;
			msgAtualizado.text = "Paciente atualizado com sucesso";
			configurarPaciente.atualizada = false;
		}

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
