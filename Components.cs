// Components.cs

namespace Mahjong
{
    public enum TileSuit {Circle, Bamboo, Character, Wind, Dragon, Flower}
    public enum Seasons {East, South, West, North}
    public enum FlowerColors{Red, Black}
    public enum DragonColors{White, Red, Green}
    
    public class TileComponent
    {
        public TileSuit Suit {get; set;}
    }
    public class NumberComponent
    {
        public int Number {get; set;}
    }
    public class SeasonComponent
    {
        public Seasons Season {get; set;}
    }
    public class FlowerColorComponent
    {
        public FlowerColors FlowerColor {get; set;}
    }
    public class DragonColorComponent
    {
        public DragonColors DragonColor {get; set;}
    }

    public class TileCodeComponent
    {
        // Make it 3 characters 
        public required string Code {get; set;}
    }
    
}