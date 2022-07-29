using System;
using System.Collections.Generic;
using _Game.Scripts.Models;
using UnityEngine;

namespace _Game.Scripts
{
    [CreateAssetMenu(menuName = "_Game/ViewModel/InventoryViewModel")]
    public class InventoryViewModel: ScriptableObject
    {
        public event Action<string> OnItemSelected;
        public event Action<string> OnItemConfirmed;
        
        [NonSerialized]
        public ObservableVariable<string> SelectedItem = new ObservableVariable<string>(null);
        
        [NonSerialized]
        public ObservableVariable<string> ConfirmedItem = new ObservableVariable<string>(null);
        
        [NonSerialized]
        public ObservableVariable<List<InventoryItemState>> InventoryItemStates = new ObservableVariable<List<InventoryItemState>>(null);
        
        [NonSerialized]
        public ObservableVariable<Characteristics> CharacteristicsMainState = new ObservableVariable<Characteristics>(null);
        
        [NonSerialized]
        public ObservableVariable<Characteristics> CharacteristicsDiffState = new ObservableVariable<Characteristics>(null);

        public void ItemSelect(string itemId)
        {
            if (itemId != SelectedItem.Value)
            {
                OnItemSelected?.Invoke(itemId);                
            }
        }

        public void ItemConfirm(string itemId)
        {
            OnItemConfirmed?.Invoke(itemId);
        }
    }
}