using UnityEngine;

namespace Match3
{
    public static class ItemDatabase 
    {
        public static Item[] Items { get; private set; }


        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]private static void Initialize() => Items = Resources.LoadAll<Item>("Items/");

    }
}

