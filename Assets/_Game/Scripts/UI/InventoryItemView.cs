using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace _Game.Scripts
{
    public class InventoryItemView: MonoBehaviour
    {
        public InventoryViewModel viewModel;
        
        public Button button;
        public Image previewIcon;
        public GameObject selectIndicator;
        public GameObject confirmIndicator;

        private string id;

        private void OnEnable()
        {
            button.onClick.AddListener(ItemSelect);
            viewModel.InventoryItemStates.OnValueChanged += HandleShopButtonStates;
        }

        private void OnDisable()
        {
            button.onClick.RemoveListener(ItemSelect);
        }

        public void Initialize(string id)
        {
            this.id = id;
            HandleShopButtonStates(viewModel.InventoryItemStates.Value);
        }
        
        private void HandleShopButtonStates(List<InventoryItemState> states)
        {
            for (var i = 0; i < states.Count; i++)
            {
                var state = states[i];
                if (state.Id == id)
                {
                    SetState(state);
                    return;
                }
            }
        }

        private void SetState(InventoryItemState state)
        {
            previewIcon.sprite = state.Icon;
            button.interactable = !state.IsSelected;
            selectIndicator.SetActive(state.IsSelected);
            confirmIndicator.SetActive(state.IsConfirmed);
        }

        private void ItemSelect() => viewModel.ItemSelect(id);
    }
}