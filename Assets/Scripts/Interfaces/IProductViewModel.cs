using System;

public interface IProductViewModel
{
	void SubscribeToUpdateProduct(Action<ProductData> action);
}
