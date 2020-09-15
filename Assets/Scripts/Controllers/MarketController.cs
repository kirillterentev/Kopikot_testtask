using UnityEngine;
using UnityEngine.UI;

public class MarketController : MonoBehaviour
{
	[SerializeField]
	private Transform uiParent;
	[SerializeField]
	private Button updateButton;

	[Header("Views prefabs")]
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
		updateButton.onClick.AddListener(ReinitMarket);
		InitMarket();
	}

	public void ReinitMarket()
	{
		Destroy(uiParent.GetChild(0).gameObject);
		dataController.UpdateData();
		InitMarket();
	}

	private void InitMarket()
	{
		var kitModel = new KitModel(dataController.GetCurrentKitData());
		var kitViewModel = new KitViewModel(kitModel);
		var kitViewGO = Instantiate(kitPrefab);
		var kitView = kitViewGO.GetComponent<IKitView>();
		kitView.BindViewModel(kitViewModel);

		var blocksData = dataController.GetCurrentKitData().Blocks;
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

	private void OnDestroy()
	{
		dataController.Save();
		updateButton.onClick.RemoveAllListeners();
	}
}
