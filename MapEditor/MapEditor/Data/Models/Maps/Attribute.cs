namespace MapEditor.Data.Models.Maps
{
    public enum MapAttributes
    {
        None,
        Length
    }

    public class Attribute
    {
        public int Type;
        public object Data;

        public Attribute() {
            Type = 0;
        }
    }
}
