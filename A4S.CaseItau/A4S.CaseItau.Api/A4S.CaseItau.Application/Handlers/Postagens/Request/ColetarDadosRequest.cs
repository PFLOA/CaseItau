using A4S.CaseItau.Core.Interfaces.Results;
using System.Collections.Generic;
using MediatR;

namespace A4S.CaseItau.Application.Handlers.Postagens.Request
{
    public class ColetarDadosRequest : IRequest<IOperationResultBase>
    {
        public List<string> HashTags = new List<string>();

        public ColetarDadosRequest()
        {
            HashTags.Add("openbanking");
            HashTags.Add("remediation");
            HashTags.Add("devops");
            HashTags.Add("sre");
            HashTags.Add("microservices");
            HashTags.Add("observability");
            HashTags.Add("oauth");
            HashTags.Add("metrics");
            HashTags.Add("logmonitoring");
            HashTags.Add("opentracing");
        }
    }
}
