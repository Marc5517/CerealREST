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

        private const String Get_By_Id = "Select * from Cereal2 where @Id = Id";

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

        //private const String Sugars_And_Fat = "Select * from Cereal2 where Sugars <= @Sugars AND Fat <= @Fat";

        //public IEnumerable<Cereal> GetBySugarsAndFat(int sugars, int fat)
        //{
        //    List<Cereal> cList = new List<Cereal>();

        //    using (SqlConnection conn = new SqlConnection(connectionString))
        //    {
        //        conn.Open();

        //        using (SqlCommand cmd = new SqlCommand(Sugars_And_Fat, conn))
        //        {
        //            cmd.Parameters.AddWithValue("@Sugars", sugars);
        //            cmd.Parameters.AddWithValue("@Fat", fat);
        //            SqlDataReader reader = cmd.ExecuteReader();
        //            while (reader.Read())
        //            {
        //                Cereal cer = ReadNextElement(reader);
        //                cList.Add(cer);
        //            }
        //            reader.Close();
        //        }
        //    }

        //    return cList;

        //}

        private const String Get_By_Sort = "Select * from Cereal2 Where (@Calories IS NULL or Calories < @Calories) AND (@Type IS NULL or [Type] = @Type) AND (@FatGT IS NULL or Fat > @FatGT)";

        public IEnumerable<Cereal> GetBySort(int? caloriesLT, string? type, int? fatGT)
        {
            List<Cereal> cList = new List<Cereal>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand(Get_By_Sort, conn))
                {
                    cmd.Parameters.AddWithValue("@Calories", $"{caloriesLT}");
                    cmd.Parameters.AddWithValue("@Type", $"{type}");
                    cmd.Parameters.AddWithValue("@FatGT", $"{fatGT}");
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


        private const String Get_By_Sorting = "Select * from Cereal2 Where " +
            "(@Name is NULL or [Name] = @Name) AND (@Mfr is NULL or Mfr = @Mfr) AND (@Type is NULL or [Type] = @Type) " +
            "AND (@Calories is NULL or Calories = @Calories) AND (@CaloriesGt is NULL or Calories > @CaloriesGt) AND (@CaloriesLT is NULL or Calories < @CaloriesLT) AND (@CaloriesGTE is NULL or Calories >= @CaloriesGTE) AND (@CaloriesLTE is NULL or Calories <= @CaloriesLTE) AND (@CaloriesNOT is NULL or Calories != @CaloriesNOT) " +
            "AND (@Protein is NULL or Protein = @Protein) AND (@ProteinGT is NULL or Protein > @ProteinGT) AND (@ProteinLT is NULL or Protein < @ProteinLT) AND (@ProteinGTE is NULL or Protein >= @ProteinGTE) AND (@ProteinLTE is NULL or Protein <= @ProteinLTE) AND (@ProteinNOT is NULL or Protein != @ProteinNOT) " +
            "AND (@Fat is NULL or Fat = @Fat) AND (@FatGT is NULL or Fat > @FatGT) AND (@FatLT is NULL or Fat < @FatLT) AND (@FatGTE is NULL or Fat >= @FatGTE) AND (@FatLTE is NULL or Fat <= @FatLTE) AND (@FatNOT is NULL or Fat != @FatNOT) " +
            "AND (@Sodium is NULL or Sodium = @Sodium) AND (@SodiumGT is NULL or Sodium > @SodiumGT) AND (@SodiumLT is NULL or Sodium < @SodiumLT) AND (@SodiumGTE is NULL or Sodium >= @SodiumGTE) AND (@SodiumLTE is NULL or Sodium <= @SodiumLTE) AND (@SodiumNot is NULL or Sodium != @SodiumNot) " +
            "AND (@Sugars is NULL or Sugars = @Sugars) AND (@SugarsGT is NULL or Sugars > @SugarsGT) AND (@SugarsLT is NULL or Sugars < @SugarsLT) AND (@SugarsGTE is NULL or Sugars >= @SugarsGTE) AND (@SugarsLTE is NULL or Sugars <= @SugarsLTE) AND (@SugarsNot is NULL or Sugars != @SugarsNot) " +
            "AND (@Potass is NULL or Potass = @Potass) AND (@PotassGT is NULL or Potass > @PotassGT) AND (@PotassLT is NULL or Potass < @PotassLT) AND (@PotassGTE is NULL or Potass >= @PotassGTE) AND (@PotassLTE is NULL or Potass <= @PotassLTE) AND (@PotassNot is NULL or Potass != @PotassNot) " +
            "AND (@Vitamins is NULL or Vitamins = @Vitamins) AND (@VitaminsGT is NULL or Vitamins > @VitaminsGT) AND (@VitaminsLT is NULL or Vitamins < @VitaminsLT) AND (@VitaminsGTE is NULL or Vitamins >= @VitaminsGTE) AND (@VitaminsLTE is NULL or Vitamins <= @VitaminsLTE) AND (@VitaminsNot is NULL or Vitamins != @VitaminsNot) " +
            "AND (@Shelf is NULL or Shelf = @Shelf) AND (@ShelfGT is NULL or Shelf > @ShelfGT) AND (@ShelfLT is NULL or Shelf < @ShelfLT) AND (@ShelfGTE is NULL or Shelf >= @ShelfGTE) AND (@ShelfLTE is NULL or Shelf <= @ShelfLTE) AND (@ShelfNot is NULL or Shelf != @ShelfNot) " +
            "AND (@Weight is NULL or [Weight] = @Weight) AND (@WeightGT is NULL or [Weight] > @WeightGT) AND (@WeightLT is NULL or [Weight] < @WeightLT) AND (@WeightGTE is NULL or [Weight] >= @WeightGTE) AND (@WeightLTE is NULL or [Weight] <= @WeightLTE) AND (@WeightNot is NULL or [Weight] != @WeightNot) " +
            "AND (@Cups is NULL or Cups = @Cups) AND (@CupsGT is NULL or Cups > @CupsGT) AND (@CupsLT is NULL or Cups < @CupsLT) AND (@CupsGTE is NULL or Cups >= @CupsGTE) AND (@CupsLTE is NULL or Cups <= @CupsLTE) AND (@CupsNot is NULL or Cups != @CupsNot) " +
            "AND (@Rating is NULL or Rating = @Rating) AND (@RatingGT is NULL or Rating > @RatingGT) AND (@RatingLT is NULL or Rating < @RatingLT) AND (@RatingGTE is NULL or Rating >= @RatingGTE) AND (@RatingLTE is NULL or Rating <= @RatingLTE) AND (@RatingNOT is NULL or Rating != @RatingNOT) " +
            "AND (@Fiber is NULL or Fiber = @Fiber) AND (@FiberGT is NULL or Fiber > @FiberGT) AND (@FiberLT is NULL or Fiber < @FiberLT) AND (@FiberGTE is NULL or Fiber >= @FiberGTE) AND (@FiberLTE is NULL or Fiber <= @FiberLTE) AND (@FiberNot is NULL or Fiber != @FiberNot) " +
            "AND (@Carbo is NULL or Carbo = @Carbo) AND (@CarboGT is NULL or Carbo > @CarboGT) AND (@CarboLT is NULL or Carbo < @CarboLT) AND (@CarboGTE is NULL or Carbo >= @CarboGTE) AND (@CarboLTE is NULL or Carbo <= @CarboLTE) AND (@CarboNot is NULL or Carbo != @CarboNot) " +
            "ORDER BY CASE " +
            "WHEN @SortBY = 'Calories' then Calories " +
            "WHEN @SortBY = 'Protein' then Protein " +
            "WHEN @SortBY = 'Fat' then Fat " +
            "WHEN @SortBY = 'Sodium' then Sodium " +
            "WHEN @SortBY = 'Sugars' then Sugars " +
            "WHEN @SortBY = 'Potass' then Potass " +
            "WHEN @SortBY = 'Vitamins' then Vitamins " +
            "WHEN @SortBY = 'Shelf' then Shelf " +
            "WHEN @SortBY = 'Weight' then [Weight] " +
            "WHEN @SortBY = 'Cups' then Cups " +
            "WHEN @SortBY = 'Rating' then Rating " +
            "WHEN @SortBY = 'Fiber' then Fiber " +
            "WHEN @SortBY = 'Carbo' then Carbo " +
            "WHEN @SortBY = 'Mfr' then Mfr " +
            "WHEN @SortBY = 'Type' then [Type] " +
            "WHEN @SortBY = 'Name' then [Name] " +
            "END";

        public IEnumerable<Cereal> GetBySorting(CerealFilter result, string? sortby)
        {
            List<Cereal> cList = new List<Cereal>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand(Get_By_Sorting, conn))
                {
                    cmd.Parameters.AddWithValue("@SortBy", $"{sortby}");
                    cmd.Parameters.AddWithValue("@Name", $"{result.Name}");
                    cmd.Parameters.AddWithValue("@Mfr", $"{result.Mfr}");
                    cmd.Parameters.AddWithValue("@Type", $"{result.Type}");
                    cmd.Parameters.AddWithValue("@Calories", $"{result.Calories}");
                    cmd.Parameters.AddWithValue("@CaloriesGT", $"{result.CaloriesGT}");
                    cmd.Parameters.AddWithValue("@CaloriesGTE", $"{result.CaloriesGTE}");
                    cmd.Parameters.AddWithValue("@CaloriesLT", $"{result.CaloriesLT}");
                    cmd.Parameters.AddWithValue("@CaloriesLTE", $"{result.CaloriesLTE}");
                    cmd.Parameters.AddWithValue("@CaloriesNot", $"{result.CaloriesNot}");
                    cmd.Parameters.AddWithValue("@Protein", $"{result.Protein}");
                    cmd.Parameters.AddWithValue("@ProteinGT", $"{result.ProteinGT}");
                    cmd.Parameters.AddWithValue("@ProteinGTE", $"{result.ProteinGTE}");
                    cmd.Parameters.AddWithValue("@ProteinLT", $"{result.ProteinLT}");
                    cmd.Parameters.AddWithValue("@ProteinLTE", $"{result.ProteinLTE}");
                    cmd.Parameters.AddWithValue("@ProteinNot", $"{result.ProteinNot}");
                    cmd.Parameters.AddWithValue("@Fat", $"{result.Fat}");
                    cmd.Parameters.AddWithValue("@FatGT", $"{result.FatGT}");
                    cmd.Parameters.AddWithValue("@FatGTE", $"{result.FatGTE}");
                    cmd.Parameters.AddWithValue("@FatLT", $"{result.FatLT}");
                    cmd.Parameters.AddWithValue("@FatLTE", $"{result.FatLTE}");
                    cmd.Parameters.AddWithValue("@FatNot", $"{result.FatNot}");
                    cmd.Parameters.AddWithValue("@Sodium", $"{result.Sodium}");
                    cmd.Parameters.AddWithValue("@SodiumGT", $"{result.SodiumGT}");
                    cmd.Parameters.AddWithValue("@SodiumGTE", $"{result.SodiumGTE}");
                    cmd.Parameters.AddWithValue("@SodiumLT", $"{result.SodiumLT}");
                    cmd.Parameters.AddWithValue("@SodiumLTE", $"{result.SodiumLTE}");
                    cmd.Parameters.AddWithValue("@SodiumNot", $"{result.SodiumNot}");
                    cmd.Parameters.AddWithValue("@Sugars", $"{result.Sugars}");
                    cmd.Parameters.AddWithValue("@SugarsGT", $"{result.SugarsGT}");
                    cmd.Parameters.AddWithValue("@SugarsGTE", $"{result.SugarsGTE}");
                    cmd.Parameters.AddWithValue("@SugarsLT", $"{result.SugarsLT}");
                    cmd.Parameters.AddWithValue("@SugarsLTE", $"{result.SugarsLTE}");
                    cmd.Parameters.AddWithValue("@SugarsNot", $"{result.SugarsNot}");
                    cmd.Parameters.AddWithValue("@Potass", $"{result.Potass}");
                    cmd.Parameters.AddWithValue("@PotassGT", $"{result.PotassGT}");
                    cmd.Parameters.AddWithValue("@PotassGTE", $"{result.PotassGTE}");
                    cmd.Parameters.AddWithValue("@PotassLT", $"{result.PotassLT}");
                    cmd.Parameters.AddWithValue("@PotassLTE", $"{result.PotassLTE}");
                    cmd.Parameters.AddWithValue("@PotassNot", $"{result.PotassNot}");
                    cmd.Parameters.AddWithValue("@Vitamins", $"{result.Vitamins}");
                    cmd.Parameters.AddWithValue("@VitaminsGT", $"{result.VitaminsGT}");
                    cmd.Parameters.AddWithValue("@VitaminsGTE", $"{result.VitaminsGTE}");
                    cmd.Parameters.AddWithValue("@VitaminsLT", $"{result.VitaminsLT}");
                    cmd.Parameters.AddWithValue("@VitaminsLTE", $"{result.VitaminsLTE}");
                    cmd.Parameters.AddWithValue("@VitaminsNot", $"{result.VitaminsNot}");
                    cmd.Parameters.AddWithValue("@Shelf", $"{result.Shelf}");
                    cmd.Parameters.AddWithValue("@ShelfGT", $"{result.ShelfGT}");
                    cmd.Parameters.AddWithValue("@ShelfGTE", $"{result.ShelfGTE}");
                    cmd.Parameters.AddWithValue("@ShelfLT", $"{result.ShelfLT}");
                    cmd.Parameters.AddWithValue("@ShelfLTE", $"{result.ShelfLTE}");
                    cmd.Parameters.AddWithValue("@ShelfNot", $"{result.ShelfNot}");
                    cmd.Parameters.AddWithValue("@Weight", $"{result.Weight}");
                    cmd.Parameters.AddWithValue("@WeightGT", $"{result.WeightGT}");
                    cmd.Parameters.AddWithValue("@WeightGTE", $"{result.WeightGTE}");
                    cmd.Parameters.AddWithValue("@WeightLT", $"{result.WeightLT}");
                    cmd.Parameters.AddWithValue("@WeightLTE", $"{result.WeightLTE}");
                    cmd.Parameters.AddWithValue("@WeightNot", $"{result.WeightNot}");
                    cmd.Parameters.AddWithValue("@Cups", $"{result.Cups}");
                    cmd.Parameters.AddWithValue("@CupsGT", $"{result.CupsGT}");
                    cmd.Parameters.AddWithValue("@CupsGTE", $"{result.CupsGTE}");
                    cmd.Parameters.AddWithValue("@CupsLT", $"{result.CupsLT}");
                    cmd.Parameters.AddWithValue("@CupsLTE", $"{result.CupsLTE}");
                    cmd.Parameters.AddWithValue("@CupsNot", $"{result.CupsNot}");
                    cmd.Parameters.AddWithValue("@Rating", $"{result.Rating}");
                    cmd.Parameters.AddWithValue("@RatingGT", $"{result.RatingGT}");
                    cmd.Parameters.AddWithValue("@RatingGTE", $"{result.RatingGTE}");
                    cmd.Parameters.AddWithValue("@RatingLT", $"{result.RatingLT}");
                    cmd.Parameters.AddWithValue("@RatingLTE", $"{result.RatingLTE}");
                    cmd.Parameters.AddWithValue("@RatingNot", $"{result.RatingNot}");
                    cmd.Parameters.AddWithValue("@Fiber", $"{result.Fiber}");
                    cmd.Parameters.AddWithValue("@FiberGT", $"{result.FiberGT}");
                    cmd.Parameters.AddWithValue("@FiberGTE", $"{result.FiberGTE}");
                    cmd.Parameters.AddWithValue("@FiberLT", $"{result.FiberLT}");
                    cmd.Parameters.AddWithValue("@FiberLTE", $"{result.FiberLTE}");
                    cmd.Parameters.AddWithValue("@FiberNot", $"{result.FiberNot}");
                    cmd.Parameters.AddWithValue("@Carbo", $"{result.Carbo}");
                    cmd.Parameters.AddWithValue("@CarboGT", $"{result.CarboGT}");
                    cmd.Parameters.AddWithValue("@CarboGTE", $"{result.CarboGTE}");
                    cmd.Parameters.AddWithValue("@CarboLT", $"{result.CarboLT}");
                    cmd.Parameters.AddWithValue("@CarboLTE", $"{result.CarboLTE}");
                    cmd.Parameters.AddWithValue("@CarboNot", $"{result.CarboNot}");
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

        private const String INSERT = "insert into Cereal2(Name, Mfr, Type, Calories, Protein, Fat, Sodium, Fiber, Carbo, Sugars, Potass, Vitamins, Shelf, Weight, Cups, Rating) Values(@Name, @Mfr, @Type, @Calories, @Protein, @Fat, @Sodium, @Fiber, @Carbo, @Sugars, @Potass, @Vitamins, @Shelf, @Weight, @Cups, @Rating)";

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

                int rowsAffected = cmd.ExecuteNonQuery();
            }
        }

        private const String UPDATE_Cereal = "UPDATE Cereal2 set Name=@Name, Mfr=@Mfr, Type=@Type, " +
            "Calories=@Calories, Protein=@Protein, Fat=@Fat, Sodium=@Sodium, Fiber=@Fiber, Carbo=@Carbo, " +
            "Sugars=@Sugars, Potass=@Potass, Vitamins=@Vitamins, Shelf=@Shelf, Weight=@Weight, Cups=@Cups, Rating=@Rating" +
            " where Id=@ID";
        
        public void UpdateCereal(int id, Cereal cereal)
        {
            Cereal cer = GetById(id);

            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(UPDATE_Cereal, conn))
            {
                conn.Open();
                cmd.Parameters.AddWithValue("@ID", id);
                cmd.Parameters.AddWithValue("@Name", cereal.Name);
                cmd.Parameters.AddWithValue("@Mfr", cereal.Mfr);
                cmd.Parameters.AddWithValue("@Type", cereal.Type);
                cmd.Parameters.AddWithValue("@Calories", cereal.Calories);
                cmd.Parameters.AddWithValue("@Protein", cereal.Protein);
                cmd.Parameters.AddWithValue("@Fat", cereal.Fat);
                cmd.Parameters.AddWithValue("@Sodium", cereal.Sodium);
                cmd.Parameters.AddWithValue("@Fiber", cereal.Fiber);
                cmd.Parameters.AddWithValue("@Carbo", cereal.Carbo);
                cmd.Parameters.AddWithValue("@Sugars", cereal.Sugars);
                cmd.Parameters.AddWithValue("@Potass", cereal.Potass);
                cmd.Parameters.AddWithValue("@Vitamins", cereal.Vitamins);
                cmd.Parameters.AddWithValue("@Shelf", cereal.Shelf);
                cmd.Parameters.AddWithValue("@Weight", cereal.Weight);
                cmd.Parameters.AddWithValue("@Cups", cereal.Cups);
                cmd.Parameters.AddWithValue("@Rating", cereal.Rating);

                int rowsAffected = cmd.ExecuteNonQuery();
                // evt. return rowsAffected == 1 => true if inserted otherwise false

                if (rowsAffected != 1)
                {
                    throw new KeyNotFoundException("Id not found, cannnot update a cereal if " + id + " does not exist.");
                }
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
            cereal.Rating = reader.SafeGetDouble(16);

            return cereal;
        }
        
        
    }
}
