using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlaveApp
{
    using Apache.NMS;
    using Apache.NMS.ActiveMQ;

    class Program
    {
        static void Main(string[] args)
        {
            IConnectionFactory factory = new ConnectionFactory("tcp://192.168.99.100:61616");

            IConnection connection = factory.CreateConnection();

            connection.ClientId = "firstQueueListener";

            connection.Start();

            ISession session = connection.CreateSession();

            //            IMessageConsumer consumer = session.CreateConsumer(new Apache.NMS.ActiveMQ.Commands.ActiveMQQueue("firstqueue"), "filter='demo'");
            IMessageConsumer consumer = session.CreateConsumer(new Apache.NMS.ActiveMQ.Commands.ActiveMQQueue("firstqueue"));

            consumer.Listener += new MessageListener(consumer_Listener);

            Console.Read();
        }

        static void consumer_Listener(IMessage message)
        {
            ITextMessage msg = (ITextMessage)message;

        }
    }
}
