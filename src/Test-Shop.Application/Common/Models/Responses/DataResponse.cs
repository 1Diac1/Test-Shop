using System.Collections.Generic;

namespace Test_Shop.Application.Common.Models.Responses
{
    public class DataResponse<T> : BaseResponse
    {
        public T Data { get; set; }

        public DataResponse()
        {
        }

        public DataResponse(bool success)
            : base(success)
        {
        }

        public DataResponse(IEnumerable<string> errors)
            : base(errors)
        {
        }

        public DataResponse(T data)
        {
            this.Data = data;
            this.Success = true;
        }

        public DataResponse(string error)
            : base(error)
        {
        }
    }
}
