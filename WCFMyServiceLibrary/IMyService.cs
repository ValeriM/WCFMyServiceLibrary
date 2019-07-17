using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace WCFMyServiceLibrary
{
    [ServiceContract]
    public interface IMyService
    {
        [OperationContract]
        string Method1(string x);
        [OperationContract]
        string Method2(string x);
    }
}
