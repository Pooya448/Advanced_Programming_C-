using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SocketChatApp {
    [TestClass]
    public class AddTests{
        [TestMethod]
        public void AddtestMethod(){
            Assert.AreEqual(5, Program.Add(2, 3));
        }
    }
}