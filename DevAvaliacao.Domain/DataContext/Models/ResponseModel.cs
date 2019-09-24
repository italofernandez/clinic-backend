using DevAvaliacao.Domain.DataContext.Enums;

namespace DevAvaliacao.Domain.DataContext.Models
{
    public class ResponseModel
    {
        public EResultStatus Status { get; set; }
        public string Message { get; set; }
        public string Location { get; set; }
        public string InnerException { get; set; }
        public object Data { get; set; }
        public int TotalRecords { get; set; }
        public object Notifications { get; set; }
    }
}
