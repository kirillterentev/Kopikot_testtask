using System;

public interface IBlockViewModel
{
	void SubscribeToUpdateBlock(Action<BlockData> action);
}
