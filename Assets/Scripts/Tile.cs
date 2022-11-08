using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Match3
{
    public sealed class Tile : MonoBehaviour
    {
        [field: SerializeField] public Image Icon { get; set; }
        [SerializeField] private Button button;
        public int X { get;  set; }
        public int Y { get; set; }

        #region Item
        
        private Item _item;
        public Item Item
        {
            get => _item;
            set
            {
                if(_item == value) return;
                
                _item = value;
                
                Icon.sprite = _item.Sprite;
            }
        }

        #endregion

        private Board _board;
        #region Zenject

        [Inject]
        private void Construct(Board board) => _board = board;

        #endregion
        
        #region Neighbours
        
        private Tile Left => X > 0 ? _board.Tiles[X - 1, Y] : null;
        private Tile Top => Y > 0 ? _board.Tiles[X, Y - 1] : null;
        private Tile Right => X < _board.Width - 1 ? _board.Tiles[X + 1, Y] : null;
        private Tile Bottom => Y < _board.Height - 1 ? _board.Tiles[X, Y + 1] : null;
        
        public Tile[] Neighbours => new[]
        {
            Left,
            Top,
            Right,
            Bottom,
        };
        
        #endregion
        
        private void Start() => button.onClick.AddListener(() => _board.Select(this));
    
        public List<Tile> GetConnectedTiles(List<Tile> exclude = null)
        {
            var result = new List<Tile> { this, };
    
            if (exclude == null)
            {
                exclude = new List<Tile> { this, };
            }
            else
            {
                exclude.Add(this);
            }
    
            foreach (var neighbour in Neighbours)
            {
                if(neighbour == null || exclude.Contains(neighbour) || neighbour.Item != Item) continue;
                
                result.AddRange(neighbour.GetConnectedTiles(exclude));
            }
            
            return result;
        }
    }
}
