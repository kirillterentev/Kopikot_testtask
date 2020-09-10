using System;

public interface IKitViewModel
{
	void SubscribeToUpdateKit(Action<KitData> action);
}
