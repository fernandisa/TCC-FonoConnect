using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class dropPaciente : MonoBehaviour {
	public Dropdown menu;
	public static int valor;
	// Use this for initialization
	void Start () {
		Debug.Log (valor);
	}
	private void ProcessaMenu (Dropdown mDropdown) {
		valor = mDropdown.value;

		Debug.Log ("valor dropdown: " + mDropdown.value);
	}
	// Update is called once per frame
	void Update () {
		menu.onValueChanged.AddListener (delegate {
			ProcessaMenu (menu);
		});
	}

}
