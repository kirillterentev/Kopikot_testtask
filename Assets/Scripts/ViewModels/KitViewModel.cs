using System;

public class KitViewModel : IKitViewModel
{
	private IKitModel model;
	private Action<KitData> UpdateKitEvent;

	public KitViewModel(IKitModel model)
	{
		this.model = model;
		model.SubscribeToUpdateModel(() => UpdateKitEvent?.Invoke(model.GetKitData()));
	}

	public void SubscribeToUpdateKit(Action<KitData> action)
	{
		UpdateKitEvent += action;
	}
}
