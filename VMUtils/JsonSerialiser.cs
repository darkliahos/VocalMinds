using Newtonsoft.Json;

namespace VMUtils
{
    public class JsonSerialiser<TInputObject> : ISerialiser<TInputObject>
    {

        public string Serialise(TInputObject io)
        {
            return JsonConvert.SerializeObject(io);
        }

        public TInputObject DeSerialise(string ro)
        {
            return JsonConvert.DeserializeObject<TInputObject>(ro);
        }
    }
}