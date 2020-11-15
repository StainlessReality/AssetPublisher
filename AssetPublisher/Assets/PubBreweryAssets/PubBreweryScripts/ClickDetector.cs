using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickDetector : MonoBehaviour 
{
	private RaycastHit hit; // will store information about what has been clicked
	private Animator anim; //will represent the animator component of the clicked object
	private bool haveHitSomething; //answer to whether something is hit
	private string gameObjectName;//will store the name of the object with animation controller
	private string triggerName;//will store the name of the animator controller trigger parameter to be fired
	private Transform objectWithAnimCtrler;// wiss store the transform of the object with animation controller

	// Update is called once per frame
	void Update () 
	{
        //If the LMB has been pressed, shoot a ray and trigger appropriate action
		if (Input.GetMouseButtonDown(0))
        {
			//This boolean holds the answer to whether a collider has been hit
			haveHitSomething = CastRay();

			ExecuteClickAction();
		}
	}

	private bool CastRay()
    {
		//Cast a ray at the mouse position
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

		//Check if the ray has hit something. The answer is stored in haveHitSomething
		//The object it hits is stored using 'hit'
		haveHitSomething = Physics.Raycast(ray, out hit, 100.0f);
		return haveHitSomething;
    }


	private void ExecuteClickAction()
    {
        if (haveHitSomething)
        {
            //Does the thing you clicked have a transform?
			if (hit.transform != null)
            {
                //Does it also have an Animator component?
				if (hit.transform.GetComponent<Animator>() != null)
                {
					gameObjectName = hit.transform.gameObject.name;//Store name of the collider's object
					anim = hit.transform.GetComponent<Animator>(); //Store the object's animator component
					triggerName = gameObjectName + "_clicked"; //Build the relevant animator controller trigger parameter name
					print(triggerName);
					anim.SetTrigger(triggerName); //Fire the parameter in the appropriate animator component
				}
                //Does its parent have an animator component?
				else if(hit.transform.parent.GetComponent<Animator>() != null)
                {
					objectWithAnimCtrler = hit.transform.parent; //Get the parent of the object we just tried
					print("the thing you hit ("+ hit.transform.gameObject.name + ") has a transform, but no animator component. However, its first parent " + objectWithAnimCtrler.gameObject.name + " does!");
					gameObjectName = hit.transform.gameObject.name;
					anim = objectWithAnimCtrler.GetComponent<Animator>();
					triggerName = gameObjectName + "_clicked";
					print(triggerName);
					anim.SetTrigger(triggerName);
				}
				//Does the next parent up have an animator component?
				else if (hit.transform.parent.parent.GetComponent<Animator>() != null)
				{
					objectWithAnimCtrler = hit.transform.parent.parent;
					print("the thing you hit (" + hit.transform.gameObject.name + ") has a transform, but no animator component. However, its second parent " + objectWithAnimCtrler.gameObject.name + " does!");
					gameObjectName = hit.transform.gameObject.name;
					anim = objectWithAnimCtrler.GetComponent<Animator>();
					triggerName = gameObjectName + "_clicked";
					print(triggerName);
					anim.SetTrigger(triggerName);
				}
				//Does the next parent up have an animator component?
				else if (hit.transform.parent.parent.parent.GetComponent<Animator>() != null)
				{
					objectWithAnimCtrler = hit.transform.parent.parent.parent;
					print("the thing you hit (" + hit.transform.gameObject.name + ") has a transform, but no animator component. However, its third parent " + objectWithAnimCtrler.gameObject.name + " does!");
					gameObjectName = hit.transform.gameObject.name;
					anim = objectWithAnimCtrler.GetComponent<Animator>();
					triggerName = gameObjectName + "_clicked";
					print(triggerName);
					anim.SetTrigger(triggerName);
				}
				//Does the next parent up have an animator component?
				else if (hit.transform.parent.parent.parent.parent.GetComponent<Animator>() != null)
				{
					objectWithAnimCtrler = hit.transform.parent.parent.parent.parent;
					print("the thing you hit (" + hit.transform.gameObject.name + ") has a transform, but no animator component. However, its fourth parent " + objectWithAnimCtrler.gameObject.name + " does!");
					gameObjectName = hit.transform.gameObject.name;
					anim = objectWithAnimCtrler.GetComponent<Animator>();
					triggerName = gameObjectName + "_clicked";
					print(triggerName);
					anim.SetTrigger(triggerName);
				}
				//Give up trying at this point, this object is probably not animated.
				else
                {
					print("the thing you hit (" + hit.transform.gameObject.name + ") has a transform, but no animator component. There is also no parent with an animator component");

				}
            }
            else
            {
				print("the thing you clicked has no transform component");
            }
        }
        else
        {
			print("no collider has been hit by raycast");
        }
    }
}
