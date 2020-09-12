using System;

public class BlockViewModel : IBlockViewModel
{
	private IBlockModel model;
	private Action<BlockData> UpdateBlockEvent;

	public BlockViewModel()
	{
		model = new BlockModel();
		model.SubscribeToUpdateModel(() => UpdateBlockEvent?.Invoke(model.GetBlockData()));
	}

	public void SubscribeToUpdateBlock(Action<BlockData> action)
	{
		UpdateBlockEvent += action;
	}
}
