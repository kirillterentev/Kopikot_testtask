using UnityEngine;

public class KitView : MonoBehaviour, IKitView
{
	private readonly int DeltaOffset = 300;

	[SerializeField]
	private Transform contentParent;

	private IKitViewModel viewModel;
	private Vector2 cachedVector = Vector2.zero;
	private int offset = 0;

	public void BindViewModel(IKitViewModel viewModel)
	{
		this.viewModel = viewModel;
		viewModel.SubscribeToUpdateKit(UpdateView);
	}

	public void AddBlock(Transform transform)
	{
		transform.SetParent(contentParent);
		transform.localPosition = cachedVector;
		cachedVector.y -= DeltaOffset;
	}

	private void UpdateView(KitData data)
	{

	}
}
