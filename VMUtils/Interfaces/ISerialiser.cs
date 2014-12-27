namespace VMUtils
{
    public interface ISerialiser<TInputObject>
    {
        string Serialise(TInputObject io);

        TInputObject DeSerialise(string ro);
    }
}
