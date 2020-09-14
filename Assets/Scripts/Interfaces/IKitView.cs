using UnityEngine;

public interface IKitView
{
	void BindViewModel(IKitViewModel viewModel);
	void AddBlock(Transform transform);
}
