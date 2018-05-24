using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using QualisysLog;

namespace QualisysyLogTests
{
    [TestClass]
    public class QsLogTests
    {
        [TestMethod]
        [Microsoft.VisualStudio.TestTools.UnitTesting.Description("En caso de que no se encuentre la configuración 'ShowConsole', se utilizara como default el valor 'false'.")]
        public void ShowConsoleConfigNotFound()
        {
            // Arrange
            bool lBolExpectedValue = false;

            // Act
            var lUnkResult = QsLog.ShowConsole;

            // Assert
            Assert.AreEqual(lUnkResult, lBolExpectedValue);
        }

        [TestMethod]
        [Microsoft.VisualStudio.TestTools.UnitTesting.Description("En caso de que no se encuentre la configuración 'FullLog', se utilizara como default el valor 'false'.")]
        public void FullLogConfigNotFound()
        {
            // Arrange
            bool lBolExpectedValue = false;

            // Act
            var lUnkResult = QsLog.FullLog;

            // Assert
            Assert.AreEqual(lUnkResult, lBolExpectedValue);
        }

        [TestMethod]
        [Microsoft.VisualStudio.TestTools.UnitTesting.Description("En caso de que no se encuentre la configuración 'LogName', se utilizara como default el valor 'log'.")]
        public void LogNameConfigNotFound()
        {
            // Arrange
            string lStrExpectedValue = "log";

            // Act
            var lUnkResult = QsLog.LogName;

            // Assert
            Assert.AreEqual(lUnkResult, lStrExpectedValue);
        }

        [TestMethod]
        [Microsoft.VisualStudio.TestTools.UnitTesting.Description("En caso de que no se encuentre la configuración 'LogPath', se utilizara como default el valor 'Empty'.")]
        public void LogPathConfigNotFound()
        {
            // Arrange
            string lStrExpectedValue = "";

            // Act
            var lUnkResult = QsLog.LogPath;

            // Assert
            Assert.AreEqual(lUnkResult, lStrExpectedValue);
        }

        [TestMethod]
        public void Write()
        {
            QsLog.Write("Hello world!");
        }

        [TestMethod]
        public void WriteInfo()
        {
            QsLog.WriteInfo("Hello world!");
        }

        [TestMethod]
        public void WriteSuccess()
        {
            QsLog.WriteSuccess("Hello world!");
        }

        [TestMethod]
        public void WriteTracking()
        {
            QsLog.WriteTracking("Hello world!");
        }

        [TestMethod]
        public void WriteProcess()
        {
            QsLog.WriteProcess("Hello world!");
        }

        [TestMethod]
        public void WriteWarning()
        {
            QsLog.WriteWarning("Hello world!");
        }

        [TestMethod]
        public void WriteError()
        {
            QsLog.WriteError("Hello world!");
        }

        [TestMethod]
        public void WriteException()
        {
            QsLog.WriteException(new Exception("Exception: Hello world!"));
        }

        [TestMethod]
        public void WriteNull()
        {
            QsLog.Write(null);
        }

        [TestMethod]
        public void WriteNullException()
        {
            QsLog.WriteException(null);
        }
    }
}
