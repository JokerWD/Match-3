using TMPro;
using UnityEngine;

namespace Match3
{
    public sealed class ScoreCounter : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI scoreText;

        #region Score

        private int _score;

        public int Score
        {
            get => _score;

            set
            {
                if(_score == value) return;

                _score = value;
            
                scoreText.SetText($"Score = {_score}");
            }
        }
        
        #endregion

    }
}
