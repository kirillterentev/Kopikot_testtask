using UnityEngine;
using UnityEngine.UI;

public class ProductView : MonoBehaviour, IProductView
{
	[SerializeField]
	private Text valueText;
	[SerializeField]
	private Text descriptionText;

	private IProductViewModel viewModel;

	private void Start()
	{
		viewModel = new ProductViewModel();
		viewModel.SubscribeToUpdateProduct(UpdateView);
	}

	private void UpdateView(ProductData data)
	{
		valueText.text = data.Value.ToString();
		descriptionText.text = data.Description;
	}
}
