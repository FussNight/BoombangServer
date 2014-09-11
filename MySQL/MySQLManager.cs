using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System;


namespace Boombang.MySQL
{
    public class MySQLManager
    {
        
       public string QueryHandlerString
       {
           get;
           private set;
       }

        public MySQLManager(string Host, uint Port, string Username, string Password,
            string Database, bool Pooling, uint MinimumPoolSize, uint MaximumPoolSize)
        {
            MySqlConnectionStringBuilder sb = new MySqlConnectionStringBuilder();
            sb.Server = Host;
            sb.Port = Port;
            sb.UserID = Username;
            sb.Password = Password;
            sb.Database = Database;
            sb.Pooling = Pooling;
            sb.MinimumPoolSize = MinimumPoolSize;
            sb.MaximumPoolSize = MaximumPoolSize;

            this.QueryHandlerString = sb.ConnectionString;
            
            Console.WriteLine("[Gestor MySQL] => ¡Oka!");
        }

        public void InvokeQuery(Query Query)
        {
            GetObject(Query);
        }

        public QueryObject GetObject(Query Query)
        {
            using (var Stream = new QueryStream())
            {
                Stream.Push(Query);
                return Stream.Pop(this);
            }
        }

      
        public Stack<QueryObject> GetObjects(params Query[] Querys)
        {
            Stack<QueryObject> Stack = new Stack<QueryObject>();

            using (var Stream = new QueryStream())
            {
                foreach (var Query in Querys)
                {
                    Stream.Push(Query);
                }

                for (int i = 0; i <= Stream.Querys.Count; i++)
                {
                    Stack.Push(Stream.Pop(this));
                }
            }

            return Stack;
        }
    }
}
