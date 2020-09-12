using UnityEngine;

public class KitView : MonoBehaviour, IKitView
{
	private IKitViewModel viewModel;

	private void Start()
	{
		viewModel = new KitViewModel();
		viewModel.SubscribeToUpdateKit(UpdateView);
	}

	private void UpdateView(KitData data)
	{
		
	}
}
