using System;

public class ProductViewModel : IProductViewModel
{
	private IProductModel model;
	private Action<ProductData> UpdateProductEvent;

	public ProductViewModel(IProductModel model)
	{
		this.model = model;
		model.SubscribeToUpdateModel(() => UpdateProductEvent?.Invoke(model.GetProductData()));
	}

	public void SubscribeToUpdateProduct(Action<ProductData> action)
	{
		UpdateProductEvent += action;
		action.Invoke(model.GetProductData());
	}

	public void Buy()
	{
		model.Buy();
	}
}
