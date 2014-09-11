using System;
using System.Collections.Generic;
namespace Boombang.MySQL
{
    public struct QueryStream : IDisposable
    {
        
        public Stack<Query> Querys;

     
        public void Push(Query Query)
        {
            if (Querys == null)
            {
                Querys = new Stack<Query>();
            }

            Querys.Push(Query);
        }

      
        public QueryObject Pop(MySQLManager MySQLManager)
        {
            QueryObject Obj = new QueryObject();
            Obj.Push(MySQLManager, Querys.Pop());
            return Obj;
        }

        public void Pop(MySQLManager MySQLManager ,out object Output)
        {
            QueryObject.Push(MySQLManager, Querys.Pop(), out Output);
        }

     
        public void Lock()
        {
            var Stack = new Stack<Query>();

            foreach (var Query in this.Querys)
            {
                Stack.Push(Query);
            }

            this.Querys = Stack;
        }

   
        public void Dispose()
        {
            foreach (var Query in Querys)
            {
                Query.Dispose();
            }

            this.Querys = null;
        }
    }
}
