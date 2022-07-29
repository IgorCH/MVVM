using System;
using System.Collections.Generic;
using _Game.Scripts.Models;
using UnityEngine;

namespace _Game.Scripts
{
    [CreateAssetMenu(menuName = "_Game/ViewModel/InventoryViewModel")]
    public class InventoryViewModel: ScriptableObject
    {
        public event Action<string> OnItemSelected = itemId => { };
        public event Action<string> OnItemConfirmed = itemId => { };
        
        public ObservableVariable<string> SelectedItem = new ObservableVariable<string>(null);
        public ObservableVariable<string> ConfirmedItem = new ObservableVariable<string>(null);
        
        public ObservableVariable<List<InventoryItemState>> InventoryItemStates = new ObservableVariable<List<InventoryItemState>>(null);
        public ObservableVariable<Characteristics> CharacteristicsMainState = new ObservableVariable<Characteristics>(null);
        public ObservableVariable<Characteristics> CharacteristicsDiffState = new ObservableVariable<Characteristics>(null);

        public void ItemSelect(string itemId)
        {
            if (itemId != SelectedItem.Value)
            {
                OnItemSelected.Invoke(itemId);                
            }
        }

        public void ItemConfirm(string itemId)
        {
            OnItemConfirmed.Invoke(itemId);
        }
    }
}