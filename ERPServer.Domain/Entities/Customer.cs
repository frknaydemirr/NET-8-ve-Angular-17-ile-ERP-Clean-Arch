using ERPServer.Domain.Abstractions;
using System.Reflection.Metadata.Ecma335;

namespace ERPServer.Domain.Entities
{
    public sealed  class Customer : Entity
    {

        public string Name { get; set; } = string.Empty;
        public string TaxDepartment { get; set; } = string.Empty;
        public string TaxNumber { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string Town { get; set; } = string.Empty;

        public string FullAdress { get; set; } = string.Empty;
    }
}
