using UnityEngine;
using System.Collections;
using Newtonsoft.Json.Linq;
using UnityEngine.UI;

public class GetPropertyValues1 : MonoBehaviour
{

	GetThingWorxData thing = new GetThingWorxData ();

	public GameObject CountText;
	public GameObject TempText;
	static string CountValue1;
	static string CountValue2;
	static string TempValue1;
	static string TempValue2;


	void Start()
	{
		JToken token = thing.CallThingWorx ();
		foreach (JProperty prop in token) 
		{			
			if (prop.Name == "ScrapCount") 
			{ 
				CountValue1 = prop.Value.ToString ();
				CountText.GetComponent<TextMesh> ().text = "Count="+CountValue1.ToString() ;
				//	StartCoroutine (GetnewValue(5.0f));
				Debug.Log ("This is the Count value" + prop.Value);
				//InvokeRepeating ("countDisplay", 10, 5);
			}
			if (prop.Name == "OvenTemperature") 
			{
				TempValue1 = prop.Value.ToString ();
				TempText.GetComponent<TextMesh> ().text = TempValue1.ToString () + "'C";
				TempText.GetComponent<TextMesh> ().alignment = TextAlignment.Center;
				Debug.Log ("This is the Temp value" + prop.Value);
				//InvokeRepeating ("tempDisplay", 10, 5);
			}
		}
	}




	//	IEnumerator GetnewValue(float waitTime)
	//	{
	//		yield return new WaitForSeconds (waitTime);
	//
	//		if (prop.Name == "TemperatureSetpoint") {
	//			CountValue2 = prop.Value.ToString ();
	//    CountValue1 = CountValue2;
	//		}
	//			JToken token = thing.CallThingWorx ();
	//			foreach(JProperty prop in token)
	//			{
	//				if (prop.Name == "TemperatureSetpoint") {
	//					CountValue1 = prop.Value.ToString ();
	//					CountText.GetComponent<TextMesh> ().text = "Count=" +CountValue1;
	//
	//					Debug.Log  ( "This is the Temp value"+prop.Value);
	//				}
	//			}
	//	}


	void countDisplay()
	{
		JToken token = thing.CallThingWorx ();
		foreach (JProperty prop in token) {
			if (prop.Name == "ScrapCount") {
				CountValue2 = prop.Value.ToString ();
				if (CountValue1 == CountValue2) {
					Debug.Log ("count value is still " + CountValue1);
				}
				else if (CountValue1 != CountValue2) {
					CountText.GetComponent<TextMesh> ().text = "Count=" + CountValue2.ToString();
					Debug.Log ("count value Changed" + CountValue2);
				}
			}
		}
	}

	void tempDisplay()
	{
		JToken token = thing.CallThingWorx ();
		foreach (JProperty prop in token) 
		{
			if (prop.Name == "OvenTemperature") 
			{
				TempValue2 = prop.Value.ToString ();
				if (TempValue1 == TempValue2) 
				{
					Debug.Log ("Temp value is still " + TempValue1);
				}
				else if (TempValue1 != TempValue2) 
				{
					CountText.GetComponent<TextMesh> ().text = TempValue2.ToString() +"'C";
					Debug.Log ("Temp value Changed" + TempValue2);
				}
			}
		}

	}

}
