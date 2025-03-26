namespace GuideAPI.Dto
{
    public class CreateUpdateResponse
    {
        public int Id { get; set; }

        private bool _isErr;
        public bool isErr
        {
            get => _isErr;
            set
            {
                _isErr = value;
                responseCode = value ? 500 : 200;
                responseMessage = value ? "An error occurred" : "";
            }
        }

        public int responseCode { get; private set; } = 200; // Default to 200
        public string responseMessage { get; private set; } = ""; // Default to empty

        public CreateUpdateResponse()
        {
            isErr = false;
        }
    }
}
