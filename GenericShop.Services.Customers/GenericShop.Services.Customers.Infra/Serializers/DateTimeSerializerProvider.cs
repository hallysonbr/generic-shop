using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;

namespace GenericShop.Services.Customers.Infra.Serializers
{
    public class DateTimeSerializerProvider : IBsonSerializationProvider
    {
        public IBsonSerializer GetSerializer(Type type)
        {
            return type == typeof(DateTime) ? DateTimeSerializer.LocalInstance : null;
        }
    }
}
