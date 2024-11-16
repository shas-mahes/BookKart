using System.Text.Json;

namespace BookKart.API
{
    public class CustomJsonSerializationPolicy : JsonNamingPolicy
    {
        public override string ConvertName(string name) => string.Concat(name[0].ToString().ToUpper(), name.AsSpan(1));
    }
}
