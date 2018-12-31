using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyFirstScript : MonoBehaviour 
{

	void Start () 
	{
		print("안녕 유니티");
		Debug.Log("로그");
		Debug.LogWarning("경고");
		Debug.LogError("에러");
	}
	

	void Update () 
	{
		Debug.Log("안녕 친구들");
	}
}
