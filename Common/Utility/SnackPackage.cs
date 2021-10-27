using Common.Enums;

namespace Common.Utility
{
    public struct SnackPackage
    {
        public Vector2D Location { get; set; }
        public FoodType FoodType { get; set; }
        public EffectType EffectType { get; set; }
        public bool WasConsumed { get; set; }
    }
}
