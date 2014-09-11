using System.Collections.Generic;
using System.Net.Sockets;

namespace Boombang.Networking
{
    public class BufferPool
    {
        public const int BUF_SIZE = 512;

        public byte[] Buffer
        {
            get;
            private set;
        }

        public int OffsetPointer
        {
            get;
            private set;
        }

        public BufferPool(int SupportedAmount)
        {
            this.Buffer = new byte[BUF_SIZE * 2 * SupportedAmount];
            this.OffsetPointer = default(int);
        }

        public void PushAllReceivers(SocketSystem SocketSystem, ICollection<SocketAsyncEventArgs> Receivers)
        {
            foreach (SocketAsyncEventArgs Args in Receivers)
            {
                Args.SetBuffer(Buffer, OffsetPointer, BUF_SIZE);
               // Args.Completed += SocketSystem.IO_Completed;

                OffsetPointer += BUF_SIZE;
            }
        }

        public void PushAllSenders(SocketSystem SocketSystem, ICollection<SocketAsyncEventArgs> Senders)
        {
            foreach (SocketAsyncEventArgs Args in Senders)
            {
                Args.SetBuffer(Buffer, OffsetPointer, BUF_SIZE);
               // Args.Completed += SocketSystem.IO_Completed;

                OffsetPointer += BUF_SIZE;
            }
        }
    }
}
