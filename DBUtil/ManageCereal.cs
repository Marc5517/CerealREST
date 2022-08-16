using CerealREST.Models;
using System.Data.SqlClient;

namespace CerealREST.DBUtil
{
    public class ManageCereal
    {
        private const String connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=CerealDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        private const String Get_All = "Select * From Cereal2";

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

        private const String Get_By_Id = "Select * from Cereal2 where Id = @Id";

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

        //private const String Get_By_Calories = "Select * from Cereal2 where Calories = @Calories";

        //public IEnumerable<Cereal> GetByCalories(int calories)
        //{
        //    List<Cereal> cereals = new List<Cereal>();

        //    using (SqlConnection conn = new SqlConnection(connectionString))
        //    {
        //        conn.Open();

        //        using (SqlCommand cmd = new SqlCommand(Get_By_Calories, conn))
        //        {
        //            cmd.Parameters.AddWithValue("@Calories", calories);
        //            SqlDataReader reader = cmd.ExecuteReader();
        //            while (reader.Read())
        //            {
        //                Cereal cer = ReadNextElement(reader);
        //                cereals.Add(cer);
        //            }
        //            reader.Close();
        //        }
        //    }
        //    return cereals;
        //}

        //private const String Get_By_Type = "Select * from Cereal2 where Type IN (@Type)";

        //public IEnumerable<Cereal> GetByType(string type)
        //{
        //    List<Cereal> cereals = new List<Cereal>();

        //    using (SqlConnection conn = new SqlConnection(connectionString))
        //    {
        //        conn.Open();

        //        using (SqlCommand cmd = new SqlCommand(Get_By_Type, conn))
        //        {
        //            cmd.Parameters.AddWithValue("@Type", $"{type}");
        //            SqlDataReader reader = cmd.ExecuteReader();
        //            while (reader.Read())
        //            {
        //                Cereal cer = ReadNextElement(reader);
        //                cereals.Add(cer);
        //            }
        //            reader.Close();
        //        }
        //    }
        //    return cereals;
        //}

        //private const String Get_By_Category = "Select * From Cereal2 Where @category IN (@cate)";
        private const String Get_By_Name = "Select * from Cereal2 Where Name IN (@cate)";
        private const String Get_By_Mfr = "Select * from Cereal2 Where Mfr IN (@cate)";
        private const String Get_By_Type = "Select * from Cereal2 Where Type IN (@cate)";
        private const String Get_By_Calories = "Select * from Cereal2 Where Calories IN (@cate)";
        private const String Get_By_Fat = "Select * from Cereal2 Where Fat IN (@cate)";
        private const String Get_By_Sodium = "Select * from Cereal2 Where Sodium IN (@cate)";
        private const String Get_By_Fiber = "Select * from Cereal2 Where Name IN (@cate)";
        private const String Get_By_Protein = "Select * from Cereal2 Where Protein IN (@cate)";
        private const String Get_By_Carbo = "Select * from Cereal2 Where Carbo IN (@cate)";
        private const String Get_By_Sugars = "Select * from Cereal2 Where Sugars IN (@cate)";
        private const String Get_By_Potass = "Select * from Cereal2 Where Potass IN (@cate)";
        private const String Get_By_Vitamins = "Select * from Cereal2 Where Vitamins IN (@cate)";
        private const String Get_By_Shelf = "Select * from Cereal2 Where Shelf IN (@cate)";
        private const String Get_By_Weight = "Select * from Cereal2 Where Weight IN (@cate)";
        private const String Get_By_Cups = "Select * from Cereal2 Where Cups IN (@cate)";
        private const String Get_By_Rating = "Select * from Cereal2 Where Rating IN (@cate)";

