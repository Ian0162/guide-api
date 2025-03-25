namespace GuideAPI.Exceptions
{
    public class InternalServerException : Exception
    {
        public int code { get; set; }
        public string message { get; set; }
        public string details { get; set; }

        public InternalServerException(string message, int code, string details) : base(message) { 
            this.code = code;  
            this.message = message;
            this.details = details;
        }
    }
}
