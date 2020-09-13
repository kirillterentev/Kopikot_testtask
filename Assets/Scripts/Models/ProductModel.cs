using System;

public class ProductModel : IProductModel
{
	private Action UpdateEvent;
	private ProductData productData;

	public ProductModel(ProductData data)
	{
		productData = data;
	}

	public ProductData GetProductData()
	{
		return productData;
	}

	public void SubscribeToUpdateModel(Action action)
	{
		UpdateEvent += action;
	}

	public void UpdateModel()
	{
		UpdateEvent?.Invoke();
	}
}
