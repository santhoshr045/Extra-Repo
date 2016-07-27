using UnityEngine;
using System.Collections;
using System.Net;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;


public class Rows {

	public string description ;
	public float Efficiency;
	public bool IsConnected;
	public string Lastconnection;
	public float MTBF;
	public float MTTR;
	public string Name;
	public float Speed;
	public float TemperatureSetPoint;

}

public class GetThingWorxData : MonoBehaviour {

	//string url = "http://119.82.98.186:8443/Thingworx/Things/RnDThing/Properties/";
	string url = "http://111.93.149.139:8080/Thingworx/Things/SimulationData/Properties/";
	string username="Administrator";
	//string username="ThingWorxSathish";
	string password="ZZh7y6dn";
	//string password="ptc";
	string rt;


	// Use this for initialization
	void Start () {
		JToken tok = CallThingWorx();
//		foreach (JProperty item in tok) {
//			Debug.Log (item.Name+": "+item.Value);
//		}

	}


	public JToken CallThingWorx(){

		 {
			var httpRequest = (HttpWebRequest)WebRequest.Create (url);
			httpRequest.ContentType = "application/json";
			
			string encoded = System.Convert.ToBase64String (System.Text.Encoding.GetEncoding("ISO-8859-1").GetBytes(username+":"+password));
			httpRequest.Headers.Add ("Authorization","Basic "+encoded);
			httpRequest.Accept = "application/json";
			
			using (HttpWebResponse response = (HttpWebResponse)httpRequest.GetResponse())
			using (Stream stream = response.GetResponseStream())
			using (StreamReader reader = new StreamReader(stream))
			{
			//	Debug.Log (response.StatusCode.ToString());
				rt = reader.ReadToEnd();

				JObject data = JObject.Parse(rt);

				JToken token = (data["rows"][0]);

				return token;
				}

				
			}


		}

	}

