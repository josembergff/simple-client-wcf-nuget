using System;
using System.ServiceModel;

namespace SimpleClientWCF
{
    public class ClientWCF<T1>
    {
        private string _url;
        public ClientWCF(string url)
        {
            _url = url;
        }

        public T1 ServiceTcp()
        {
            try
            {
                NetTcpBinding binding = new NetTcpBinding(SecurityMode.None);
                //binding.ReliableSession = new OptionalReliableSession { Enabled = true, Ordered = true, InactivityTimeout = TimeSpan.FromSeconds(10) };

                EndpointAddress address = new EndpointAddress(_url);

                ChannelFactory<T1> channelFactory = new ChannelFactory<T1>(binding, address);
                return channelFactory.CreateChannel();
            }catch(Exception ex)
            {
                return default(T1);
            }
        }

        public T1 ServiceHttp()
        {
            try
            {
                NetHttpBinding binding = new NetHttpBinding(BasicHttpSecurityMode.None);
                //binding.ReliableSession = new OptionalReliableSession { Enabled = true, Ordered = true, InactivityTimeout = TimeSpan.FromSeconds(10) };

                EndpointAddress address = new EndpointAddress(_url);

                ChannelFactory<T1> channelFactory = new ChannelFactory<T1>(binding, address);
                return channelFactory.CreateChannel();
            }
            catch (Exception ex)
            {
                return default(T1);
            }
        }

    }
}
