using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickDetector : MonoBehaviour 
{
	private RaycastHit hit;
	private bool haveHitSomething;

	// Update is called once per frame
	void Update () 
	{
        if (Input.GetMouseButtonDown(0))
        {
			haveHitSomething = CastRay();
			PrintName();
		}
	}

	private bool CastRay()
    {
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		haveHitSomething = Physics.Raycast(ray, out hit, 100.0f);
		return haveHitSomething;
    }

	private void PrintName()
    {
		if (haveHitSomething && hit.transform != null)
		{
				print(gameObject.name);
		}		
    }
}
