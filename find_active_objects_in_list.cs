using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

public class save_objects : MonoBehaviour {

	// Use this for initialization
	void Start (string name) {

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
				/*
				Debug.Log(obj.name+":position:"+obj.transform.position.ToString("F3"));
				//Debug.Log(obj.name + ":local-position:" + obj.transform.localPosition.ToString("F3"));
				Debug.Log(obj.name + ":rotation:" + obj.transform.rotation.ToString("F3"));
				Debug.Log(obj.name + ":scale:" + obj.transform.localScale.ToString("F3"));
				*/
				get_object_parameters(obj,name);
			}
		}

		Debug.Log("csv write finish");

		
	}
	
	//get object paramaters
	//arugument...GameObject obj
	//return...
	void get_object_parameters(GameObject obj,string name){

		//辞書型の初期化
		var para_table = new Dictionary<string, string>();

		//name
		para_table.Add("name",obj.name);

		//position
		//x,y,z=px,py,pz
		//辞書に追加
		para_table.Add("px", obj.transform.position.x.ToString("F4"));
		para_table.Add("py", obj.transform.position.y.ToString("F4"));
		para_table.Add("pz", obj.transform.position.z.ToString("F4"));

		//rotation
		//x,y,z,w=rx,ry,rz,rw
		//辞書に追加
		para_table.Add("rx", obj.transform.rotation.x.ToString("F4"));
		para_table.Add("ry", obj.transform.rotation.y.ToString("F4"));
		para_table.Add("rz", obj.transform.rotation.z.ToString("F4"));
		para_table.Add("rw", obj.transform.rotation.w.ToString("F4"));

		//Scale
		//x,y,z=sx,sy,sz
		//辞書に追加
		para_table.Add("sx", obj.transform.localScale.x.ToString("F4"));
		para_table.Add("sy", obj.transform.localScale.y.ToString("F4"));
		para_table.Add("sz", obj.transform.localScale.z.ToString("F4"));

		object_parameters_to_csv(para_table,name);

	}

	//
	void object_parameters_to_csv(IDictionary <string,string>para_table,string name){

		string csv_write_data = string.Empty;


		//辞書内のKey,Valueを文字列として総出力
		foreach(KeyValuePair<string,string> item in para_table)
		{
			//csv_write_data += $"{item.Key}:{item.Value},";
			csv_write_data += item.Key + ":" + item.Value + ",";
		}

		csv_write(csv_write_data,name);

	}

	void csv_write(string write_data,string name){	

		
		try
		{
			//append
			//true...Add,false...Write
			var append = true;
			//出力用ファイル
			var csv_file_path =Application.dataPath;
			csv_file_path=csv_file_path.Substring(0,csv_file_path.LastIndexOf(@"\")+1);

			//出力
			using (var write_file=new System.IO.StreamWriter(csv_file_path+@"save_csv\"+name+".csv", append,System.Text.Encoding.GetEncoding("utf-8")))
			{
				write_file.WriteLine(write_data);
			}
		}
		catch(System.Exception e)
		{
			//print error messsage when file open
			System.Console.WriteLine(e.Message);
			Debug.Log(e.Message);
			Debug.Log("csv write error");
		}
	}


}
