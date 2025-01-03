using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Helpers
{
    public class OperatingResult<TResult>
    {
        public int StatusCode { get; set; }
        public string ResultCode { get; set; }
        public string ResultMessage { get; set; }

        public Dictionary<string, string[]> Errors { get; set; } = new Dictionary<string, string[]>();

        public TResult? Result { get; private set; }

        public OperatingResult<TResult> OnSuccess(TResult result)
        {
            return new OperatingResult<TResult>
            {
                StatusCode = 0,
                ResultCode = "SCC",
                ResultMessage = "İşlem başarılı.",
                Result = result
            };
        }
        public OperatingResult<TResult> OnFailure(string resultCode, string resultMessage, TResult result)
        {
            return new OperatingResult<TResult>
            {
                StatusCode = 1,
                ResultCode = resultCode.ToString(),
                ResultMessage = resultMessage.ToString(),
                Result = result
            };
        }
    }
}
