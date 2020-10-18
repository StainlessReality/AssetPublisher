using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickDetector : MonoBehaviour 
{
	private RaycastHit hit;
	private Animator anim;
	private bool haveHitSomething;
	private string gameObjectName;
	private string triggerName;
	private Transform objectWithAnimCtrler;

	// Update is called once per frame
	void Update () 
	{
        if (Input.GetMouseButtonDown(0))
        {
			haveHitSomething = CastRay();
			ExecuteClickAction();
		}
	}

	private bool CastRay()
    {
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		haveHitSomething = Physics.Raycast(ray, out hit, 100.0f);
		return haveHitSomething;
    }


	private void ExecuteClickAction()
    {
        if (haveHitSomething)
        {
            if (hit.transform != null)
            {
                if (hit.transform.GetComponent<Animator>() != null)
                {
					gameObjectName = hit.transform.gameObject.name;
					anim = hit.transform.GetComponent<Animator>();
					triggerName = gameObjectName + "_clicked";
					print(triggerName);
					anim.SetTrigger(triggerName);
				}
                else if(hit.transform.parent.GetComponent<Animator>() != null)
                {
					objectWithAnimCtrler = hit.transform.parent;
					print("the thing you hit ("+ hit.transform.gameObject.name + ") has a transform, but no animator component. However, its first parent " + objectWithAnimCtrler.gameObject.name + " does!");
					gameObjectName = hit.transform.gameObject.name;
					anim = objectWithAnimCtrler.GetComponent<Animator>();
					triggerName = gameObjectName + "_clicked";
					print(triggerName);
					anim.SetTrigger(triggerName);
				}
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
