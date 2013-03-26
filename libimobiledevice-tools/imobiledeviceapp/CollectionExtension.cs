namespace iMobileDeviceApp
{
    using System;
    using System.Collections.Generic;

    public static class CollectionExtension
    {
        public static void Add(this ICollection<string> collection, string key, string value)
        {
            collection.Add(String.Format("{0} {1}", key, value));
        }
    }
}
