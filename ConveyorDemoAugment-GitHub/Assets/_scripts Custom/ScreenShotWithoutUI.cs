using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.IO;
using Vuforia;



public class ScreenShotWithoutUI : MonoBehaviour {

//	public RawImage image;

	public void ScreenShotCapture () {
	
//		Rect rect = new Rect (0, 0, Screen.width , Screen.height);
//		string monthVar = System.DateTime.Now.Ticks.ToString ();
//		string fileName = monthVar + ".jpg";
//		StartCoroutine(TakeScreenShot(image, rect , fileName ,1));
	}

//	IEnumerator TakeScreenShot(RawImage image, Rect rect , string fileName, float ratio)
//	{
//
//		//wait for the end of the frame to avoid any interfereance
//		yield return new WaitForEndOfFrame();
//
//
//		//Aplly the ratio
//		rect.height *= ratio;
//		rect.width *= ratio;
//
//		camera.Render ();
//		Texture2D texture = new Texture2D((int)(camera.pixelWidth), (int)(camera.pixelHeight));
//
//		texture.ReadPixels (rect, 0, 0);
//		texture.Apply ();
//
//		byte[] bytes = texture.EncodeToPNG ();
//
//		System.IO.File.WriteAllBytes (Application.persistentDataPath + "/" + fileName, bytes);
//		image.texture = texture;
//
//	}

}
