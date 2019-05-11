using System;
using System.Collections;
using System.Collections.Generic;

namespace MiniAspNet.V2_1
{
    public interface IFeatureCollection : IDictionary<Type, object>
    {
    }

    public class FeatureCollection : Dictionary<Type, object>, IFeatureCollection
    {
    }
}