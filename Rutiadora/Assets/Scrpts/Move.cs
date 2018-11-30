using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using System.Text;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Move : MonoBehaviour { //Clase que mueve el eje X del módelo
	float x;
    float z;
    //Variable para guardar el valor de la posición en x
	//LeeJson lj = new LeeJson(); //Otra vez instanciamos la clase LeeJson para traer los datos lo más rápido posible
	public MoveOnAxis move;
	//void Start() {
	//	StartCoroutine(getUnityWebRequest());	
	//}
	// Update is called once per frame
	void Update () {
        z = move.lj.y;
            ///1250.0f; //Escalamos el valor traido del Json para el módelo en unity
		transform.localPosition = new Vector3( transform.position.x, transform.position.y, z); //Transformamos la posición de x del objeto a la traida del json
	}


	/* IEnumerator getUnityWebRequest() //Otra vez el método que lee los datos del Json
	{
		UnityWebRequest www = UnityWebRequest.Get ("https://machinear-node.herokuapp.com/api/variables");
		yield return www.Send();
 
		if(www.isNetworkError || www.isHttpError) {
			Debug.Log(www.error);
		}
		else {
			lj = JsonUtility.FromJson<LeeJson>(www.downloadHandler.text);
		}		
		yield return new waitForSeconds(1);
	}*/
}