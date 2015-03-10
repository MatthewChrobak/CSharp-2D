using Server.IO;

namespace Server.Data.Models
{
    public class Player : Entity
    {
        public static string Folder = Server.StartupPath + "data\\players\\";

        public string Username { private set; get; }
        public string Password { private set; get; }

        public bool Create(string username, string password) {
            
            // Does the account already exist?
            if (!FolderSystem.FileExists(Folder + username + ".dat")) {
                // It doesn't exiset. Create a new player.

                this.Username = username;
                this.Password = password;

                return true;
            } else {
                // The account already exists. Return false.
                return false;
            }
        }
        public bool Login(string username, string password) {
            // Does the account exist?
            if (FolderSystem.FileExists(Folder + username + ".dat")) {

                // It exists. Start to load the player.
                var buffer = new DataBuffer(Folder + username + ".dat");
                this.Username = buffer.ReadString();

                // Does the password match up?
                if (buffer.ReadString() == password) {
                    // It matches up. Finish loading the player.
                    this.Password = password;

                    return true;
                } else {
                    return false;
                }
            } else {
                // It doesn't exist. Return false;
                return false;
            }
        }
        public bool Save() {
            var buffer = new DataBuffer();
            buffer.Write(Username);
            buffer.Write(Password);
            buffer.Save(Folder + Username.ToLower() + ".dat");
            return true;
        }  
    }
}
