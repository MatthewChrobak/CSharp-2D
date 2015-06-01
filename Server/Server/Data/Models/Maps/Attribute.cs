namespace Server.Data.Models.Maps
{
    public enum MapAttributes
    {
        None,
        Length
    }

    public class Attribute
    {
        public int Type { private set; get; }
        public object Data { private set; get; }

        public Attribute(int type, object data) {
            this.Type = type;
            this.Data = data;
        }
    }
}
