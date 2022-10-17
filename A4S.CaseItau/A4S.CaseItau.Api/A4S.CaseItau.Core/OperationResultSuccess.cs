using A4S.CaseItau.Core.Interfaces.Results;
using System.Collections.Generic;
using A4S.CaseItau.Core.Enum;
using System;

namespace A4S.CaseItau.Core
{
    public class OperationResultSuccess : IOperationResultBase
    {
        public List<string> Messages { get; } = new List<string>();
        public EnumTypeResult ResultType { get; set; }

        public OperationResultSuccess(EnumTypeResult result) => ResultType = result;
        public static IOperationResultBase Create(EnumTypeResult result) => new OperationResultSuccess(result);

        public IOperationResultBase AddMessageBase(string message)
        {
            Messages.Add(message);
            return this;
        }
    }
}
