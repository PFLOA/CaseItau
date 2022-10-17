using A4S.CaseItau.Core.Interfaces.Results;
using System.Collections.Generic;
using A4S.CaseItau.Core.Enum;

namespace A4S.CaseItau.Core
{
    public class OperationResultInternalError<TResponse> : IOperationResult<TResponse>
    {
        public List<string> Messages { get; } = new List<string>();
        public EnumTypeResult ResultType { get; set; } = EnumTypeResult.InternalError;
        public TResponse Data { get; set; }

        public static IOperationResult<T> Create<T>() => new OperationResultInternalError<T>();

        public IOperationResultBase AddMessageBase(string message)
        {
            Messages.Add(message);
            return this;
        }

        public IOperationResult<TResponse> AddMessage(string message)
        {
            Messages.Add(message);
            return this;
        }
    }
}
