using UnityEngine;
using UnityEngine.UI;

public class ProductView : MonoBehaviour, IProductView
{
	[SerializeField]
	private Text valueText;
	[SerializeField]
	private Text descriptionText;
	[SerializeField]
	private Button clickHandler;

	private IProductViewModel viewModel;

	public void BindViewModel(IProductViewModel viewModel)
	{
		this.viewModel = viewModel;
		viewModel.SubscribeToUpdateProduct(UpdateView);
		clickHandler.onClick.AddListener(viewModel.Buy);
	}

	private void UpdateView(ProductData data)
	{
		valueText.text = data.Value.ToString();
		descriptionText.text = data.Description;
		clickHandler.interactable = data.CanBuy;
	}

	private void OnDestroy()
	{
		clickHandler.onClick.RemoveAllListeners();
	}
}
