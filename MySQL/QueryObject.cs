using System;
using MySql.Data.MySqlClient;

namespace Boombang.MySQL
{
    public class QueryObject
    {
      
        public object Output { get; private set; }

      
        public void Push(MySQLManager MySQLManager, Query Query)
        {
            try
            {
                switch (Query.OutType)
                {
                    case QueryType.Action:
                        MySqlHelper.ExecuteNonQuery(MySQLManager.QueryHandlerString, Query.Command, Query.Parameters.ToArray());
                        break;
                    case QueryType.DataRow:
                        Output = MySqlHelper.ExecuteDataRow(MySQLManager.QueryHandlerString, Query.Command, Query.Parameters.ToArray());
                        break;
                    case QueryType.DataTable:
                        Output = MySqlHelper.ExecuteDataset(MySQLManager.QueryHandlerString, Query.Command, Query.Parameters.ToArray()).Tables[0];
                        break;
                    case QueryType.String:
                        Output = Convert.ToString(MySqlHelper.ExecuteScalar(MySQLManager.QueryHandlerString, Query.Command, Query.Parameters.ToArray()));
                        break;
                    case QueryType.Integer:
                        Output = Convert.ToInt32(MySqlHelper.ExecuteScalar(MySQLManager.QueryHandlerString, Query.Command, Query.Parameters.ToArray()));
                        break;
                    case QueryType.Boolean:
                        Output = Convert.ToInt32(MySqlHelper.ExecuteScalar(MySQLManager.QueryHandlerString, Query.Command, Query.Parameters.ToArray())) > 0;
                        break;
                }
            }
            catch { Output = null; }

            Query.Dispose();
        }

     
        public static void Push(MySQLManager MySQLManager, Query Query, out object Output)
        {
            QueryObject Obj = new QueryObject();
            Obj.Push(MySQLManager, Query);
            Output = Obj.Output;

            if (Output == null)
            {
                Output = new object();
            }

            Query.Dispose();
        }

      
        public T GetOutput<T>()
        {
            return (T)Output;
        }
    }
}
