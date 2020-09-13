using UnityEngine;

public class MarketController : MonoBehaviour
{
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
		var kitView = Instantiate(kitPrefab).GetComponent<IKitView>();
		kitView.BindViewModel(kitViewModel);

		var blocksData = kitsData[randomIndex].Blocks;
		for (int i = 0; i < blocksData.Length; i++)
		{
			var blockModel = new BlockModel(blocksData[i]);
			var blockViewModel = new BlockViewModel(blockModel);
			var blockView = Instantiate(blockPrefab).GetComponent<IBlockView>();
			blockView.BindViewModel(blockViewModel);

			kitModel.SubscribeToUpdateModel(kitModel.UpdateModel);

			var productsData = blocksData[i].Products;
			for (int j = 0; j < productsData.Length; j++)
			{
				var productModel = new ProductModel(productsData[j]);
				var productViewModel = new ProductViewModel(productModel);
				var productView = Instantiate(productPrefab).GetComponent<IProductView>();
				productView.BindViewModel(productViewModel);

				blockModel.SubscribeToUpdateModel(blockModel.UpdateModel);
			}
		}
	}
}
