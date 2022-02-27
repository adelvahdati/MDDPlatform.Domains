namespace MDDPlatform.Domains.Core.Entities
{
    internal class DomainNameNullException : Exception
    {
        public DomainNameNullException(string? message) : base(message)
        {
        }
    }
}