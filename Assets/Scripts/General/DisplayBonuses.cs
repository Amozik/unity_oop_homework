using UnityEngine;
using UnityEngine.UI;

namespace General
{
    public class DisplayBonuses : IView
    {
        private Text _text;
        private int _point;
        private int _totalPoints;
        
        public DisplayBonuses(int totalPoints)
        {
            _text = Object.FindObjectOfType<Text>();
            _totalPoints = totalPoints;
            Display(0);
        }
        
        public void Display(int value)
        {
            _point += value;
            _text.text = $"Вы набрали {_point} из {_totalPoints}";
        }
    }
}