using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class find_active_objects_in_list : MonoBehaviour {

	// Use this for initialization
	void Start () {

		//typeで指定した型の全てのオブジェクトを配列で取得し，その要素数繰り返す
		foreach (GameObject obj in UnityEngine.Object.FindObjectsOfType(typeof(GameObject)))
		{
			//シーン上に存在するオブジェクトならば処理
			if(obj.activeInHierarchy){
				/*
				//GameObjectの名前を表示
				Debug.Log(obj.name);
				*/
				//変数に代入
				//var hoge =obj.name);
				Debug.Log(obj.name+":position:"+obj.transform.position.ToString("F3"));
				//Debug.Log(obj.name + ":local-position:" + obj.transform.localPosition.ToString("F3"));
				Debug.Log(obj.name + ":rotation:" + obj.transform.rotation.ToString("F3"));
				Debug.Log(obj.name + ":scale:" + obj.transform.localScale.ToString("F3"));
			}
		}
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
