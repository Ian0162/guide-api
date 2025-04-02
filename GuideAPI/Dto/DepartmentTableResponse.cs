namespace GuideAPI.Dto
{
    public class DepartmentTableResponse <T>
    {
        //  total, data, page , start, end, totalPages, rowsPerPage
        // Pagination properties
        public IEnumerable<T> data { get; set; } = new List<T>();
        public int total { get; set; }
        public int page { get; set; }
        public int start { get; set; }
        public int end { get; set; }
        public int totalPages { get; set; }
        public int rowsPerPage { get; set; }

        // Response status
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

        public int responseCode { get; set; } = 200; // Default to 200
        public string responseMessage { get; set; } = ""; // Default to empty

        public DepartmentTableResponse()
        {
            isErr = false;
        }

    }
}
