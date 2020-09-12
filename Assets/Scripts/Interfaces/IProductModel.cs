using System;

public interface IProductModel
{
	ProductData GetProductData();
	void SubscribeToUpdateModel(Action action);
}
