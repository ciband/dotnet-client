// Author:
//       Brian Faust <brian@ark.io>
//
// Copyright (c) 2018 Ark Ecosystem <info@ark.io>
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
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ArkEcosystem.Client.Tests.API.One
{
    using One = ArkEcosystem.Client.API.One.One;

    [TestClass]
    public class PeersTest
    {
        [TestMethod]
        public void All()
        {
            TestHelper.MockHttpRequestOne("peers");

            var response = TestHelper.MockConnection<One>().Api.Peers.All();

            TestHelper.AssertSuccessResponse(response);
        }

        [TestMethod]
        public async Task AllAsync()
        {
            TestHelper.MockHttpRequestOne("peers");

            var response = await TestHelper.MockConnection<One>().Api.Peers.AllAsync();

            TestHelper.AssertSuccessResponse(response);
        }

        [TestMethod]
        public void Show()
        {
            TestHelper.MockHttpRequestOne("peers/get");

            var response = TestHelper.MockConnection<One>().Api.Peers.Show("dummy", 1234);

            TestHelper.AssertSuccessResponse(response);
        }

        [TestMethod]
        public async Task ShowAsync()
        {
            TestHelper.MockHttpRequestOne("peers/get");

            var response = await TestHelper.MockConnection<One>().Api.Peers.ShowAsync("dummy", 1234);

            TestHelper.AssertSuccessResponse(response);
        }

        [TestMethod]
        public void Version()
        {
            TestHelper.MockHttpRequestOne("peers/version");

            var response = TestHelper.MockConnection<One>().Api.Peers.Version();

            TestHelper.AssertSuccessResponse(response);
        }

        [TestMethod]
        public async Task VersionAsync()
        {
            TestHelper.MockHttpRequestOne("peers/version");

            var response = await TestHelper.MockConnection<One>().Api.Peers.VersionAsync();

            TestHelper.AssertSuccessResponse(response);
        }
    }
}
