using System;

public class BlockModel : IBlockModel
{
	private Action UpdateEvent;
	private BlockData blockData;

	public BlockModel(BlockData data)
	{
		blockData = data;
	}

	public BlockData GetBlockData()
	{
		return blockData;
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
