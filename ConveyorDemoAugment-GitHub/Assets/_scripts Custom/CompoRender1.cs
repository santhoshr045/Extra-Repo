using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using System;
using Vuforia;

public class CompoRender1 : MonoBehaviour
{

	private VuMarkManager mVuMarkManager;
	private VuMarkTarget mClosestVuMark;
	private VuMarkTarget mCurrentVuMark;


	// Use this for initialization
	void Start () 
	{
		Debug.Log (" Inside Compo Renderer 1 START ");
		mVuMarkManager = TrackerManager.Instance.GetStateManager().GetVuMarkManager();
		mVuMarkManager.RegisterVuMarkDetectedCallback(OnVuMarkDetected);
		mVuMarkManager.RegisterVuMarkLostCallback(OnVuMarkLost);

	}
	
	// Update is called once per frame
	void Update () 
	{
		UpdateClosestTarget();
	}

	void OnDestroy()
	{
		// unregister callbacks from VuMark Manager
		mVuMarkManager.UnregisterVuMarkDetectedCallback(OnVuMarkDetected);
		mVuMarkManager.UnregisterVuMarkLostCallback(OnVuMarkLost);
	}

	public void OnVuMarkDetected(VuMarkTarget target)
	{
		{
			string name = GetVuMarkString (target);
			if (name == "Vuforia000") 
			{
				Debug.Log (" Inside Compo Renderer 1 On Vumark Detected ");
				Renderer[] rendererComponents = GetComponentsInChildren<Renderer> (true);
				Collider[] colliderComponents = GetComponentsInChildren<Collider> (true);


				{
					// Enable rendering:
					foreach (Renderer component in rendererComponents) {
						component.enabled = true;
					}

					// Enable colliders:
					foreach (Collider component in colliderComponents) {
						component.enabled = true;
					}


				}
			}

		}
	}

	/// <summary>
	/// This method will be called whenever a tracked VuMark is lost
	/// </summary>
	public void OnVuMarkLost(VuMarkTarget target)
	{
		Debug.Log("Lost VuMark: " + GetVuMarkString(target));
		{
			Debug.Log (" Inside Compo Renderer 1 On Vumark Lost ");
			Renderer[] rendererComponents = GetComponentsInChildren<Renderer>(true);
			Collider[] colliderComponents = GetComponentsInChildren<Collider>(true);

			// Disable rendering:
			foreach (Renderer component in rendererComponents)
			{
				component.enabled = false;
			}

			// Disable colliders:
			foreach (Collider component in colliderComponents)
			{
				component.enabled = false;
			}
		}
		//if (target == mCurrentVuMark)
		//	mIdPanel.ResetShowTrigger();
	}



	void UpdateClosestTarget()
	{
		Camera cam = DigitalEyewearBehaviour.Instance.PrimaryCamera ?? Camera.main;

		float closestDistance = Mathf.Infinity;

		foreach (var bhvr in mVuMarkManager.GetActiveBehaviours())
		{
			Vector3 worldPosition = bhvr.transform.position;
			Vector3 camPosition = cam.transform.InverseTransformPoint(worldPosition);

			float distance = Vector3.Distance(Vector2.zero, camPosition);
			if (distance < closestDistance)
			{
				closestDistance = distance;
				mClosestVuMark = bhvr.VuMarkTarget;
			}
		}

		if (mClosestVuMark != null)
		{
			//var vuMarkId = GetVuMarkString(mClosestVuMark);
			//var vuMarkTitle = GetVuMarkDataType(mClosestVuMark);
			if (mCurrentVuMark != mClosestVuMark)
			{
				mCurrentVuMark = mClosestVuMark;
	
				//Call the Renderer component here
				//StartCoroutine here
				if (name == "Vuforia000") 
				{
					

					Renderer[] rendererComponents = GetComponentsInChildren<Renderer> (true);
					Collider[] colliderComponents = GetComponentsInChildren<Collider> (true);
					Animator animator = GetComponentInChildren<Animator> ();

					{
						// Enable rendering:
						foreach (Renderer component in rendererComponents) {
							component.enabled = true;
						}

						// Enable colliders:
						foreach (Collider component in colliderComponents) {
							component.enabled = true;
						}


					}
				}



			}
		}
	}

	private string GetVuMarkDataType(VuMarkTarget vumark)
	{
		switch (vumark.InstanceId.DataType)
		{
		case InstanceIdType.BYTES:
			return "Bytes";
		case InstanceIdType.STRING:
			return "String";
		case InstanceIdType.NUMERIC:
			return "Numeric";
		}
		return "";
	}

	private string GetVuMarkString(VuMarkTarget vumark)
	{
		switch (vumark.InstanceId.DataType)
		{
		case InstanceIdType.BYTES:
			return vumark.InstanceId.HexStringValue;
		case InstanceIdType.STRING:
			return vumark.InstanceId.StringValue;
		case InstanceIdType.NUMERIC:
			return vumark.InstanceId.NumericValue.ToString();
		}
		return "";
	}




}
