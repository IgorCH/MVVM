using System;
using UnityEngine;

namespace _Game.Scripts
{
    [CreateAssetMenu(menuName = "_Game/Manager/InventoryStorage")]
    public class InventoryStorage: ScriptableObject
    {
        [NonSerialized]
        private string SelectedItem;
        
        [NonSerialized]
        private string ConfirmedItem;

        public void SelectItem(string id)
        {
            SelectedItem = id;
        }

        public void ConfirmItem(string id)
        {
            ConfirmedItem = id;
        }
        
        public bool IsItemSelected(string weaponId) => SelectedItem == weaponId;
        public bool IsItemConfirmed(string weaponId) => ConfirmedItem == weaponId;
    }
}