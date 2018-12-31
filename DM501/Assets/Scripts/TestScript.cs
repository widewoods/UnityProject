using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour 
{
	//public 은 유니티 에디터에서 볼 수 있다.
	private int a;
	public int b;
	//접근 한정자를 안 적으면 private
	int c;


	//Integer -> int 정수
	private int age = 14;
	//Floating Point -> float 소수
	private float moveSpeed = 3.0f;
	//Character(문자) -> char 문자
	private char myFirstCharacterOfMyName = 'H';
	//String Cheese -> string 문자열
	private string myName = "HongWooJoo";
	//boolean -> bool 논리(참, 거짓)
	private bool isAlive = true;

}
