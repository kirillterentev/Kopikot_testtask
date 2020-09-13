using System;

public interface IBlockModel
{
	BlockData GetBlockData();
	void SubscribeToUpdateModel(Action action);
	void UpdateModel();
}
