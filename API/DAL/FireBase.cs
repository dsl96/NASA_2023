using FireSharp.Config;
using FireSharp.Response;
using FireSharp.Interfaces;
using FireSharp;
using System.Windows.Media.Imaging;
using System.Numerics;
using System.IO;
using Firebase.Storage;
using System.Windows.Forms;

namespace API.DAL
{
    public class FireBase
    {
        internal readonly IFirebaseConfig ifireBase;

        private readonly IFirebaseClient _client;

        private readonly FirebaseStorage _storage;
        public FireBase()
        {
            ifireBase = new FirebaseConfig()
            {
                //TODO  check the secret if that legal to writh this hear
                AuthSecret = "yYzF6hZWigvdAvl34IkzK5sTsVglcm8mwtEVqAeq",
                BasePath = "https://nasa2023-507e6-default-rtdb.firebaseio.com/"
            };

            _storage = new FirebaseStorage("https://nasa2023-507e6-default-rtdb.firebaseio.com/");
            _client = new FirebaseClient(ifireBase);
        }

        public async Task UploadImageAsync(string imageData, string? storagePath = null)
        {
            try
            {
                byte[] imageBytes = Convert.FromBase64String(imageData);

                using (var stream = new MemoryStream(imageBytes))
                {
                    // Upload the file to Firebase Storage
                    var task = await _storage.Child(storagePath)
                                              .PutAsync(stream);

                    MessageBox.Show("File uploaded successfully");
                }
            }
            catch (Exception ex)
            {
               MessageBox.Show($"Error uploading file: {ex.Message}");
            }
        }
    }
}
