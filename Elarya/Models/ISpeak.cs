using System.Collections.Generic;

namespace Elarya.Models
{
    internal interface ISpeak
    {
        List<string> Messages { get; set; }

        string Speak();
    }
}
