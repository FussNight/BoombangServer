using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace Boombang.MySQL
{
    public class Query
    {
      
        public string Command { get; private set; }

       
        public List<MySqlParameter> Parameters { get; private set; }

    
        public QueryType OutType { get; private set; }

        
        public void Listen(string Command, QueryType OutType)
        {
            this.Command = Command;
            this.OutType = OutType;
            this.Parameters = new List<MySqlParameter>();
        }

   
        public void Push(string Name, object Item)
        {
            Parameters.Add(new MySqlParameter(string.Format("@{0}", Name), Item));
        }

     
        public void Dispose()
        {
            this.Command = null;
            this.Parameters = null;
        }
    }
}
