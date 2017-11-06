using System.Collections.Generic;

namespace NumberCruncher
{
    public interface ICalculateServiceFactory
    {
        ICalculateService GetCalculateService(string name);
        List<string> ServiceKeys { get; }
    }
}
