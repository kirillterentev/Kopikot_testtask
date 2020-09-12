using UnityEngine;

[CreateAssetMenu(fileName = " New product", menuName = "Create product")]
public class ProductData : ScriptableObject
{
	[SerializeField]
	private string id;
	[SerializeField]
	private int value;
	[SerializeField]
	private string description;
	private bool canBuy = true;

	public string Id => id;
	public int Value => value;
	public string Description => description;
	public bool CanBuy => canBuy;
}
