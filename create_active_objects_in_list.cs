using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class create_active_objects_in_list : MonoBehaviour {

	// Use this for initialization
	void Start () {
		csv_read();
	}

	void csv_read(){

		//入力用ファイル
		var csv_file_path = Application.dataPath;
		csv_file_path = csv_file_path.Substring(0, csv_file_path.LastIndexOf(@"\") + 1);

		//読み込んだ文字列保存
		string string_line;

		//入力
		using (var read_file=new System.IO.StreamReader(csv_file_path+@"save_csv\test.csv",System.Text.Encoding.GetEncoding("utf-8")))
		{
			while(read_file.Peek()>=0){
				string_line = string.Empty;
				//一行ずつ読み込む
				string_line = read_file.ReadLine();

				//string_print(string_line);
				split_string_line(string_line);

			}

		}
		
	}

	void split_string_line(string string_line){

		//辞書型変数の作成
		var para_tables = new Dictionary<string, string>();

		//","で文字列を分割
		char[] delimiterchar_for_words = {','};
		char[] delimiterchar_for_word = { ':' };

		string[] words = string_line.Split(delimiterchar_for_words,StringSplitOptions.RemoveEmptyEntries);

		foreach(var word in words){
			//Debug.Log(word);
			
			//':'で分割
			string[] word_split = word.Split(delimiterchar_for_word, StringSplitOptions.RemoveEmptyEntries);
			para_tables.Add(word_split[0], word_split[1]);

		}

		create_object(para_tables);

	}

	void create_object(IDictionary<string, string> para_tables) {

		//作成しないオブジェクトリスト
		string[] create_object_name ={"Main Camera","Directional Light","GameObject"};

		//Primitive Type
		string[] create_primitive_type = { "Sphere", "Capsule", "Cylinder", "Cube", "Plane", "Quad" };

		//Debug.Log(create_object_name.Length);

		int index1 = Array.IndexOf(create_object_name, para_tables["name"]);

		int index2 = Array.IndexOf(create_primitive_type, para_tables["name"]);

		if (index1 == -1){

			if (index2 == -1)
			{
				
				Debug.Log("in success.");
				//プレハブを取得
				//バックスラッシュは動かない
				GameObject prefab = (GameObject)Resources.Load("Material/" +(string) para_tables["name"]) as GameObject;

				//位置の指定
				var Position = new Vector3(float.Parse(para_tables["px"]), float.Parse(para_tables["py"]), float.Parse(para_tables["pz"]));

				//回転の指定
				var Rotation = new Quaternion(float.Parse(para_tables["rx"]), float.Parse(para_tables["ry"]), float.Parse(para_tables["rz"]), float.Parse(para_tables["rw"]));

				//Scaleの指定
				var Scale = new Vector3(float.Parse(para_tables["sx"]), float.Parse(para_tables["sy"]), float.Parse(para_tables["sz"]));

				GameObject cre_obj = Instantiate(prefab, Position, Rotation);

				cre_obj.transform.localScale = Scale;
	
				Debug.Log("Create success.");
				
			}
			else
			{
				/*
				GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
				cube.transform.position = new Vector3(float.Parse(para_tables["px"]), float.Parse(para_tables["py"]), float.Parse(para_tables["pz"]));
				cube.transform.rotation = new Quaternion(float.Parse(para_tables["rx"]), float.Parse(para_tables["ry"]), float.Parse(para_tables["rz"]), float.Parse(para_tables["rw"]));
				cube.transform.localScale = new Vector3(float.Parse(para_tables["sx"]), float.Parse(para_tables["sy"]), float.Parse(para_tables["sz"]));
				*/

				create_primitive_object(para_tables);
			}

	
		}

	}

	void create_primitive_object(IDictionary<string, string> para_tables){

		GameObject obj;
		switch(para_tables["name"]){
			case "Sphere":
				obj = GameObject.CreatePrimitive(PrimitiveType.Sphere);
				break;
			case "Capsule":
				obj = GameObject.CreatePrimitive(PrimitiveType.Capsule);
				break;
			case "Cylinder":
				obj = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
				break;
			case "Plane":
				obj = GameObject.CreatePrimitive(PrimitiveType.Plane);
				break;
			case "Quad":
				obj = GameObject.CreatePrimitive(PrimitiveType.Quad);
				break;
			default:
				obj = GameObject.CreatePrimitive(PrimitiveType.Cube);
				break;
		}

		obj.transform.position = new Vector3(float.Parse(para_tables["px"]), float.Parse(para_tables["py"]), float.Parse(para_tables["pz"]));
		obj.transform.rotation = new Quaternion(float.Parse(para_tables["rx"]), float.Parse(para_tables["ry"]), float.Parse(para_tables["rz"]), float.Parse(para_tables["rw"]));
		obj.transform.localScale = new Vector3(float.Parse(para_tables["sx"]), float.Parse(para_tables["sy"]), float.Parse(para_tables["sz"]));

	}

}
