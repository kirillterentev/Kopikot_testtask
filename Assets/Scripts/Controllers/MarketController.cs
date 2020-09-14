using UnityEngine;

public class MarketController : MonoBehaviour
{
	[SerializeField]
	private Transform uiParent;
	[SerializeField]
	private GameObject kitPrefab;
	[SerializeField]
	private GameObject blockPrefab;
	[SerializeField]
	private GameObject productPrefab;

	private IDataController dataController;

	private void Awake()
	{
		dataController = new DataController();
	}

	private void Start()
	{
		InitMarket();
	}

	private void InitMarket()
	{
		var kitsData = dataController.GetKitData();
		var randomIndex = Random.Range(0, kitsData.Length);

		var kitModel = new KitModel(kitsData[randomIndex]);
		var kitViewModel = new KitViewModel(kitModel);
		var kitViewGO = Instantiate(kitPrefab);
		var kitView = kitViewGO.GetComponent<IKitView>();
		kitView.BindViewModel(kitViewModel);

		var blocksData = kitsData[randomIndex].Blocks;
		for (int i = 0; i < blocksData.Length; i++)
		{
			var blockModel = new BlockModel(blocksData[i]);
			var blockViewModel = new BlockViewModel(blockModel);
			var blockViewGO = Instantiate(blockPrefab);
			var blockView = blockViewGO.GetComponent<IBlockView>();
			blockView.BindViewModel(blockViewModel);

			kitModel.SubscribeToUpdateModel(kitModel.UpdateModel);
			kitView.AddBlock(blockViewGO.transform);

			var productsData = blocksData[i].Products;
			for (int j = 0; j < productsData.Length; j++)
			{
				var productModel = new ProductModel(productsData[j]);
				var productViewModel = new ProductViewModel(productModel);
				var productViewGO = Instantiate(productPrefab);
				var productView = productViewGO.GetComponent<IProductView>();
				productView.BindViewModel(productViewModel);

				blockModel.SubscribeToUpdateModel(blockModel.UpdateModel);
				blockView.AddProduct(productViewGO.transform);
			}
		}

		kitViewGO.transform.SetParent(uiParent);
		kitViewGO.transform.localPosition = Vector2.zero;
	}
}
