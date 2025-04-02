namespace GuideAPI.Dto
{
    public class DefaultResponse
    {
        public int Id { get; set; }

        private bool _isErr;
        public bool isErr
        {
            get => _isErr;
            set
            {
                _isErr = value;
                responseCode = responseCode;
                responseMessage = responseCode == 500 ? "An error occurred" : responseMessage;
            }
        }

        public int responseCode { get; set; } = 200; // Default to 200
        public string responseMessage { get; set; } = ""; // Default to empty

        public DefaultResponse()
        {
            isErr = false;
        }
    }
}
