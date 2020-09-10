using UnityEngine;

[CreateAssetMenu(fileName = " New kit", menuName = "Create kit")]
public class KitData : ScriptableObject
{
	[SerializeField]
	private string id;
	[SerializeField]
	private BlockData[] blocks;

	public string Id => id;
	public BlockData[] Blocks => blocks;
}
