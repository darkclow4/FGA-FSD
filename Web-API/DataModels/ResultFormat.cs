namespace Web_API.DataModels
{
    public class ResultFormat<T>
    {
        public int StatusCode { get; set; }
        public string Status { get; set; }
        public string Message { get; set; }
        public IEnumerable<T> Data { get; set; } = new List<T>();

    }
}
