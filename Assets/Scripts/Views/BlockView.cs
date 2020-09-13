using UnityEngine;

public class BlockView : MonoBehaviour, IBlockView
{
	private IBlockViewModel viewModel;

	public void BindViewModel(IBlockViewModel viewModel)
	{
		this.viewModel = viewModel;
		viewModel.SubscribeToUpdateBlock(UpdateView);
	}

	private void UpdateView(BlockData data)
	{

	}
}
