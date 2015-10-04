using System;
using System.Collections.Generic;

namespace BBCodesExtended.Generators
{
    /// <summary>
    /// Description of IGenerator.
    /// </summary>
    public interface IGenerator
    {
        string Generate(List<Nodes.Node> nodes);
    }
}
