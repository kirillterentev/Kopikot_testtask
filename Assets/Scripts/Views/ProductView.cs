using UnityEngine;
using UnityEngine.UI;

public class ProductView : MonoBehaviour, IProductView
{
	[SerializeField]
	private Text valueText;
	[SerializeField]
	private Text descriptionText;

	private IProductViewModel viewModel;

	public void BindViewModel(IProductViewModel viewModel)
	{
		this.viewModel = viewModel;
		viewModel.SubscribeToUpdateProduct(UpdateView);
	}

	private void UpdateView(ProductData data)
	{
		valueText.text = data.Value.ToString();
		descriptionText.text = data.Description;
	}
}
