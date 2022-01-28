using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using RestSharp;
using System.Drawing.Imaging;
using System.Drawing;

namespace API2
{
    public class ImageDownloader
    {
        //first method to save
        public static Image GetPicture(string url)
        {
            RestClient client = new RestClient(url) 
            {
                Timeout = 300000
            };
            RestRequest request = new RestRequest(Method.GET);
            byte[] array = client.DownloadData(request);
            MemoryStream mem = new MemoryStream(array);

            var yourImage = Image.FromStream(mem);

            yourImage.Save(@"C:\Users\slavu\OneDrive\Рабочий стол\API2\ффф.jpeg", ImageFormat.Jpeg);
       
            return yourImage;
        }


        //second method to save
        public static bool ByteArrayToFile(string fileName, byte[] byteArray)
        {
            try
            {
                using (var fs = new FileStream(fileName, FileMode.Create, FileAccess.Write))
                {
                    fs.Write(byteArray, 0, byteArray.Length);
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception caught in process: {0}", ex);
                return false;
            }
        }



    }

}
