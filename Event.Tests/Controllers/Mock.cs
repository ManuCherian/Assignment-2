using System;
using Event.Models;

namespace Event.Tests.Controllers
{
    internal class Mock<T>
    {
        public IDataEventDetails Object { get; internal set; }

        internal object Setup(Func<object, object> p)
        {
            throw new NotImplementedException();
        }
    }
}