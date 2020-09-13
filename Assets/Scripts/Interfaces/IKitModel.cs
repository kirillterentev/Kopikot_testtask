using System;

public interface IKitModel
{
	KitData GetKitData();
	void SubscribeToUpdateModel(Action action);
	void UpdateModel();
}
