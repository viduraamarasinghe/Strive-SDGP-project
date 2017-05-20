using System.Collections;
using System.Collections.Generic;
using LitJson;
using UnityEngine.Networking;
using UnityEngine;

public class UserActivity : MonoBehaviour {
    ActivityRecord userActivity;
	// Use this for initialization
	void Start () {
        StartCoroutine(GetHealthStatistics());
	}
	
    IEnumerator GetHealthStatistics ()
    {
        //sending a GET request
        string requestURL = "http://localhost/JSONtest.JSON";
        UnityWebRequest request = UnityWebRequest.Get(requestURL);
        yield return request.Send();

        if (request.error == null)
        {
            ParseJSON(request.downloadHandler.text);
        } else
        {
            Debug.Log("Retrieving updated health statistics failed!");
        }
    }

    private void ParseJSON(string jsonContent)
    {
        userActivity = JsonMapper.ToObject<ActivityRecord>(jsonContent);
    }
}
public class ActivityRecord
{
    string userId;
    int steps;
}