using System;

namespace DAPPER_CURD.Models
{
    public class ErrorViewModel
    {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
        public int Statuscode { get; set; }
        public string Msg { get; set; }
    }
}
