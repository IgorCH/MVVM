using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace _Game.Scripts
{
    public class DiffText: MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _textComponent;
        [SerializeField] private Color _negativeColor;
        [SerializeField] private Color _zeroColor;
        [SerializeField] private Color _positiveColor;
        
        public int Value
        {
            get => Int32.Parse(_textComponent.text);
            set
            {
                if (value < 0)
                {
                    _textComponent.color = _negativeColor;
                    _textComponent.text = $"{value}";
                } 
                else if (value > 0)
                {
                    _textComponent.color = _positiveColor;
                    _textComponent.text = $"+{value}";
                }
                else
                {
                    _textComponent.color = _zeroColor;
                    _textComponent.text = "";
                }
            }
        }
    }
}