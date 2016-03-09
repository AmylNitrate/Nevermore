using UnityEngine;
using System.Collections;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class Data : MonoBehaviour {

	public static Data control;

	public int Matches;
	public int Batteries;

	// Use this for initialization
	void Awake () 
	{
		if (control == null) 
		{
			DontDestroyOnLoad (gameObject);
			control = this;
		} 
		else if (control != null) 
		{
			Destroy (gameObject);
		}
	
	}

	public void Save()
	{
		BinaryFormatter bf = new BinaryFormatter();
		FileStream file = File.Create(Application.persistentDataPath + "/playerInfo.dat");

		PlayerData _data = new PlayerData();
		_data.matches = Matches;
		_data.batteries = Batteries;


		bf.Serialize(file, _data);
		file.Close();
	}

	public void Load()
	{
		if(File.Exists(Application.persistentDataPath + "/playerInfo.dat"))
		{
			BinaryFormatter bf = new BinaryFormatter();
			FileStream file = File.Open(Application.persistentDataPath + "/playerInfo.dat", FileMode.Open);
			PlayerData _data = (PlayerData)bf.Deserialize(file);
			file.Close();

			Matches = _data.matches;
			Batteries = _data.batteries;

		}
	}
		
		
}

[Serializable]
class PlayerData
{
	public int matches;
	public int batteries;
}