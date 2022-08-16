using System.Data.SqlClient;

namespace CerealREST.DBUtil
{
    public static class ManageExtension
    {
        public static double SafeGetDouble(this SqlDataReader reader,
                                    int colIndex)
        {
            if (!reader.IsDBNull(colIndex))
                return reader.GetDouble(colIndex);
            return 0;
        }
    }
}
