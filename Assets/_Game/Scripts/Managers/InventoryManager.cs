using System.Collections.Generic;
using System.Linq;
using _Game.Scripts;
using _Game.Scripts.Models;
using UnityEngine;

namespace _Game
{
    public class InventoryManager : MonoBehaviour
    {
        public InventoryViewModel viewModel;
        public InventoryStorage storage;
        public List<Item> Items;

        private void Start()
        {
            UpdateInventoryItems();
            OnItemSelected(Items[0].Id);
        }

        private void OnEnable()
        {
            viewModel.OnItemSelected += OnItemSelected;
            viewModel.OnItemConfirmed += OnItemConfirmed;
        }

        private void OnDisable()
        {
            viewModel.OnItemSelected -= OnItemSelected;
            viewModel.OnItemConfirmed -= OnItemConfirmed;
        }

        private void OnItemSelected(string itemId)
        {
            viewModel.SelectedItem.Value = itemId;
            storage.SelectItem(itemId);
            UpdateInventoryItems();
            UpdateCharacteristics();
        }

        private void OnItemConfirmed(string itemId)
        {
            viewModel.ConfirmedItem.Value = itemId;
            storage.ConfirmItem(itemId);
            UpdateInventoryItems();
            UpdateCharacteristics();
        }

        private void UpdateInventoryItems()
        {
            viewModel.InventoryItemStates.Value = Items
                .Select(weapon => new InventoryItemState(
                    weapon.Id,
                    weapon.Icon,
                    storage.IsItemSelected(weapon.Id),
                    storage.IsItemConfirmed(weapon.Id)
                ))
                .ToList();
        }

        private void UpdateCharacteristics()
        {
            if (!string.IsNullOrEmpty(viewModel.ConfirmedItem.Value))
            {
                Item confirmedItem = GetItemById(viewModel.ConfirmedItem.Value);
                viewModel.CharacteristicsMainState.Value = confirmedItem.Characteristics;
                
                if (!string.IsNullOrEmpty(viewModel.SelectedItem.Value))
                {
                    Item selectedItem = GetItemById(viewModel.SelectedItem.Value);
                    Characteristics diff = Characteristics.Diff(confirmedItem.Characteristics, selectedItem.Characteristics);
                    viewModel.CharacteristicsDiffState.Value = diff;
                }
            }
        }

        private Item GetItemById(string itemId) => Items.First(item => item.Id == itemId);
    }
}