using System;

public class KitModel : IKitModel
{
	private Action UpdateEvent;
	private KitData kitData;

	public KitModel(KitData data)
	{
		kitData = data;
	}

	public KitData GetKitData()
	{
		return kitData;
	}

	public void SubscribeToUpdateModel(Action action)
	{
		UpdateEvent += action;
	}

	public void UpdateModel()
	{
		UpdateEvent?.Invoke();
	}
}
