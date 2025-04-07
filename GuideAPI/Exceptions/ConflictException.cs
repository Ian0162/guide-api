namespace GuideAPI.Exceptions
{
    public class ConflictException : ApplicationException
    {
        public ConflictException(string name, object key) : base($"{name} with id ({key}) is Already Exist, Conflict Detected")
        {

        }
    }
}
