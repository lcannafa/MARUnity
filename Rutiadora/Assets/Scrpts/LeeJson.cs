using System;

[Serializable] //Se deben serializar los datos traidos del Json
public class LeeJson //Clase que trae los datos del Json
{

	public string _id; //Primera variable traida del Json (generada automáticamente)
	public float voltaje; //Variable de voltaje
	public float corriente; //Variable de corriente
	public float y; //Variable de posición en Y
	public float x; //Variable de posición en X
	public int __v; //Variable generada automáticamente 
}	


