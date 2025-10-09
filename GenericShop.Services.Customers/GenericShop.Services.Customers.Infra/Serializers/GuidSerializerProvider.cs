using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Bson.Serialization;
using MongoDB.Bson;

namespace GenericShop.Services.Customers.Infra.Serializers
{
    public class GuidSerializerProvider : IBsonSerializationProvider
    {
        public IBsonSerializer GetSerializer(Type type)
        {
            return type == typeof(Guid) ? new GuidSerializer(GuidRepresentation.Standard) : null;
        }
    }
}
