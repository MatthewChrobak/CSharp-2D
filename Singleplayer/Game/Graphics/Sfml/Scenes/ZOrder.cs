namespace Game.Graphics.Sfml.Scenes
{
    public static class ZOrder
    {
        // Initialize the Z to be -1 so that when we ask for a Z value, we'll get 0.
        private static int _z = -1;

        public static int GetNewZ() {
            // Return the incremented value of Z.
            return ++ZOrder._z;
        }

        public static int GetHighZ() {
            // Return the actual value of Z without incrementing.
            return ZOrder._z;
        }

        public static void ResetZOrder() {
            // Change the Z variable to be -1 so that when we
            // ask for a Z value, we'll get 0.
            ZOrder._z = -1;
        }
    }
}
