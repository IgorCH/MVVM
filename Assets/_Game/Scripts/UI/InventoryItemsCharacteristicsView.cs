using _Game.Scripts.Models;
using TMPro;
using UnityEngine;

namespace _Game.Scripts
{
    public class InventoryItemsCharacteristicsView: MonoBehaviour
    {
        public InventoryViewModel viewModel;

        public TextMeshProUGUI strengthValue;
        public DiffText strengthDiff;
        public TextMeshProUGUI agilityValue;
        public DiffText agilityDiff;
        public TextMeshProUGUI staminaValue;
        public DiffText staminaDiff;
        public TextMeshProUGUI wisdomValue;
        public DiffText wisdomDiff;
        
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
            strengthDiff.Value = chars.Strength;
            agilityDiff.Value = chars.Agility;
            staminaDiff.Value = chars.Stamina;
            wisdomDiff.Value = chars.Wisdom;
        }
    }
}