using System;

public class ProductViewModel : IProductViewModel
{
	private IProductModel model;
	private Action<ProductData> UpdateProductEvent;

	private bool canBuy;
	public bool CanBuy
	{
		get => canBuy;
		private set => UpdateProductEvent?.Invoke(model.GetProductData());
	}

	public ProductViewModel()
	{
		model = new ProductModel();
		model.SubscribeToUpdateModel(() => CanBuy = model.GetProductData().CanBuy);
	}

	public void SubscribeToUpdateProduct(Action<ProductData> action)
	{
		UpdateProductEvent += action;
		action.Invoke(model.GetProductData());
	}
}
