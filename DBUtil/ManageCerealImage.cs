using CerealREST.Models;
using System.Data.SqlClient;
using System.Drawing;

namespace CerealREST.DBUtil
{
    public class ManageCerealImage
    {
        private const String connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=CerealDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        private const String Get_By_Id = "Select * from CerealImage where ImgId = @ImgId";

        public CerealImage GetById(int imgId)
        {
            CerealImage cI = new CerealImage();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                using (var cmd = new SqlCommand(Get_By_Id, conn))
                {
                    cmd.Parameters.AddWithValue("@ImgId", imgId);
                    var reader = cmd.ExecuteReader();
                    if (reader.Read()) cI = ReadNextElement(reader);
                }
            }

            return cI;
        }

        private CerealImage ReadNextElement(SqlDataReader reader)
        {
            CerealImage cerealI = new CerealImage();

            cerealI.ImgId = reader.GetInt32(0);
            cerealI.ImgName = reader.GetString(1);
            byte[] img = (byte[])(reader[2]);
            //Image image = ByteArrayToImage(img);
            cerealI.ImgData = img;
            

            return cerealI;

        }

        //public Image ByteArrayToImage(byte[] data)
        //{
        //    using (var ms = new MemoryStream(data))
        //    {
        //        return Image.FromStream(ms);
        //    }
        //}
    }
}
