using UnityEngine;

public class KitView : MonoBehaviour, IKitView
{
	private IKitViewModel viewModel;

	public void BindViewModel(IKitViewModel viewModel)
	{
		this.viewModel = viewModel;
		viewModel.SubscribeToUpdateKit(UpdateView);
	}

	private void UpdateView(KitData data)
	{
		
	}
}
