using UnityEngine;

public class DataController : IDataController
{
	private readonly string KitsDataPath = "Kits";

	private KitData[] kitsData;

	public DataController()
	{
		kitsData = Resources.LoadAll<KitData>(KitsDataPath);
	}

	public KitData[] GetKitData()
	{
		return kitsData;
	}

	public void Save()
	{
		
	}

	public void Load()
	{
		
	}
}
