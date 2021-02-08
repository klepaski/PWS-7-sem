using System.Collections.Generic;

namespace Lab8.Models
{
    public class DataModel
    {
        public string Key { get; set; }
        public string Value { get; set; }
    }
    public class ErrorJsonRPC
    {
        public int Code { get; set; }
        public string Message { get; set; }
        public string Data { get; set; }
    }

    //{"jsonrpc": "2.0", "method": "post.like", "params": {"post": "12345"}, "id": 1}
    public class ReqJsonRPC
    {
        public string Id { get; set; }
        public string Method { get; set; }
        public DataModel Params { get; set; }
    }

    //{"jsonrpc": "2.0", "result": {"likes": 123}, "id": 1}
    public class ResJsonRPC
    {
        public string Id { get; set; }
        public string Method { get; set; }
        public int? Result { get; set; }
    }

    //{"jsonrpc": "2.0", "error": {"code": 666, "message": "not found"}, "id": "1"}
    public class ResJsonRPCError
    {
        public string Id { get; set; }
        public ErrorJsonRPC Error { get; set; }
    }
}