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
				//GameObjectの名前を表示
				Debug.Log(obj.name);
			}
		}
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
