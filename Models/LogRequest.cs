namespace
    ExtractCssValuesToJson.Models {
    public class LogRequest {
        public Guid Id { get; set; }
        public string IpClient { get; set; }
        public int FilesLengthRequest { get; set; }
        public string ConfigRequest { get; set; }
        public HttpResponseEnum HttpResponse { get; set; } = HttpResponseEnum.Success;
        public string ContentResponse { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
    }
}
