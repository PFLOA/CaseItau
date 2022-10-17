using System.ComponentModel;

namespace A4S.CaseItau.Core.Enum
{
    public enum EnumTypeResult
    {
        [Description("OK")]
        Ok = 200,

        [Description("Criado")]
        Created = 201,

        [Description("Aceito")]
        Accepted = 202,

        [Description("Entrada Inválida")]
        InvalidInput = 400,

        [Description("Não Encontrado")]
        NotFound = 404,

        [Description("Proibido")]
        Forbidden = 403,

        [Description("Erro Interno")]
        InternalError = 500,

        [Description("Serviço Indisponível")]
        ServiceUnavaliable = 503
    }
}
