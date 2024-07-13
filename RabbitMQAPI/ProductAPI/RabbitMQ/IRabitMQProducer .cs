using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductAPI.RabbitMQ
{
    public interface IRabitMQProducer 
    {
                public void SendProductMessage < T > (T message);

    }
}