using _Game.Scripts.Models;
using TMPro;
using UnityEngine;

namespace _Game.Scripts
{
    public class InventoryItemsCharacteristicsView: MonoBehaviour
    {
        public InventoryViewModel viewModel;

        public TextMeshProUGUI strengthValue;
        public TextMeshProUGUI strengthDiff;
        public TextMeshProUGUI agilityValue;
        public TextMeshProUGUI agilityDiff;
        public TextMeshProUGUI staminaValue;
        public TextMeshProUGUI staminaDiff;
        public TextMeshProUGUI wisdomValue;
        public TextMeshProUGUI wisdomDiff;
        
        private void OnEnable()
        {
            viewModel.CharacteristicsMainState.OnValueChanged += UpdateMainCharacteristics;
            viewModel.CharacteristicsDiffState.OnValueChanged += UpdateDiffCharacteristics;

        }

        private void OnDisable()
        {
            viewModel.CharacteristicsMainState.OnValueChanged -= UpdateMainCharacteristics;
            viewModel.CharacteristicsDiffState.OnValueChanged -= UpdateDiffCharacteristics;
        }
        
        private void UpdateMainCharacteristics(Characteristics chars)
        {
            strengthValue.text = chars.Strength.ToString();
            agilityValue.text = chars.Agility.ToString();
            staminaValue.text = chars.Stamina.ToString();
            wisdomValue.text = chars.Wisdom.ToString();
        }
        
        private void UpdateDiffCharacteristics(Characteristics chars)
        {
            strengthDiff.text = chars.Strength.ToString();
            agilityDiff.text = chars.Agility.ToString();
            staminaDiff.text = chars.Stamina.ToString();
            wisdomDiff.text = chars.Wisdom.ToString();
        }
    }
}