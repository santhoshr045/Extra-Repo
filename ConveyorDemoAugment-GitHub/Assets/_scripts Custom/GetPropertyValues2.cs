using UnityEngine;
using System.Collections;
using Newtonsoft.Json.Linq;
using UnityEngine.UI;

public class GetPropertyValues2 : MonoBehaviour
{

	GetThingWorxData thing = new GetThingWorxData ();
	// Use this for initialization
	public GameObject RPM1Text;
	public GameObject RPM2Text;
	static string Rpm1Value1;
	static string Rpm1Value2;
	static string Rpm2Value1;
	static string Rpm2Value2;



	 void Start()
	{



		JToken token = thing.CallThingWorx ();
		foreach (JProperty prop in token) 
		{
			if (prop.Name == "NoOfRotationsRotaryMould") 
			{ 
				Rpm1Value1 = prop.Value.ToString ();
				RPM1Text.GetComponent<TextMesh> ().text = Rpm1Value1.ToString ()+"rpm";
				Debug.Log ("This is the Rpm1 value" + Rpm1Value1);
				//InvokeRepeating ("Rpm1Display", 10, 5);
			}
			if (prop.Name == "NoofRotationConveyor") 
			{
				Rpm2Value1 = prop.Value.ToString ();
				RPM2Text.GetComponent<TextMesh> ().text = prop.Value.ToString ()+"rpm";
				Debug.Log ("This is the Rpm2 value" + Rpm2Value2);
				//InvokeRepeating ("Rpm2Display", 10, 5);

			}
		}
	}

	void Rpm1Display ()
	{
		JToken token = thing.CallThingWorx ();
		foreach (JProperty prop in token) 
		{
			if (prop.Name == "NoOfRotationsRotaryMould") 
			{
				Rpm1Value2 = prop.Value.ToString ();
				if (Rpm1Value1 == Rpm1Value2) 
				{
					Debug.Log ("RPM1 value is still " + Rpm1Value2);
				} 
				else if (Rpm1Value1 != Rpm1Value2) 
				{
					RPM1Text.GetComponent<TextMesh> ().text = Rpm1Value2.ToString ()+"rpm";
					Debug.Log ("RPM1 value Changed" + Rpm1Value2);
				}
			}
		}
	}

	void Rpm2Display ()
	{
		JToken token = thing.CallThingWorx ();
		foreach (JProperty prop in token) 
		{
			if (prop.Name == "NoofRotationConveyor") 
			{
				Rpm2Value2 = prop.Value.ToString ();
				if (Rpm2Value1 == Rpm2Value2) 
				{
					Debug.Log ("RPM2 value is still " + Rpm2Value1);
				} else if (Rpm2Value1 != Rpm2Value2) 
				{
					RPM1Text.GetComponent<TextMesh> ().text = Rpm2Value2.ToString ()+"rpm";
					Debug.Log ("RPM2 value Changed" + Rpm2Value2);
				}
			}
		}
	}

}
