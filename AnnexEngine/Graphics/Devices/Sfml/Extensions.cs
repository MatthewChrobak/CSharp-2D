using SFML.Window;

namespace AnnexEngine.Graphics.Devices.Sfml
{
    /// <summary>
    /// Extension methods to be used with the Sfml device implementation.
    /// </summary>
    public static class Extensions
    {
        /// <summary>
        /// Filters SFML's KeyEventArgs into its actual string representation.
        /// Returns 'backspace' if the backspace button is pressed.
        /// Returns 'delete' if the delete button is pressed.
        /// </summary>
        /// <param name="e">The event to process.</param>
        /// <returns>The event filtered into a string.</returns>
        public static string FilterKey(this KeyEventArgs e)
        {
            // Get the key.
            string key = e.Code.ToString().ToLower();

            // Make sure it's a single character.
            if (key.Length == 1) {
                // Are we hitting shift?
                if (e.Shift) {
                    key = key.ToUpper();
                }
            } else {
                // If it's not a single character, explore other options.
                switch (key) {
                    case "space":
                        key = " ";
                        break;
                    case "delete":
                    case "backspace":
                        // Keep it as it is.
                        break;
                    default:
                        // TODO: Display the keypress in a log or something.
                        key = string.Empty;
                        break;
                }
            }

            // Return the filtered key.
            return key;
        }
    }
}
