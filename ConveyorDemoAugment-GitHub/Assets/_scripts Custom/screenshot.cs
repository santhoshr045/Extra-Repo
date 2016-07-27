using UnityEngine;
using System.Collections;


public class screenshot : MonoBehaviour {
	
	public void MyTeakeScreenshot () {
			 	 

		if (Application.platform == RuntimePlatform.Android) {
			Application.CaptureScreenshot ("UnityScreenshot",4);

			//show toast 
			ShowToast obj = new ShowToast ();
			obj.MyShowToastMethod ("ScreenShot Captured");
			Debug.Log ("ScreenShot Captured in android");
		
		} else {
			Application.CaptureScreenshot ("UnityScreenShot", 4);
			Debug.Log ("ScreenShot Captured");
		}
	}
		void Update()
		{
			
		if (Input.GetKeyUp(KeyCode.Escape)) 
			{
			#if UNITY_EDITOR
			UnityEditor.EditorApplication.isPlaying = false;
			#elif UNITY_ANDROID
			Application.Quit();
			#endif
			}
		}

	}

