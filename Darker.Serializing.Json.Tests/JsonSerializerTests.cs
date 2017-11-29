using System;
using NUnit.Framework;

namespace Darker.Serializing.Json.Tests
{
    [TestFixture]
    public class JsonSerializerTests
    {
        [SetUp]
        public void Setup()
        {
            _serializer = new JsonSerializer(readableFormatting:true);
        }

        private JsonSerializer _serializer;

        [Test]
        public void Serializing_empty_Does_Not_Throw()
        {
            Assert.DoesNotThrow(() => _serializer.Serialize(new object()));
        }


        [Test]
        public void Serializing_null_throws()
        {
            object o = null;
            Assert.Throws<ArgumentNullException>(() => _serializer.Serialize(o));
        }

        [Test]
        public void Serializing_primitive_Does_Not_Throw()
        {
            Assert.DoesNotThrow(() =>
                _serializer.Serialize("Hello World"));
            Assert.DoesNotThrow(() => _serializer.Serialize(5));
            Assert.DoesNotThrow(() => _serializer.Serialize(5f));
            Assert.DoesNotThrow(() => _serializer.Serialize(5d));
        }
    }
}