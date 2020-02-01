using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using Domain.SharedKernel;

namespace TraningAppTests.DomainTests
{
    [TestFixture]
    class ValueObjectMock : ValueObject
    {
        ValueObjectMock valueObjectMock;

        [SetUp]
        public void SetUp()
        {
            valueObjectMock = new ValueObjectMock();
        }

        protected override IEnumerable<object> GetAtomicValues()
        {
            throw new NotImplementedException();
        }

        [Test]
        public void EqualOperatorIsTrueWhenInstancesAreNull()
        {
            ValueObjectMock a = null;
            ValueObjectMock b = null;

            bool result = EqualOperator(a, b);

            Assert.IsTrue(result);
        }

        [Test]
        public void EqualOperatorIsFalseWhenLeftInstanceIsNull()
        {
            ValueObjectMock obj1 = null;
            var obj2 = valueObjectMock;

            var result = EqualOperator(obj1, obj2);

            Assert.IsFalse(result);
        }

        [Test]
        public void EqualOperatorIsFalseWhenRightInstanceIsNull()
        {
            var a = valueObjectMock;
            ValueObjectMock b = null;

            var result = EqualOperator(a, b);

            Assert.IsFalse(result);
        }
    }
}
