using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snakey.Proxy
{
    public interface IConnectionManager
    {
        bool IsConnected();
        void ConnectToServer();
    }
}