        public IEnumerable<Cereal> GetByCategory(string category, string cate)
        {
            List<Cereal> cList = new List<Cereal>();

            var cQuery = "";

            if (category == "Name")
            {
                cQuery = Get_By_Name;
            }
            else if (category == "Mfr")
            {
                cQuery = Get_By_Mfr;
            }
            else if (category == "Type")
            {
                cQuery = Get_By_Type;
            }
            else if (category == "Calories")
            {
                cQuery = Get_By_Calories;
            }
            else if (category == "Protein")
            {
                cQuery = Get_By_Protein;
            }
            else if (category == "Fat")
            {
                cQuery = Get_By_Fat;
            }
            else if (category == "Sodium")
            {
                cQuery = Get_By_Sodium;
            }
            else if (category == "Fiber")
            {
                cQuery = Get_By_Fiber;
            }
            else if (category == "Carbo")
            {
                cQuery = Get_By_Carbo;
            }
            else if (category == "Sugars")
            {
                cQuery = Get_By_Sugars;
            }
            else if (category == "Potass")
            {
                cQuery = Get_By_Potass;
            }
            else if (category == "Vitamins")
            {
                cQuery = Get_By_Vitamins;
            }
            else if (category == "Shelf")
            {
                cQuery = Get_By_Shelf;
            }
            else if (category == "Weight")
            {
                cQuery = Get_By_Weight;
            }
            else if (category == "Cups")
            {
                cQuery = Get_By_Cups;
            }
            else if (category == "Rating")
            {
                cQuery = Get_By_Rating;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand(cQuery, conn))
                {
                    //cmd.Parameters.AddWithValue("@category", $"{category}");
                    cmd.Parameters.AddWithValue("@cate", $"{cate}");
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

        private const String Get_By_Exact_Calories = "Select * from Cereal2 Where Calories = @cate";
        private const String Get_By_Low_Or_Equal_Calories = "Select * from Cereal2 Where Calories >= @cate";
        private const String Get_By_High_Or_Equal_Calories = "Select * from Cereal2 Where Calories <= @cate";
        private const String Get_By_Low_Calories = "Select * from Cereal2 Where Calories > @cate";
        private const String Get_By_High_Calories = "Select * from Cereal2 Where Calories < @cate";
        private const String Get_By_Not_Equal_Calories = "Select * from Cereal2 Where Calories != @cate";
       
        private const String Get_By_Exact_Fat = "Select * from Cereal2 Where Fat = @cate";
        private const String Get_By_Low_Or_Equal_Fat = "Select * from Cereal2 Where Fat >= @cate";
        private const String Get_By_High_Or_Equal_Fat = "Select * from Cereal2 Where Fat <= @cate";
        private const String Get_By_Low_Fat = "Select * from Cereal2 Where Fat > @cate";
        private const String Get_By_High_Fat = "Select * from Cereal2 Where Fat < @cate";
        private const String Get_By_Not_Equal_Fat = "Select * from Cereal2 Where Fat != @cate";
        
        private const String Get_By_Exact_Protein = "Select * from Cereal2 Where Protein = @cate";
        private const String Get_By_Low_Or_Equal_Protein = "Select * from Cereal2 Where Protein >= @cate";
        private const String Get_By_High_Or_Equal_Protein = "Select * from Cereal2 Where Protein <= @cate";
        private const String Get_By_Low_Protein = "Select * from Cereal2 Where Protein > @cate";
        private const String Get_By_High_Protein = "Select * from Cereal2 Where Protein < @cate";
        private const String Get_By_Not_Equal_Protein = "Select * from Cereal2 Where Protein != @cate";
        
        private const String Get_By_Exact_Sodium = "Select * from Cereal2 Where Sodium = @cate";
        private const String Get_By_Low_Or_Equal_Sodium = "Select * from Cereal2 Where Sodium >= @cate";
        private const String Get_By_High_Or_Equal_Sodium = "Select * from Cereal2 Where Sodium <= @cate";
        private const String Get_By_Low_Sodium = "Select * from Cereal2 Where Sodium > @cate";
        private const String Get_By_High_Sodium = "Select * from Cereal2 Where Sodium < @cate";
        private const String Get_By_Not_Equal_Sodium = "Select * from Cereal2 Where Sodium != @cate";

        private const String Get_By_Exact_Fiber = "Select * from Cereal2 Where Fiber = @cate";
        private const String Get_By_Low_Or_Equal_Fiber = "Select * from Cereal2 Where Fiber >= @cate";
        private const String Get_By_High_Or_Equal_Fiber = "Select * from Cereal2 Where Fiber <= @cate";
        private const String Get_By_Low_Fiber = "Select * from Cereal2 Where Fiber > @cate";
        private const String Get_By_High_Fiber = "Select * from Cereal2 Where Fiber < @cate";
        private const String Get_By_Not_Equal_Fiber = "Select * from Cereal2 Where Fiber != @cate";
        
        private const String Get_By_Exact_Carbo = "Select * from Cereal2 Where Carbo = @cate";
        private const String Get_By_Low_Or_Equal_Carbo = "Select * from Cereal2 Where Carbo >= @cate";
        private const String Get_By_High_Or_Equal_Carbo = "Select * from Cereal2 Where Carbo <= @cate";
        private const String Get_By_Low_Carbo = "Select * from Cereal2 Where Carbo > @cate";
        private const String Get_By_High_Carbo = "Select * from Cereal2 Where Carbo < @cate";
        private const String Get_By_Not_Equal_Carbo = "Select * from Cereal2 Where Carbo != @cate";
        
        private const String Get_By_Exact_Sugars = "Select * from Cereal2 Where Sugars = @cate";
        private const String Get_By_Low_Or_Equal_Sugars = "Select * from Cereal2 Where Sugars >= @cate";
        private const String Get_By_High_Or_Equal_Sugars = "Select * from Cereal2 Where Sugars <= @cate";
        private const String Get_By_Low_Sugars = "Select * from Cereal2 Where Sugars > @cate";
        private const String Get_By_High_Sugars = "Select * from Cereal2 Where Sugars < @cate";
        private const String Get_By_Not_Equal_Sugars = "Select * from Cereal2 Where Sugars != @cate";
        
        private const String Get_By_Exact_Potass = "Select * from Cereal2 Where Potass = @cate";
        private const String Get_By_Low_Or_Equal_Potass = "Select * from Cereal2 Where Potass >= @cate";
        private const String Get_By_High_Or_Equal_Potass = "Select * from Cereal2 Where Potass <= @cate";
        private const String Get_By_Low_Potass = "Select * from Cereal2 Where Potass > @cate";
        private const String Get_By_High_Potass = "Select * from Cereal2 Where Potass < @cate";
        private const String Get_By_Not_Equal_Potass = "Select * from Cereal2 Where Potass != @cate";
        
        private const String Get_By_Exact_Vitamins = "Select * from Cereal2 Where Vitamins = @cate";
        private const String Get_By_Low_Or_Equal_Vitamins = "Select * from Cereal2 Where Vitamins >= @cate";
        private const String Get_By_High_Or_Equal_Vitamins = "Select * from Cereal2 Where Vitamins <= @cate";
        private const String Get_By_Low_Vitamins = "Select * from Cereal2 Where Vitamins > @cate";
        private const String Get_By_High_Vitamins = "Select * from Cereal2 Where Vitamins < @cate";
        private const String Get_By_Not_Equal_Vitamins = "Select * from Cereal2 Where Vitamins != @cate";
        
        private const String Get_By_Exact_Shelf = "Select * from Cereal2 Where Shelf = @cate";
        private const String Get_By_Low_Or_Equal_Shelf = "Select * from Cereal2 Where Shelf >= @cate";
        private const String Get_By_High_Or_Equal_Shelf = "Select * from Cereal2 Where Shelf <= @cate";
        private const String Get_By_Low_Shelf = "Select * from Cereal2 Where Shelf > @cate";
        private const String Get_By_High_Shelf = "Select * from Cereal2 Where Shelf < @cate";
        private const String Get_By_Not_Equal_Shelf = "Select * from Cereal2 Where Shelf != @cate";
        
        private const String Get_By_Exact_Weight = "Select * from Cereal2 Where Weight = @cate";
        private const String Get_By_Low_Or_Equal_Weight = "Select * from Cereal2 Where Weight >= @cate";
        private const String Get_By_High_Or_Equal_Weight = "Select * from Cereal2 Where Weight <= @cate";
        private const String Get_By_Low_Weight = "Select * from Cereal2 Where Weight > @cate";
        private const String Get_By_High_Weight = "Select * from Cereal2 Where Weight < @cate";
        private const String Get_By_Not_Equal_Weight = "Select * from Cereal2 Where Weight != @cate";
        
        private const String Get_By_Exact_Cups = "Select * from Cereal2 Where Cups = @cate";
        private const String Get_By_Low_Or_Equal_Cups = "Select * from Cereal2 Where Cups >= @cate";
        private const String Get_By_High_Or_Equal_Cups = "Select * from Cereal2 Where Cups <= @cate";
        private const String Get_By_Low_Cups = "Select * from Cereal2 Where Cups > @cate";
        private const String Get_By_High_Cups = "Select * from Cereal2 Where Cups < @cate";
        private const String Get_By_Not_Equal_Cups = "Select * from Cereal2 Where Cups != @cate";
        
        private const String Get_By_Exact_Rating = "Select * from Cereal2 Where Rating = @cate";
        private const String Get_By_Low_Or_Equal_Rating = "Select * from Cereal2 Where Rating >= @cate";
        private const String Get_By_High_Or_Equal_Rating = "Select * from Cereal2 Where Rating <= @cate";
        private const String Get_By_Low_Rating = "Select * from Cereal2 Where Rating > @cate";
        private const String Get_By_High_Rating = "Select * from Cereal2 Where Rating < @cate";
        private const String Get_By_Not_Equal_Rating = "Select * from Cereal2 Where Rating != @cate";

        public IEnumerable<Cereal> GetBySortingCategory(string category2, string sort, int cate2)
        {
            List<Cereal> cList = new List<Cereal>();

            var cQuery = "";

            if (category2 == "Calories")
            {
                if (sort == "=")
                {
                    cQuery = Get_By_Exact_Calories;
                }
                else if (sort == ">=")
                {
                    cQuery = Get_By_Low_Or_Equal_Calories;
                }
                else if (sort == "<=")
                {
                    cQuery = Get_By_High_Or_Equal_Calories;
                }
                else if (sort == ">")
                {
                    cQuery = Get_By_Low_Calories;
                }
                else if (sort == "<")
                {
                    cQuery = Get_By_High_Calories;
                }
                else if (sort == "!=")
                {
                    cQuery = Get_By_Not_Equal_Calories;
                }
            }
            else if (category2 == "Fat")
            {
                if (sort == "=")
                {
                    cQuery = Get_By_Exact_Fat;
                }
                else if (sort == ">=")
                {
                    cQuery = Get_By_Low_Or_Equal_Fat;
                }
                else if (sort == "<=")
                {
                    cQuery = Get_By_High_Or_Equal_Fat;
                }
                else if (sort == ">")
                {
                    cQuery = Get_By_Low_Fat;
                }
                else if (sort == "<")
                {
                    cQuery = Get_By_High_Fat;
                }
                else if (sort == "!=")
                {
                    cQuery = Get_By_Not_Equal_Fat;
                }
            }
            else if (category2 == "Protein")
            {
                if (sort == "=")
                {
                    cQuery = Get_By_Exact_Protein;
                }
                else if (sort == ">=")
                {
                    cQuery = Get_By_Low_Or_Equal_Protein;
                }
                else if (sort == "<=")
                {
                    cQuery = Get_By_High_Or_Equal_Protein;
                }
                else if (sort == ">")
                {
                    cQuery = Get_By_Low_Protein;
                }
                else if (sort == "<")
                {
                    cQuery = Get_By_High_Protein;
                }
                else if (sort == "!=")
                {
                    cQuery = Get_By_Not_Equal_Protein;
                }
            }
            else if (category2 == "Sodium")
            {
                if (sort == "=")
                {
                    cQuery = Get_By_Exact_Sodium;
                }
                else if (sort == ">=")
                {
                    cQuery = Get_By_Low_Or_Equal_Sodium;
                }
                else if (sort == "<=")
                {
                    cQuery = Get_By_High_Or_Equal_Sodium;
                }
                else if (sort == ">")
                {
                    cQuery = Get_By_Low_Sodium;
                }
                else if (sort == "<")
                {
                    cQuery = Get_By_High_Sodium;
                }
                else if (sort == "!=")
                {
                    cQuery = Get_By_Not_Equal_Sodium;
                }
            }
            else if (category2 == "Fiber")
            {
                if (sort == "=")
                {
                    cQuery = Get_By_Exact_Fiber;
                }
                else if (sort == ">=")
                {
                    cQuery = Get_By_Low_Or_Equal_Fiber;
                }
                else if (sort == "<=")
                {
                    cQuery = Get_By_High_Or_Equal_Fiber;
                }
                else if (sort == ">")
                {
                    cQuery = Get_By_Low_Fiber;
                }
                else if (sort == "<")
                {
                    cQuery = Get_By_High_Fiber;
                }
                else if (sort == "!=")
                {
                    cQuery = Get_By_Not_Equal_Fiber;
                }
            }
            else if (category2 == "Carbo")
            {
                if (sort == "=")
                {
                    cQuery = Get_By_Exact_Carbo;
                }
                else if (sort == ">=")
                {
                    cQuery = Get_By_Low_Or_Equal_Carbo;
                }
                else if (sort == "<=")
                {
                    cQuery = Get_By_High_Or_Equal_Carbo;
                }
                else if (sort == ">")
                {
                    cQuery = Get_By_Low_Carbo;
                }
                else if (sort == "<")
                {
                    cQuery = Get_By_High_Carbo;
                }
                else if (sort == "!=")
                {
                    cQuery = Get_By_Not_Equal_Carbo;
                }
            }
            else if (category2 == "Sugars")
            {
                if (sort == "=")
                {
                    cQuery = Get_By_Exact_Sugars;
                }
                else if (sort == ">=")
                {
                    cQuery = Get_By_Low_Or_Equal_Sugars;
                }
                else if (sort == "<=")
                {
                    cQuery = Get_By_High_Or_Equal_Sugars;
                }
                else if (sort == ">")
                {
                    cQuery = Get_By_Low_Sugars;
                }
                else if (sort == "<")
                {
                    cQuery = Get_By_High_Sugars;
                }
                else if (sort == "!=")
                {
                    cQuery = Get_By_Not_Equal_Sugars;
                }
            }
            else if (category2 == "Potass")
            {
                if (sort == "=")
                {
                    cQuery = Get_By_Exact_Potass;
                }
                else if (sort == ">=")
                {
                    cQuery = Get_By_Low_Or_Equal_Potass;
                }
                else if (sort == "<=")
                {
                    cQuery = Get_By_High_Or_Equal_Potass;
                }
                else if (sort == ">")
                {
                    cQuery = Get_By_Low_Potass;
                }
                else if (sort == "<")
                {
                    cQuery = Get_By_High_Potass;
                }
                else if (sort == "!=")
                {
                    cQuery = Get_By_Not_Equal_Potass;
                }
            }
            else if (category2 == "Vitamins")
            {
                if (sort == "=")
                {
                    cQuery = Get_By_Exact_Vitamins;
                }
                else if (sort == ">=")
                {
                    cQuery = Get_By_Low_Or_Equal_Vitamins;
                }
                else if (sort == "<=")
                {
                    cQuery = Get_By_High_Or_Equal_Vitamins;
                }
                else if (sort == ">")
                {
                    cQuery = Get_By_Low_Vitamins;
                }
                else if (sort == "<")
                {
                    cQuery = Get_By_High_Vitamins;
                }
                else if (sort == "!=")
                {
                    cQuery = Get_By_Not_Equal_Vitamins;
                }
            }
            else if (category2 == "Shelf")
            {
                if (sort == "=")
                {
                    cQuery = Get_By_Exact_Shelf;
                }
                else if (sort == ">=")
                {
                    cQuery = Get_By_Low_Or_Equal_Shelf;
                }
                else if (sort == "<=")
                {
                    cQuery = Get_By_High_Or_Equal_Shelf;
                }
                else if (sort == ">")
                {
                    cQuery = Get_By_Low_Shelf;
                }
                else if (sort == "<")
                {
                    cQuery = Get_By_High_Shelf;
                }
                else if (sort == "!=")
                {
                    cQuery = Get_By_Not_Equal_Shelf;
                }
            }
            else if (category2 == "Weight")
            {
                if (sort == "=")
                {
                    cQuery = Get_By_Exact_Weight;
                }
                else if (sort == ">=")
                {
                    cQuery = Get_By_Low_Or_Equal_Weight;
                }
                else if (sort == "<=")
                {
                    cQuery = Get_By_High_Or_Equal_Weight;
                }
                else if (sort == ">")
                {
                    cQuery = Get_By_Low_Weight;
                }
                else if (sort == "<")
                {
                    cQuery = Get_By_High_Weight;
                }
                else if (sort == "!=")
                {
                    cQuery = Get_By_Not_Equal_Weight;
                }
            }
            else if (category2 == "Cups")
            {
                if (sort == "=")
                {
                    cQuery = Get_By_Exact_Cups;
                }
                else if (sort == ">=")
                {
                    cQuery = Get_By_Low_Or_Equal_Cups;
                }
                else if (sort == "<=")
                {
                    cQuery = Get_By_High_Or_Equal_Cups;
                }
                else if (sort == ">")
                {
                    cQuery = Get_By_Low_Cups;
                }
                else if (sort == "<")
                {
                    cQuery = Get_By_High_Cups;
                }
                else if (sort == "!=")
                {
                    cQuery = Get_By_Not_Equal_Cups;
                }
            }
            else if (category2 == "Rating")
            {
                if (sort == "=")
                {
                    cQuery = Get_By_Exact_Rating;
                }
                else if (sort == ">=")
                {
                    cQuery = Get_By_Low_Or_Equal_Rating;
                }
                else if (sort == "<=")
                {
                    cQuery = Get_By_High_Or_Equal_Rating;
                }
                else if (sort == ">")
                {
                    cQuery = Get_By_Low_Rating;
                }
                else if (sort == "<")
                {
                    cQuery = Get_By_High_Rating;
                }
                else if (sort == "!=")
                {
                    cQuery = Get_By_Not_Equal_Rating;
                }
            }
            

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand(cQuery, conn))
                {
                    //cmd.Parameters.AddWithValue("@category", $"{category}");
                    cmd.Parameters.AddWithValue("@cate", $"{cate2}");
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

        private const String Sugars_And_Fat = "Select * from Cereal2 where Sugars <= @Sugars AND Fat <= @Fat";

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

        private const String INSERT = "insert into Cereal2(Name, Mfr, Type, Calories, Protein, Fat, Sodium, Fiber, Carbo, Sugars, Potass, Vitamins, Shelf, Weight, Cups, Rating, Image) Values(@Name, @Mfr, @Type, @Calories, @Protein, @Fat, @Sodium, @Fiber, @Carbo, @Sugars, @Potass, @Vitamins, @Shelf, @Weight, @Cups, @Rating, @Image)";

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

        private const String DELETE_CEREAL = "DELETE Cereal2 WHERE Id = @Id";

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

        //public static double? SafeGetDouble(this SqlDataReader reader, int colIndex)
        //{
        //    if (!reader.IsDBNull(colIndex))
        //    {
        //        return reader.GetDouble(colIndex);
        //    }
        //    else
        //    {
        //        return null;
        //    }
        //}

        private Cereal ReadNextElement(SqlDataReader reader)
        {
            Cereal cereal = new Cereal();

            int size = 1024 * 1024;
            byte[] buffer = new byte[size];
            int readBytes = 0;
            int index = 0;

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
            cereal.Rating = reader.SafeGetDouble(16);
            //cereal.Image = (byte[])Convert.FromBase64String(reader.GetString(17));
            cereal.Image = reader.GetBytes(17, index, buffer, 0, size);

            return cereal;
        }
        
        
    }
}
