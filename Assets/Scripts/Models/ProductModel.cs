using System;

public class ProductModel : IProductModel
{
	private Action UpdateEvent;

	public ProductData GetProductData()
	{
		return null;
	}

	public void SubscribeToUpdateModel(Action action)
	{
		UpdateEvent += action;
	}
}
