using UnityEngine;

public class BlockView : MonoBehaviour, IBlockView
{
	private readonly int DeltaOffset = 250;

	[SerializeField]
	private Transform contentParent;

	private IBlockViewModel viewModel;
	private Vector2 cachedVector = Vector2.zero;

	public void BindViewModel(IBlockViewModel viewModel)
	{
		this.viewModel = viewModel;
		viewModel.SubscribeToUpdateBlock(UpdateView);
	}

	public void AddProduct(Transform transform)
	{
		transform.SetParent(contentParent);
		transform.localPosition = cachedVector;
		cachedVector.x += DeltaOffset;
	}

	private void UpdateView(BlockData data)
	{

	}
}
