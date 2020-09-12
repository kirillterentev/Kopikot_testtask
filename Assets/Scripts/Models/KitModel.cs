using System;

public class KitModel : IKitModel
{
	private Action UpdateEvent;

	public KitData GetKitData()
	{
		return null;
	}

	public void SubscribeToUpdateModel(Action action)
	{
		UpdateEvent += action;
	}
}
