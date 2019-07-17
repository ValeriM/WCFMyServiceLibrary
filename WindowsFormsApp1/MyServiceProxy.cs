/*
 Файл генерится утилитой
 SvcUtil  http://localhost:9001/MyService  /out:MyServiceProxy.cs  /config:App.config
 После того как готова и запущена служба 
 1. Инсталяция
 C:\Windows\Microsoft.NET\Framework\v4.0.30319\InstallUtil.exe WindowsServiceHostForMyService.exe
 2. Запуск через управление службами
 */

namespace ServiceReference1
{
    using System.Runtime.Serialization;
    using System;

    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName = "IMyService")]
    public interface IMyService
    {

        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IMyService/Method1", ReplyAction = "http://tempuri.org/IMyService/Method1Response")]
        string Method1(string x);

        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IMyService/Method2", ReplyAction = "http://tempuri.org/IMyService/Method2Response")]
        string Method2(string x);
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    public interface IMyServiceChannel : IMyService, System.ServiceModel.IClientChannel
    {
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    public partial class MyServiceClient : System.ServiceModel.ClientBase<IMyService>, IMyService
    {
        public MyServiceClient()
        {
        }

        public MyServiceClient(string endpointConfigurationName) :
                base(endpointConfigurationName)
        {
        }

        public MyServiceClient(string endpointConfigurationName, string remoteAddress) :
                base(endpointConfigurationName, remoteAddress)
        {
        }

        public MyServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) :
                base(endpointConfigurationName, remoteAddress)
        {
        }

        public MyServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) :
                base(binding, remoteAddress)
        {
        }

        public string Method1(string x)
        {
            return base.Channel.Method1(x);
        }

        public string Method2(string x)
        {
            return base.Channel.Method2(x);
        }
    }
}