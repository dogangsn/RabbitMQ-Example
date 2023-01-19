namespace RabbitMQ_Example.RabbitMQ
{
    public interface IRabbitMQProducer
    {
        public void SendMessage<T>(T Message);
    }
}
