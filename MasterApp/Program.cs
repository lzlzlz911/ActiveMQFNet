using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterApp
{
    using Apache.NMS;
    using Apache.NMS.ActiveMQ;
    using Apache.NMS.ActiveMQ.Commands;

    class Program
    {
        static void Main(string[] args)
        {
            IConnectionFactory factory = new ConnectionFactory("tcp://192.168.99.100:61616");

            using (IConnection connection = factory.CreateConnection())
            {
                using (ISession session = connection.CreateSession())
                {
                    IMessageProducer prod = session.CreateProducer(new ActiveMQQueue("firstqueue"));

                    ITextMessage message = prod.CreateTextMessage();

                    message.Text = "hw";

                    prod.Send(message);
                }
            }
        }
    }
}
