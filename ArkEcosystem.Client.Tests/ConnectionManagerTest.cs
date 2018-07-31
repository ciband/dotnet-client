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

namespace ArkEcosystem.Client.Tests
{
    [TestClass]
    public class ConnectionManagerTest
    {
        private readonly string _testHostName = "https://10.0.0.0/";
        
        [TestMethod]
        public void Connect()
        {
            var cm = new Client.ConnectionManager();
            var req = TestHelper.MockHttpRequestTwo("peers"); // dummy request
            var conn = cm.Connect(TestHelper.MockConnection<Client.API.Two.Two>());
            //Assert.AreEqual(conn, cm.Connection<Client.API.Two.Two>());
            Assert.AreEqual(1, cm.GetConnections().Count);
        }
        
        [TestMethod]
        public void Disconnect()
        {
            var cm = new Client.ConnectionManager();
            var req = TestHelper.MockHttpRequestTwo("peers"); // dummy request
            cm.Connect(TestHelper.MockConnection<Client.API.Two.Two>(), "test");
            Assert.AreEqual(1, cm.GetConnections().Count);
            cm.Disconnect("test");
            Assert.AreEqual(0, cm.GetConnections().Count);
        }
        
        [TestMethod]
        public void Connection()
        {
            var cm = new Client.ConnectionManager();
            var req = TestHelper.MockHttpRequestTwo("peers"); // dummy request
            var conn = cm.Connect(TestHelper.MockConnection<Client.API.Two.Two>(), "test");
            //Assert.AreEqual(conn, cm.Connection<Client.API.Two.Two>("test"));
            Assert.AreEqual(1, cm.GetConnections().Count);
        }
        
        [TestMethod]
        public void GetDefaultConnection()
        {
            var cm = new Client.ConnectionManager();
            Assert.AreEqual("main", cm.GetDefaultConnection());
        }
        
        [TestMethod]
        public void SetDefaultConnection()
        {
            var cm = new Client.ConnectionManager();
            cm.SetDefaultConnection("test");
            Assert.AreEqual("test", cm.GetDefaultConnection());
        }
        
        [TestMethod]
        public void GetConnections()
        {
            var cm = new Client.ConnectionManager();
            var req1 = TestHelper.MockHttpRequestOne("peers"); // dummy request
            var conn1 = cm.Connect(TestHelper.MockConnection<Client.API.One.One>(), "test1");
            var req2 = TestHelper.MockHttpRequestTwo("peers"); // dummy request
            var conn2 = cm.Connect(TestHelper.MockConnection<Client.API.Two.Two>(), "test2");
            var dict = cm.GetConnections();
            Assert.AreEqual(2, dict.Count);
            //Assert.IsNotNull(dict["test1"]);
            //Assert.IsNotNull(dict["test2"]);
        }
    }
}
