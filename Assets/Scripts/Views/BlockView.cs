using UnityEngine;

public class BlockView : MonoBehaviour, IBlockView
{
	private IBlockViewModel viewModel;

	private void Start()
	{
		viewModel = new BlockViewModel();
		viewModel.SubscribeToUpdateBlock(UpdateView);
	}

	private void UpdateView(BlockData data)
	{

	}
}
