using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clickCheck : MonoBehaviour {

	public static bool clickCheckBool;

	void OnMouseDown()
	{		
		clickCheckBool = true;
	}
}
