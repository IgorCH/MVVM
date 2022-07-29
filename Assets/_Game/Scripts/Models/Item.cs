using System;
using UnityEngine;

namespace _Game.Scripts.Models
{
    [CreateAssetMenu(menuName = "_Game/Item")]
    public class Item: ScriptableObject
    {
        public string Id = Guid.NewGuid().ToString();
        public Sprite Icon;
        public Characteristics Characteristics;
    }
}