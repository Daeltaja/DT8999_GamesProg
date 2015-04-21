using UnityEngine;
using System.Collections;
//an abstract class is like a blueprint - any classes or states that inherit from it, must contain the same members as it (methods, constructors etc)
public abstract class State {
	
	protected GameObject myGameObject;//protected means you inheriting classes can access the variable
	public State(GameObject gameobject) //constructor which assigns myGameObject
	{
		this.myGameObject = gameobject;
	}
	public abstract void Update(); //abstract methods must appear in class/states that inherit from this class
	public abstract void Enter();
	public abstract void Exit();
}
