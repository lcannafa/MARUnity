using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using System.Text;
using System;
using UnityEngine.UI;

public class MoveOnAxis : MonoBehaviour { //Clase que mueve el eje Y del módelo (conectada al eje x)
	
	public LeeJson lj = new LeeJson();
	public float z; //Variable para guardar la posición en y de la máquina (Se llama z ya que el eje y de la máquina, es el z del modelo de unity)
	public float x; //Variable para guardar la posición en x de la máquina 
    public Boolean neg;	//Se vuelve a tomar la variable en x, para que el módelo no se mueva por separado
    public float firstX;
    public float secondX;
    public float firstY;
    public float secondY;
    public float vel;
    public float velY;
    public float timeError=0.6f;
    public GameObject ejeY;
    public Vector3 velocityVector;
    public Vector3 velocityVectory;
    // Update is called once per frame
    void Start() {
		StartCoroutine(getUnityWebRequestStart());
        Debug.Log("starting");
	}
	void Update () {
        ///1250.0f; //Escala de la máquina para el modelo de unity
		//z = lj.x;///(-1250.0f); //Escala de la máquina para el modelo de unity
        //z+200.0f
        //transform.GetComponent<Rigidbody>().velocity = new Vector3( 0, 0, z*0.004f); //Transformamos los ejes X y Z con las coordenadas obtenidas
        
    }


    IEnumerator getUnityWebRequest() //Método para traer los datos del Json, los usamos en todas las clases, para que los datos sean en tiempo real
    {
        while (true)
        {


            UnityWebRequest www = UnityWebRequest.Get("https://machinear-node.herokuapp.com/api/variables");
            yield return www.Send();

            if (www.isNetworkError || www.isHttpError) {
                Debug.Log(www.error);
                Debug.Log("errorcorutina");
            }
            else {
                lj = JsonUtility.FromJson<LeeJson>(www.downloadHandler.text);
            }
            secondX = 200+lj.x;
            secondY = lj.y;
            
            vel = -(secondX - firstX) / 1.0f;
            velY= (secondY - firstY) / 1.0f;
            transform.localPosition= new Vector3(firstX, 0, 0);
            ejeY.transform.localPosition = new Vector3(0, 0, firstY);

            velocityVector=transform.TransformPoint(new Vector3(secondX, 0, 0))- transform.TransformPoint(new Vector3(firstX, 0, 0));
            velocityVectory = ejeY.transform.TransformPoint(new Vector3(0, 0, secondY)) - ejeY.transform.TransformPoint(new Vector3(0, 0, firstY));
            transform.GetComponent<Rigidbody>().velocity = timeError * (velocityVector + velocityVectory);
            ejeY.transform.GetComponent<Rigidbody>().velocity = timeError * velocityVectory;
            //transform.GetComponent<Rigidbody>().velocity = new Vector3(timeError * velY * 0.004f, 0, timeError* vel * 0.004f);
            //ejeY.transform.GetComponent<Rigidbody>().velocity = new Vector3(timeError * velY * 0.004f, 0,0);

            /*
            if (lj.x > 0)
            {
                transform.localPosition = new Vector3(200, 0, 0);
            }
            else
            {
                transform.localPosition = new Vector3(100, 0, 0);
            }
            */
            yield return new WaitForSeconds(1.0f);
            firstX = secondX;
            firstY = secondY;
            Debug.Log("corutina");

        }
    }

    IEnumerator getUnityWebRequestStart() //Método para traer los datos del Json, los usamos en todas las clases, para que los datos sean en tiempo real
    {

            UnityWebRequest www = UnityWebRequest.Get("https://machinear-node.herokuapp.com/api/variables");
            yield return www.Send();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
                Debug.Log("errorcorutina");
            }
            else
            {
                lj = JsonUtility.FromJson<LeeJson>(www.downloadHandler.text);
            }
            firstX = 200 + lj.x;
        firstY = lj.y;
        
            transform.localPosition = new Vector3(firstX, 0, 0);
        ejeY.transform.localPosition = new Vector3(0, 0, firstY);
            StartCoroutine(getUnityWebRequest());






    }

}