using System;

public class BlockModel : IBlockModel
{
	private Action UpdateEvent;

	public BlockData GetBlockData()
	{
		return null;
	}

	public void SubscribeToUpdateModel(Action action)
	{
		UpdateEvent += action;
	}
}
