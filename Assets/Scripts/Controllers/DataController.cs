using System.Linq;
using UnityEngine;

public class DataController : IDataController
{
	private readonly string KitsDataPath = "Kits";
	private readonly string SaveKey = "SaveData";

	private KitData[] kitsData;
	private KitData currentKitData;

	public DataController()
	{
		kitsData = Resources.LoadAll<KitData>(KitsDataPath);
		Load();
	}

	public KitData GetCurrentKitData()
	{
		return currentKitData;
	}

	public void Save()
	{
		PlayerPrefs.SetString(SaveKey, currentKitData.Id);
	}

	public void Load()
	{
		if (PlayerPrefs.HasKey(SaveKey))
		{
			var id = PlayerPrefs.GetString(SaveKey);
			currentKitData = kitsData.First(kit => kit.Id == id);
		}

		if (currentKitData == null)
		{
			currentKitData = kitsData[Random.Range(0, kitsData.Length)];
		}
	}
}
