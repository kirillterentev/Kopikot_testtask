using UnityEngine;

[CreateAssetMenu(fileName = " New block", menuName = "Create block")]
public class BlockData : ScriptableObject
{
	[SerializeField]
	private string id;
	[SerializeField]
	private ProductData[] products;

	public string Id => id;
	public ProductData[] Products => products;
}
