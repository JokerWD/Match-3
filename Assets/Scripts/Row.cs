using UnityEngine;

namespace Match3
{
    public sealed class Row : MonoBehaviour
    {
        [field:SerializeField] public Tile[] tiles { get; private set; }
    }
}

