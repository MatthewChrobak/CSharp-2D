namespace Server.Data.Models.Maps
{
    public class Tile
    {
        public Attribute Attribute;

        public Tile(int type, object data) {
            Attribute = new Attribute(type, data);
        }

        public Tile() {
            Attribute = new Attribute((int)MapAttributes.None, 0);
        }
    }
}
