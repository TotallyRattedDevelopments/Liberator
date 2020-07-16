// EnumElementRelationships.cs
//
// Author:
//       kevmccarthy <developments@totallyratted.com>
//
// Copyright (c) 2020 Liberator Test Tools
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.
using System;

namespace Liberator.Driver.Enums
{
    /// <summary>
    /// Enumeration for the relationships between elements
    /// </summary>
    public enum EnumElementRelationships
    {
        /// <summary>
        /// No response was returned
        /// </summary>
        NoResponse = 0,

        /// <summary>
        /// There is no relationship between the nodes
        /// </summary>
        NoRelationship = 1,

        /// <summary>
        /// The first node is found to be after the second node
        /// </summary>
        FirstAfterSecond = 2,

        /// <summary>
        /// The second node is found to be after the first node
        /// </summary>
        FirstBeforeSecond = 4,

        /// <summary>
        /// The first node is found to be inside the second node
        /// </summary>
        FirstInsideSecond = 8,

        /// <summary>
        /// The first node is found to be outside the second node
        /// </summary>
        FirstOutsideSecond = 16,

        /// <summary>
        /// The status if the relationship is unknown
        /// </summary>
        Unknown = 32
    }
}
