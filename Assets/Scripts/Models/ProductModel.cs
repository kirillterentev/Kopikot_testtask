using System;
using UnityEngine;

public class ProductModel : IProductModel
{
	private Action UpdateEvent;
	private ProductData productData;

	public ProductModel(ProductData data)
	{
		productData = data;
		productData.CanBuy = true;
	}

	public ProductData GetProductData()
	{
		return productData;
	}

	public void SubscribeToUpdateModel(Action action)
	{
		UpdateEvent += action;
	}

	public void Buy()
	{
		productData.CanBuy = false;
		UpdateModel();
		Debug.Log($"Buy product : ID({productData.Id}), Product({productData.Value} {productData.Type})");
	}

	public void UpdateModel()
	{
		UpdateEvent?.Invoke();
	}
}
