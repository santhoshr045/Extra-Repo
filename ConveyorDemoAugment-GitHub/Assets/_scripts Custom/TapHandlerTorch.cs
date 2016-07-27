using UnityEngine;
using System.Collections;
using Vuforia;

public class TapHandlerTorch : MonoBehaviour
{
	#region PRIVATE_MEMBERS
	private const float DOUBLE_TAP_MAX_DELAY = 0.5f;//seconds
	private int mTapCount = 0;
	private float mTimeSinceLastTap = 0;
	//private CameraSettings mCamSettings = null;
	//private MenuAnimator mMenuAnim = null;
	private bool mFlashTorchEnabled = false;
	#endregion //PRIVATE_MEMBERS


	#region MONOBEHAVIOUR_METHODS
	void Start() 
	{

		mTapCount = 0;
		mTimeSinceLastTap = 0;
	}

	void Update() 
	{
		if (mFlashTorchEnabled)
		{
			mTapCount = 0;	
			mTimeSinceLastTap = 0;
		}
		else
		{
			HandleTap();
		}

		#if UNITY_ANDROID
		// On Android, the Back button is mapped to the Esc key
		if (Input.GetKeyUp(KeyCode.Escape))
		{
		#if (UNITY_5_2 || UNITY_5_1 || UNITY_5_0)
	//	Application.LoadLevel("InstructionScene_1");   
		Application.Quit();
		#else // UNITY_5_3 or above
	//	UnityEngine.SceneManagement.SceneManager.LoadScene("InstructionScene_1");
			Application.Quit();
		#endif
	}
		#endif
}
#endregion //MONOBEHAVIOUR_METHODS


#region PRIVATE_METHODS
private void HandleTap()
{
	if (mTapCount == 1)
	{
		mTimeSinceLastTap += Time.deltaTime;
		if (mTimeSinceLastTap > DOUBLE_TAP_MAX_DELAY)
		{
			// too late for double tap, 
			// we confirm it was a single tap
			OnSingleTapConfirmed();

			// reset touch count and timer
			mTapCount = 0;
			mTimeSinceLastTap = 0;
		}
	}
	else if (mTapCount == 2)
	{
		// we got a double tap
		OnDoubleTap();

		// reset touch count and timer
		mTimeSinceLastTap = 0;
		mTapCount = 0;
	}

	if (Input.GetMouseButtonUp(0))
	{
		mTapCount++;
	}
}

protected virtual void OnSingleTapConfirmed()
{
		CameraSettings camSettings = GetComponentInChildren<CameraSettings>();
	if (camSettings)
	{
			Debug.Log ("Successfully triggered autofocus");
			camSettings.TriggerAutofocusEvent();
	}
}

protected virtual void OnDoubleTap()
{
		CameraSettings mCamSettings = GetComponentInChildren<CameraSettings>();
		if (mCamSettings) {
			if (mCamSettings.IsFlashTorchEnabled()) {
				mCamSettings.SwitchFlashTorch (ON: false);
			} else {
				mCamSettings.SwitchFlashTorch (ON: true);
			}
		}
}
#endregion // PRIVATE_METHODS
}
