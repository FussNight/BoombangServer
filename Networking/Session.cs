using System;
using System.Net.Sockets;
using System.Text;


namespace Boombang.Networking
{
    public class Session
    {
        public Socket Socket
        {
            get;
            set;
        }

        /*public Protocol HabboEncryption
        {
            get;
            set;
        }*/

        public SocketAsyncEventArgs ReceiveEventArgs
        {
            get;
            set;
        }

        public int SendBytesRemainingCount
        {
            get;
            set;
        }

       /* public User User
        {
            get;
            set;
        }*/

        public int BytesSentAlreadyCount
        {
            get;
            set;
        }

        public byte[] DataToSend
        {
            get;
            set;
        }

        public void OnDissconection()
        {
            Console.WriteLine("Closing connection...");
        }

       /* public void UpdateCharacter(User user)
        {
            this.User = user;
        }*/


        public void Send(string Data)
        {
            Socket.Send(Encoding.Default.GetBytes(Data));
        }

       /* public void Send(ServerMessage Message)
        {
            this.Socket.Send(this.User.GlobalCrypto.Enciphe(Message.GetBytes()));
        } */

        public void SendByte(byte[] Data)
        {
            Socket.Send(Data);
        }

        /*public void Send(ServerPacket Packet)
        {
            Socket.Send(Packet.ToByteArray());
        }*/

        public void FinishSend(IAsyncResult Result)
        {
            if (!Result.IsCompleted)
            {
                // > FAIL
            }
        }

        internal static byte[] Deciphe(byte[] Data)
        {
            throw new NotImplementedException();
        }
    }
}
