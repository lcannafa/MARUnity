using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using System.Text;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnPantalla : MonoBehaviour { //Clase que controla la interfaz gráfica


	private GUIStyle guiStyle; //Instancia del objeto usado para manejar el texto que aparece en pantalla
	LeeJson lj = new LeeJson(); //Instancia de la clase en la que quedan guardados los datos del Json enviado por la máquina
	private int rotar;
	// Use this for initialization
	void Start () {
	guiStyle = new GUIStyle(); //Inicia la instancia del texto
	StartCoroutine(getUnityWebRequest());
	}

	
	// Update is called once per frame
	void OnGUI () { //Método de unity para mostrar en la interfaz gráfica
		
		guiStyle.fontSize = 75; //Tamaño de la letra de los labels que apareceran en la GUI
		GUILayout.Label("Posicion en Y: "+ lj.x+"mm", guiStyle); //Label con la posición actual de la máquina en el eje x
		GUILayout.Label("Posicion en X: "+ lj.y + "mm", guiStyle); //Label con la posición actual de la máquina en el eje y
		GUILayout.Label("Corriente: "+ lj.corriente + " A", guiStyle); //Label con la corriente de la máquina
		GUILayout.Label("Voltaje: "+ lj.voltaje + " V", guiStyle); //Label con el voltaje de la máquina
		
		
	}
	IEnumerator getUnityWebRequest() // Método el cual trae de un url un Json
	{
		while (true)
		{
		UnityWebRequest www = UnityWebRequest.Get ("https://machinear-node.herokuapp.com/api/variables"); //Hace un GET al url y lo guarda en la variable www
		yield return www.Send();
 
		if(www.isNetworkError || www.isHttpError) {
			Debug.Log(www.error); //Manejo de errores
		}
		else {
			lj = JsonUtility.FromJson<LeeJson>(www.downloadHandler.text); //Guarda el Json en nuestro objeto lj (instancia de la clase LeeJson)
		}
		yield return new WaitForSeconds(1);
	}
	}
}