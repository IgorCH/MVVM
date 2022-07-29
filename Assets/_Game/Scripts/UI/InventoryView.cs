using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace _Game.Scripts
{
    public class InventoryView: MonoBehaviour
    {
        public InventoryViewModel viewModel;
        public InventoryItemView InventoryItemPrefab;
        public RectTransform ItemsContainer;
        public Button ConfirmButton;
        private bool isInitialized;

        private void OnEnable()
        {
            ConfirmButton.onClick.AddListener(OnConfirm);
            viewModel.InventoryItemStates.OnValueChanged += InitializeIfNeed;
        }

        private void OnDisable()
        {
            ConfirmButton.onClick.RemoveListener(OnConfirm);
            viewModel.InventoryItemStates.OnValueChanged -= InitializeIfNeed;
        }
        
        private void InitializeIfNeed(List<InventoryItemState> buttonStates)
        {
            if (isInitialized)
            {
                return;
            }
            
            for (var i = 0; i < buttonStates.Count; i++)
            {
                var shopButtonView = Instantiate(InventoryItemPrefab, ItemsContainer);
                shopButtonView.Initialize(buttonStates[i].Id);
            }

            isInitialized = true;
        }

        private void OnConfirm()
        {
            if (!string.IsNullOrEmpty(viewModel.SelectedItem.Value))
            {
                viewModel.ItemConfirm(viewModel.SelectedItem.Value);
            }
        }
    }
}