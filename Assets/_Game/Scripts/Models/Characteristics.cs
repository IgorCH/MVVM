using System;

namespace _Game.Scripts.Models
{
    [Serializable]
    public class Characteristics
    {
        public int Strength;
        public int Agility;
        public int Stamina;
        public int Wisdom;

        public static Characteristics Diff(Characteristics chars2, Characteristics chars1)
        {
            Characteristics result = new Characteristics();
            result.Strength = chars1.Strength - chars2.Strength;
            result.Agility = chars1.Agility - chars2.Agility;
            result.Stamina = chars1.Stamina - chars2.Stamina;
            result.Wisdom = chars1.Wisdom - chars2.Wisdom;
            return result;
        }
    }
}