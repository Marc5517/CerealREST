using CerealREST.Models;
using System.Data.SqlClient;

namespace CerealREST.DBUtil
{
    public class ManageCereal
    {
        private const String connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=CerealDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        private const String Get_All = "Select * From Cereal";

        public IEnumerable<Cereal> Get()
        {
            List<Cereal> cereals = new List<Cereal>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(Get_All, conn))
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Cereal cer = ReadNextElement(reader);
                    cereals.Add(cer);
                }
                reader.Close();
            }
            return cereals;
        }

        private const String Get_By_Id = "Select * from Cereal where Id = @Id";

        public Cereal GetById(int id)
        {
            Cereal c = new Cereal();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                using (var cmd = new SqlCommand(Get_By_Id, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    var reader = cmd.ExecuteReader();
                    if (reader.Read()) c = ReadNextElement(reader);
                }
            }

            return c;
        }

        private const String Get_By_Calories = "Select * from Cereal where Calories = @Calories";

        public IEnumerable<Cereal> GetByCalories(int calories)
        {
            List<Cereal> cereals = new List<Cereal>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand(Get_By_Calories, conn))
                {
                    cmd.Parameters.AddWithValue("@Calories", calories);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Cereal cer = ReadNextElement(reader);
                        cereals.Add(cer);
                    }
                    reader.Close();
                }
            }
            return cereals;
        }

        private const String Get_By_Type = "Select * from Cereal where Type IN (@Type)";

        public IEnumerable<Cereal> GetByType(string type)
        {
            List<Cereal> cereals = new List<Cereal>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand(Get_By_Type, conn))
                {
                    cmd.Parameters.AddWithValue("@Type", $"{type}");
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Cereal cer = ReadNextElement(reader);
                        cereals.Add(cer);
                    }
                    reader.Close();
                }
            }
            return cereals;
        }

        private const String Sugars_And_Fat = "Select* from Cereal where Sugars <= @Sugars AND Fat <= @Fat";

        public IEnumerable<Cereal> GetBySugarsAndFat(int sugars, int fat)
        {
            List<Cereal> cList = new List<Cereal>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand(Sugars_And_Fat, conn))
                {
                    cmd.Parameters.AddWithValue("@Sugars", sugars);
                    cmd.Parameters.AddWithValue("@Fat", fat);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Cereal cer = ReadNextElement(reader);
                        cList.Add(cer);
                    }
                    reader.Close();
                }
            }

            return cList;

        }

        private const String INSERT = "insert into Cereal(Name, Mfr, Type, Calories, Protein, Fat, Sodium, Fiber, Carbo, Sugars, Potass, Vitamins, Shelf, Weight, Cups, Rating, Image) Values(@Name, @Mfr, @Type, @Calories, @Protein, @Fat, @Sodium, @Fiber, @Carbo, @Sugars, @Potass, @Vitamins, @Shelf, @Weight, @Cups, @Rating, @Image)";

        public void Add(Cereal value)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(INSERT, conn))
            {
                conn.Open();
                cmd.Parameters.AddWithValue("@Name", value.Name);
                cmd.Parameters.AddWithValue("@Mfr", value.Mfr);
                cmd.Parameters.AddWithValue("@Type", value.Type);
                cmd.Parameters.AddWithValue("@Calories", value.Calories);
                cmd.Parameters.AddWithValue("@Protein", value.Protein);
                cmd.Parameters.AddWithValue("@Fat", value.Fat);
                cmd.Parameters.AddWithValue("@Sodium", value.Sodium);
                cmd.Parameters.AddWithValue("@Fiber", value.Fiber);
                cmd.Parameters.AddWithValue("@Carbo", value.Carbo);
                cmd.Parameters.AddWithValue("@Sugars", value.Sugars);
                cmd.Parameters.AddWithValue("@Potass", value.Potass);
                cmd.Parameters.AddWithValue("@Vitamins", value.Vitamins);
                cmd.Parameters.AddWithValue("@Shelf", value.Shelf);
                cmd.Parameters.AddWithValue("@Weight", value.Weight);
                cmd.Parameters.AddWithValue("@Cups", value.Cups);
                cmd.Parameters.AddWithValue("@Rating", value.Rating);
                cmd.Parameters.AddWithValue("@Image", value.Image);

                int rowsAffected = cmd.ExecuteNonQuery();
            }
        }

        private const String DELETE_CEREAL = "DELETE Cereal WHERE Id = @Id";

        public Cereal DeleteCereal(int id)
        {
            Cereal cere = GetById(id);

            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(DELETE_CEREAL, conn))
            {
                conn.Open();
                cmd.Parameters.AddWithValue("@Id", id);

                int rowsAffected = cmd.ExecuteNonQuery();
            }

            return cere;
        }

        private Cereal ReadNextElement(SqlDataReader reader)
        {
            Cereal cereal = new Cereal();

            cereal.Id = reader.GetInt32(0);
            cereal.Name = reader.GetString(1);
            cereal.Mfr = reader.GetString(2);
            cereal.Type = reader.GetString(3);
            cereal.Calories = reader.GetInt32(4);
            cereal.Protein = reader.GetInt32(5);
            cereal.Fat = reader.GetInt32(6);
            cereal.Sodium = reader.GetInt32(7);
            cereal.Fiber = reader.GetDouble(8);
            cereal.Carbo = reader.GetDouble(9);
            cereal.Sugars = reader.GetInt32(10);
            cereal.Potass = reader.GetInt32(11);
            cereal.Vitamins = reader.GetInt32(12);
            cereal.Shelf = reader.GetInt32(13);
            cereal.Weight = reader.GetDouble(14);
            cereal.Cups = reader.GetDouble(15);
            cereal.Rating = reader.GetDouble(16);
            cereal.Image = reader.GetString(17);

            return cereal;
        }
    }
}
