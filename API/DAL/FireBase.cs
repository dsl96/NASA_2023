using FireSharp.Config;
using FireSharp.Response;
using FireSharp.Interfaces;
using FireSharp;
using System.Windows.Media.Imaging;
using System.Numerics;
using System.IO;


namespace API.DAL
{
    public class FireBase
    {
        internal readonly IFirebaseConfig ifireBase;

        private readonly IFirebaseClient _client;

        FireBase()
        {
            ifireBase = new FirebaseConfig()
            {
                //TODO  check the secret if that legal to writh this hear
                AuthSecret = "yYzF6hZWigvdAvl34IkzK5sTsVglcm8mwtEVqAeq",
                BasePath = "https://nasa2023-507e6-default-rtdb.firebaseio.com/"
            };

            _client = new FirebaseClient(ifireBase);
        }


        //internal async Task InsertPictureAsync(string pictureName, string data)
        //{
        //    BitmapImage image = new BitmapImage()

        //    image.BeginInit(); ;
        //    if (Uri.TryCreate(data, UriKind.Absolute, out Uri uriResult) &&
        //           (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps))
        //        image.UriSource = new Uri(data);
        //    else if ( data is byte[] bytes)
        //        using (MemoryStream stream = new MemoryStream(bytes))
        //            image.StreamSource = stream;

        //    image.CacheOption = BitmapCacheOption.OnLoad;
        //    image.EndInit();

        //    SetResponse response = await _client.SetAsync(pictureName, data);

        //}
    }
}
