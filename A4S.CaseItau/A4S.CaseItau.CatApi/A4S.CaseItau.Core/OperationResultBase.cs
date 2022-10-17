using A4S.CaseItau.Core.Interfaces.Results;
using System.Collections.Generic;
using A4S.CaseItau.Core.Enum;

namespace A4S.CaseItau.Core
{
    public class OperationResultBase : IOperationResultBase
    {
        public List<string> Messages { get; }

        public EnumTypeResult ResultType { get; set; }

        public IOperationResultBase AddMessageBase(string message)
        {
            Messages.Add(message);
            return this;
        }
    }
}
