using System.Collections.Generic;
using A4S.CaseItau.Core.Enum;

namespace A4S.CaseItau.Core.Interfaces.Results
{
    public interface IOperationResultBase
    {
        List<string> Messages { get; }
        EnumTypeResult ResultType { get; set; }

        IOperationResultBase AddMessageBase(string message);
    }
    public interface IOperationResult<T> : IOperationResultBase
    {
        T Data { get; set; }

        IOperationResult<T> AddMessage(string message);
    }
}
