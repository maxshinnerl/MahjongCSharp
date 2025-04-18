
using System.Collections;
using System.Runtime.InteropServices;

namespace Mahjong
{
    public class BoardManager
    {
        public List<int> tileEntities; // list of tiles on the board, starts with 144 entities (0-143)

        public BoardManager(ComponentManager cm)
        {
            // Initialize all 144 unique tiles
            tileEntities = [];
            TileFactory tf = new(cm);
            
            // flowers have 2 each
            FlowerColors[] fcs = Enum.GetValues<FlowerColors>(); // Get enum values as a list
            for (int i = 0; i < 2; i++)
            {
                for(int flowernum = 1; flowernum <= 4; flowernum++)
                {
                    tileEntities.Add(tf.CreateTile(TileSuit.Flower, number:flowernum, fc:fcs[i]));
                }
            }

            // all other tiles have 4 each
            for (int i = 0; i < 4; i++)
            {
                // main suits get 1-9
                for(int tilenum = 1; tilenum <= 9; tilenum++)
                {
                    tileEntities.Add(tf.CreateTile(TileSuit.Circle,    number:tilenum));
                    tileEntities.Add(tf.CreateTile(TileSuit.Bamboo,    number:tilenum));
                    tileEntities.Add(tf.CreateTile(TileSuit.Character, number:tilenum));
                }

                // dragons
                tileEntities.Add(tf.CreateTile(TileSuit.Dragon, dc:DragonColors.Green));
                tileEntities.Add(tf.CreateTile(TileSuit.Dragon, dc:DragonColors.Red));
                tileEntities.Add(tf.CreateTile(TileSuit.Dragon, dc:DragonColors.White));

                // winds
                tileEntities.Add(tf.CreateTile(TileSuit.Wind, s:Seasons.East));
                tileEntities.Add(tf.CreateTile(TileSuit.Wind, s:Seasons.South));
                tileEntities.Add(tf.CreateTile(TileSuit.Wind, s:Seasons.West));
                tileEntities.Add(tf.CreateTile(TileSuit.Wind, s:Seasons.North));
            }
        }
 
        public void VerifyTiles(ComponentManager cm)
        {
            List<string> tileCodes = [];
            foreach (int num in tileEntities)
            {
                tileCodes.Add(cm.GetComponent<TileCodeComponent>(num).Code);
            }
            tileCodes.Sort();
            foreach (string code in tileCodes)
            {
                Console.WriteLine(code);
            }
        }
 
    }

    // Tile factory for creating tiles with components
    public class TileFactory(ComponentManager cm)
    {
        private readonly ComponentManager componentManager = cm;
        

        public int CreateTile(TileSuit suit,
                              int? number = null, 
                              FlowerColors? fc = null, 
                              DragonColors? dc = null,
                              Seasons? s = null)
        {
            
            int tileEntityID = EntityManager.CreateEntity();
            componentManager.AddComponent(tileEntityID, new TileComponent{Suit=suit}); // add the suit component
            
            string NameCode = "";

            // add additional components depending on suit
            switch(suit)
            {
                case TileSuit.Circle:
                    NameCode += "Ci" + number;
                    if (number.HasValue)
                    {
                        componentManager.AddComponent(tileEntityID, new NumberComponent{Number=(int)number});
                        break;
                    }
                    throw new ArgumentNullException(nameof(number));
                case TileSuit.Character:
                    NameCode += "Ch" + number;
                    if (number.HasValue)
                    {
                        componentManager.AddComponent(tileEntityID, new NumberComponent{Number=(int)number});
                        break;
                    }
                    throw new ArgumentNullException(nameof(number));
                case TileSuit.Bamboo:
                    NameCode += "Ba" + number;
                    if (number.HasValue)
                    {
                        componentManager.AddComponent(tileEntityID, new NumberComponent{Number=(int)number});
                        break;
                    }
                    throw new ArgumentNullException(nameof(number));
                
                case TileSuit.Dragon:
                    NameCode += "Dr";
                    if (dc.HasValue)
                    {
                        componentManager.AddComponent(tileEntityID, new DragonColorComponent{DragonColor = (DragonColors)dc});
                        switch(dc)
                        {
                            case DragonColors.White:
                                NameCode += "W";
                                break;
                            case DragonColors.Green:
                                NameCode += "G";
                                break;
                            case DragonColors.Red:
                                NameCode += "R";
                                break;
                        }
                        break;
                    }
                    throw new ArgumentNullException(nameof(dc));

                case TileSuit.Wind:
                    NameCode += "Wi";
                    if (s.HasValue)
                    {
                        componentManager.AddComponent(tileEntityID, new SeasonComponent{Season = (Seasons)s});
                        switch(s)
                        {
                            case Seasons.East:
                                NameCode += "E";
                                break;
                            case Seasons.South:
                                NameCode += "S";
                                break;
                            case Seasons.West:
                                NameCode += "W";
                                break;
                            case Seasons.North:
                                NameCode += "N";
                                break;
                        }
                        break;
                    }
                    throw new ArgumentNullException(nameof(s));

                case TileSuit.Flower:
                    // Flower has color AND number
                    NameCode += "F";
                    if (fc.HasValue)
                    {
                        componentManager.AddComponent(tileEntityID, new FlowerColorComponent{FlowerColor = (FlowerColors)fc});
                        switch(fc)
                        {
                            case FlowerColors.Red:
                                NameCode += "R";
                                break;
                            case FlowerColors.Black:
                                NameCode += "B";
                                break;
                        }
                    }
                    else{throw new ArgumentNullException(nameof(fc));}

                    if (number.HasValue)
                    {
                        componentManager.AddComponent(tileEntityID, new NumberComponent{Number=(int)number});
                        NameCode += number;
                    }
                    else{throw new ArgumentNullException(nameof(number));}
                    break;
            }
            componentManager.AddComponent(tileEntityID, new TileCodeComponent{Code=NameCode});
            return tileEntityID;
        }
    }
}