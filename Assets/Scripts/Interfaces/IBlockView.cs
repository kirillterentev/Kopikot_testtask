using UnityEngine;

public interface IBlockView
{
	void BindViewModel(IBlockViewModel viewModel);
	void AddProduct(Transform transform);
}
