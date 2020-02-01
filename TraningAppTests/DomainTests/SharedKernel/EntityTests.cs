using NUnit.Framework;
using System;
using System.Collections.Generic;
using Domain.SharedKernel;

namespace TraningAppTests.DomainTests
{
    public class EntityMock : Entity
    {
        internal object actual;

        public EntityMock() : base()
        {
            actual = Actual;
        }

        public EntityMock(Guid id)
        {
            base.Id = id;
        }
    }

    public class EntityMockAdditional : Entity
    {

    }

    [TestFixture]
    class EntityTests
    {
        EntityMock entityMock;

        [SetUp]
        public void SetUp()
        {
            entityMock = new EntityMock();
        }

        [Test]
        public void EqualsIsFalseIfInstanceIsNull()
        {
            var result = entityMock.Equals(null);
            Assert.IsFalse(result);
        }

        [Test]
        public void EqualsIsTrueIfReferenceIsTrue()
        {
            var obj = entityMock;
            var result = entityMock.Equals(obj);
            Assert.IsTrue(result);
        }

        [Test]
        public void EqualsIsFalseIfTypesAreDifferent()
        {
            var obj = new EntityMockAdditional();
            var result = entityMock.Equals(obj);
            Assert.IsFalse(result);
        }

        [Test]
        public void EqualsIsTrueIfIDsAreEquals()
        {
            var id = Guid.NewGuid();
            var obj1 = new EntityMock(id);
            var obj2 = new EntityMock(id);

            var result = obj1.Equals(obj2);
            Assert.IsTrue(result);
        }
        //If gdzie Id = null jest nie do przetestowania dlatego ze GUID nie jest NullAble !! 

        [Test]
        public void EntitiesAreEqualIfBothExists()
        {
            var obj1 = new EntityMock();
            var obj2 = obj1;

            bool result = (obj1 == obj2);

            Assert.IsTrue(result);
        }

        [Test]
        public void EntitiesAreEqualIfBothNull()
        {
            EntityMock a = null;
            EntityMock b = null;

            bool result = (a == b);

            Assert.IsTrue(result);
        }

        [Test]
        public void EntitiesAreNotEqualIfFirstObjectIsNull()
        {
            EntityMock a = null;
            EntityMock b = new EntityMock();

            bool result = (a == b);

            Assert.IsFalse(result);
        }

        [Test]
        public void EntitiesAreNotEqualIfSecondObjectIsNull()
        {
            EntityMock a = new EntityMock();
            EntityMock b = null;

            bool result = (a == b);

            Assert.IsFalse(result);
        }

        [Test]
        public void EntitiesAreNotTheSameIfBothAreDifferent()
        {
            EntityMock a = new EntityMock();
            EntityMock b = new EntityMock();

            bool result = (a != b);

            Assert.IsTrue(result);
        }

        //Niepotrzebny test wg. mnie, ale na wszelki wypadek jest
        [Test]
        public void GetHashCodeIsCorrectWhenReturnTheChain()
        {
            var expected = (entityMock.actual.GetType().ToString() + entityMock.Id).GetHashCode();
            var result = entityMock.GetHashCode();

            Assert.AreEqual(result, expected);
        }
    }

}
