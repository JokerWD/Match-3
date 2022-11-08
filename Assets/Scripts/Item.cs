using UnityEngine;

namespace Match3
{
    [CreateAssetMenu(menuName = "Match-3/Item")]
    public sealed class Item : ScriptableObject
    {
        [field:SerializeField] public int Value { get; private set; }
        [field:SerializeField] public Sprite Sprite { get; private set; }
    }
}
