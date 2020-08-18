using System;
using System.Collections.Generic;
using FizzWare.NBuilder;
using OpenRealEstate.Core.Extensions;
using Shouldly;

namespace OpenRealEstate.Core.Tests.ExtensionTests
{
    public abstract class BaseSideTests
    {
        private const string Type = "m";
        private const int Value = 10;

        protected static IList<Side> _sides(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException($"'{nameof(name)}' cannot be null or whitespace", nameof(name));
            }

            return Builder<Side>.CreateListOfSize(10)
                .TheFirst(1)
                .With(side => side.Name = name)
                .And(side => side.Type = Type)
                .And(side => side.Value = 10)
                .TheRest()
                .Build();
        }

        protected void GivenAValidName_Side_ReturnsAUnitOfMeasure(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException($"'{nameof(name)}' cannot be null or whitespace", nameof(name));
            }

            // Arrange & Act.
            var sides = _sides(name);
            var side = GetASide(name, sides);

            // Assert.
            side.Name.ShouldBe(name);
            side.Type.ShouldBe(Type);
            side.Value.ShouldBe(Value);
        }

        protected void GivenAnInvalidName_Frontage_ReturnsNull(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException($"'{nameof(name)}' cannot be null or whitespace", nameof(name));
            }

            // Arrange.
            var sides = _sides(name);
            sides.RemoveAt(0); // Removes side.

            // Act.
            var side = GetASide(name, sides);

            // Assert.
            side.ShouldBeNull();
        }

        private static Side GetASide(string name, IList<Side> sides)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException($"'{nameof(name)}' cannot be null or whitespace", nameof(name));
            }

            if (sides is null)
            {
                throw new ArgumentNullException(nameof(sides));
            }

            Side side;
            switch (name)
            {
                case "frontage":
                    side = sides.Frontage();
                    break;
                case "right":
                    side = sides.Right();
                    break;
                case "left":
                    side = sides.Left();
                    break;
                case "rear":
                    side = sides.Rear();
                    break;
                default:
                    throw new InvalidOperationException();
            }

            return side;
        }
    }
}
