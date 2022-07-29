using _Game.Scripts.Models;
using UnityEngine;

namespace _Game.Scripts
{
    public struct InventoryItemState
    {
        public readonly string Id;
        public readonly Sprite Icon;
        public readonly bool IsSelected;
        public readonly bool IsConfirmed;

        public InventoryItemState(
            string id, 
            Sprite icon,
            bool isSelected, 
            bool isConfirmed)
        {
            Id = id;
            Icon = icon;
            IsSelected = isSelected;
            IsConfirmed = isConfirmed;
        }
    }
}