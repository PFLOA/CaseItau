using System.Runtime.Serialization;
using System;

namespace A4S.CaseItau.Core.Models
{
    public class Entity<TId>
    {
        public TId Id { get; set; }
        public Guid Guid { get; set; } = Guid.NewGuid();
        public DateTime DataCadastro { get; set; } = DateTime.Now;
    }
}
