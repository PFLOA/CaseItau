using A4S.CaseItau.Core.Interfaces.Results;
using System.Collections.Generic;
using A4S.CaseItau.Core.Enum;

namespace A4S.CaseItau.Core
{
    public class OperationResult<TResult> : IOperationResult<TResult>
    {
        public TResult Data { get; set; }

        public List<string> Messages { get; } = new List<string>();

        public EnumTypeResult ResultType { get; set; } = EnumTypeResult.InternalError;

        public static OperationResult<TResult> Create(EnumTypeResult result, TResult data)
        {
            return new OperationResult<TResult>(data, result);
        }
        public static OperationResult<TResult> Create(EnumTypeResult result)
        {
            return new OperationResult<TResult>(result);
        }

        public OperationResult(TResult data, EnumTypeResult result)
        {
            Data = data;
            ResultType = result;
        }

        public OperationResult(EnumTypeResult result)
        {
            ResultType = result;
        }

        public IOperationResult<TResult> AddMessage(string message)
        {
            Messages.Add(message);
            return this;
        }

        public IOperationResultBase AddMessageBase(string message)
        {
            Messages.Add(message);
            return this;
        }
    }
}
