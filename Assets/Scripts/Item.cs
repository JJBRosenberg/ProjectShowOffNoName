using UnityEditor;
using UnityEngine;


[CreateAssetMenu]
public class Item : ScriptableObject
{
    [SerializeField] string id;
    public string ID { get { return id; } }
    public string ItemName;
    public Sprite Icon;

    public int MaximumStacks = 1;
#if UNITY_EDITOR
    protected virtual void OnValidate()
	{
		string path = AssetDatabase.GetAssetPath(this);
		id = AssetDatabase.AssetPathToGUID(path);
	}
#endif

	public virtual Item GetCopy()
    {
        return this;
    }

    public virtual void Destroy()
    {

    }
}
