﻿using QualisysConfig;
using System;
using System.IO;
using System.Reflection;

namespace QualisysLog
{
    /// <summary>
    ///     Librería para registrar registros en el log de la aplicación
    /// </summary>
    /// <remarks>
    ///     Raul Anaya, 14/12/2017
    /// </remarks>
    public static class QsLog
    {
        private static bool mBolShowConsole = false;
        private static bool mBolFullLog = false;
        private static string mStrLogName = "log";

        static QsLog()
        {
            try
            {
                mBolShowConsole = QsConfig.GetValue<bool>("ShowConsole");
                mBolFullLog = QsConfig.GetValue<bool>("FullLog");
                mStrLogName = QsConfig.GetValue<string>("LogName");
            }
            catch
            {
                //Ignore exceptions
            }
        }

        /// <summary>
        ///     Propiedad que indica si se esta registrando un log detallado, esta propiedad se puede cambiar desde el App/Web.config
        /// </summary>
        public static bool FullLog
        {
            get { return mBolFullLog; }
        }

        /// <summary>
        ///     Propiedad que indica si se mostrara la consola por cada registro del log ingresado, esta propiedad se puede cambiar desde el App/Web.config
        /// </summary>
        public static bool ShowConsole
        {
            get { return mBolShowConsole; }
        }

        /// <summary>
        ///     Propiedad que indica el nombre del archivo del log, esta propiedad se puede cambiar desde el App/Web.config
        /// </summary>
        public static string LogName
        {
            get { return mStrLogName; }
        }

        /// <summary>
        ///     Método para registrar un texto libre directamente en el log.
        /// </summary>
        /// <param name="pStrFormat">
        ///     Formato del mensaje
        /// </param>
        /// <param name="pArrObjArgs">
        ///     Parámetros del formato del mensaje
        /// </param>
        /// <remarks>
        ///     Raul Anaya, 14/12/2017
        /// </remarks>
        public static void Write(string pStrFormat, params object[] pArrObjArgs)
        {
            Write(string.Format(pStrFormat, pArrObjArgs));
        }

        /// <summary>
        ///     Método para registrar un texto libre directamente en el log.
        /// </summary>
        /// <param name="pStrMessage">
        ///     Mensaje
        /// </param>
        /// <remarks>
        ///     Raul Anaya, 14/12/2017
        /// </remarks>
        public static void Write(string pStrMessage)
        {
            string lStrApplicationPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase).Replace("file:\\", "");
            string lStrLogPath = Path.Combine(lStrApplicationPath, string.Format("{0}.log", QsLog.LogName));
            string lStrDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss ");

            try
            {
                using (StreamWriter lObjWriter = new StreamWriter(lStrLogPath, true))
                {
                    lObjWriter.WriteLine(string.Concat(lStrDate, pStrMessage));
                }
            }
            catch
            {
                lStrLogPath = Path.Combine(lStrApplicationPath, string.Concat(DateTime.Now.ToString("yyyy-MM-dd-"), Guid.NewGuid().ToString(), ".log"));
                using (StreamWriter lObjWriter = new StreamWriter(lStrLogPath, true))
                {
                    lObjWriter.WriteLine(string.Concat(lStrDate, pStrMessage));
                }
            }
        }

        /// <summary>
        ///     Método para registrar información en el log.
        /// </summary>
        /// <param name="pStrMessage">
        ///     Mensaje
        /// </param>
        /// <remarks>
        ///     Raul Anaya, 14/12/2017
        /// </remarks>
        public static void WriteInfo(string pStrMessage)
        {
            Write("[INFO] {0}", pStrMessage);
            ConsoleWriteLine(pStrMessage, ConsoleColor.Gray);
        }

        /// <summary>
        ///     Método para registrar información en el log.
        /// </summary>
        /// <param name="pStrFormat">
        ///     Formato del mensaje
        /// </param>
        /// <param name="pArrObjArgs">
        ///     Parámetros del formato del mensaje
        /// </param>
        /// <remarks>
        ///     Raul Anaya, 14/12/2017
        /// </remarks>
        public static void WriteInfo(string pStrFormat, params object[] pArrObjArgs)
        {
            WriteInfo(string.Format(pStrFormat, pArrObjArgs));
        }

        /// <summary>
        ///     Método para registrar un evento exitoso, tal evento solo se registrara si  la propiedad del log 'FullLog' es 'true'.
        /// </summary>
        /// <param name="pStrMessage">
        ///     Mensaje
        /// </param>
        /// <remarks>
        ///     Raul Anaya, 14/12/2017
        /// </remarks>
        public static void WriteSuccess(string pStrMessage)
        {
            if (FullLog)
            {
                Write("[SUCCESS] {0}", pStrMessage);
                ConsoleWriteLine(pStrMessage, ConsoleColor.Green);
            }
        }

        /// <summary>
        ///     Método para registrar un evento exitoso, tal evento solo se registrara si  la propiedad del log 'FullLog' es 'true'.
        /// </summary>
        /// <param name="pStrFormat">
        ///     Formato del mensaje
        /// </param>
        /// <param name="pArrObjArgs">
        ///     Parámetros del formato del mensaje
        /// </param>
        /// <remarks>
        ///     Raul Anaya, 14/12/2017
        /// </remarks>
        public static void WriteSuccess(string pStrFormat, params object[] pArrObjArgs)
        {
            WriteSuccess(string.Format(pStrFormat, pArrObjArgs));
        }

        /// <summary>
        ///     Método para registrar el seguimiento de un evento, tal seguimiento solo se registrara si  la propiedad del log 'FullLog' es 'true'.
        /// </summary>
        /// <param name="pStrMessage">
        ///     Mensaje
        /// </param>
        /// <remarks>
        ///     Raul Anaya, 14/12/2017
        /// </remarks>
        public static void WriteTracking(string pStrMessage)
        {
            if (FullLog)
            {
                Write("[TRACK] {0}", pStrMessage);
                ConsoleWriteLine(pStrMessage, ConsoleColor.Gray);
            }
        }

        /// <summary>
        ///     Método para registrar el seguimiento de un evento, tal seguimiento solo se registrara si  la propiedad del log 'FullLog' es 'true'.
        /// </summary>
        /// <param name="pStrFormat">
        ///     Formato del mensaje
        /// </param>
        /// <param name="pArrObjArgs">
        ///     Parámetros del formato del mensaje
        /// </param>
        /// <remarks>
        ///     Raul Anaya, 14/12/2017
        /// </remarks>
        public static void WriteTracking(string pStrFormat, params object[] pArrObjArgs)
        {
            WriteTracking(string.Format(pStrFormat, pArrObjArgs));
        }

        /// <summary>
        ///     Método para registrar el evento de un proceso, tal evento solo se registrara si la propiedad del log 'FullLog' es 'true'.
        /// </summary>
        /// <param name="pStrMessage">
        ///     Mensaje
        /// </param>
        /// <remarks>
        ///     Raul Anaya, 14/12/2017
        /// </remarks>
        public static void WriteProcess(string pStrMessage)
        {
            if (FullLog)
            {
                Write("[PROCESS] {0}", pStrMessage);
                ConsoleWriteLine(pStrMessage, ConsoleColor.Yellow);
            }
        }

        /// <summary>
        ///     Método para registrar el evento de un proceso, tal evento solo se registrara si la propiedad del log 'FullLog' es 'true'.
        /// </summary>
        /// <param name="pStrFormat">
        ///     Formato del mensaje
        /// </param>
        /// <param name="pArrObjArgs">
        ///     Parámetros del formato del mensaje
        /// </param>
        /// <remarks>
        ///     Raul Anaya, 14/12/2017
        /// </remarks>
        public static void WriteProcess(string pStrFormat, params object[] pArrObjArgs)
        {
            WriteProcess(string.Format(pStrFormat, pArrObjArgs));
        }

        /// <summary>
        ///     Método para registrar una advertencia, tal advertencia solo se registrara si la propiedad del log 'FullLog' es 'true'.
        /// </summary>
        /// <param name="pStrMessage">
        ///     Mensaje
        /// </param>
        /// <remarks>
        ///     Raul Anaya, 14/12/2017
        /// </remarks>
        public static void WriteWarning(string pStrMessage)
        {
            if (FullLog)
            {
                Write(string.Format("[WARNING] {0}", pStrMessage));
                ConsoleWriteLine(pStrMessage, ConsoleColor.DarkYellow);
            }
        }

        /// <summary>
        ///     Método para registrar una advertencia, tal advertencia solo se registrara si la propiedad del log 'FullLog' es 'true'.
        /// </summary>
        /// <param name="pStrFormat">
        ///     Formato del mensaje
        /// </param>
        /// <param name="pArrObjArgs">
        ///     Parámetros del formato del mensaje
        /// </param>
        /// <remarks>
        ///     Raul Anaya, 14/12/2017
        /// </remarks>
        public static void WriteWarning(string pStrFormat, params object[] pArrObjArgs)
        {
            WriteWarning(string.Format(pStrFormat, pArrObjArgs));
        }

        /// <summary>
        ///     Método para registrar un error.
        /// </summary>
        /// <param name="pStrMessage">
        ///     Mensaje
        /// </param>
        /// <remarks>
        ///     Raul Anaya, 14/12/2017
        /// </remarks>
        public static void WriteError(string pStrMessage)
        {
            Write("[ERROR] {0}", pStrMessage);
            ConsoleWriteLine(pStrMessage, ConsoleColor.Red);
        }

        /// <summary>
        ///     Método para registrar un error.
        /// </summary>
        /// <param name="pStrFormat">
        ///     Formato del mensaje
        /// </param>
        /// <param name="pArrObjArgs">
        ///     Parámetros del formato del mensaje
        /// </param>
        /// <remarks>
        ///     Raul Anaya, 14/12/2017
        /// </remarks>
        public static void WriteError(string pStrFormat, params object[] pArrObjArgs)
        {
            WriteError(string.Format(pStrFormat, pArrObjArgs));
        }

        /// <summary>
        ///     Método para registrar una excepción.
        /// </summary>
        /// <param name="pObjException">
        ///     Excepción
        /// </param>
        /// <remarks>
        ///     Raul Anaya, 14/12/2017
        /// </remarks>
        public static void WriteException(Exception pObjException)
        {
            if (pObjException != null)
            {
                if (FullLog)
                {
                    Write("[ERROR] {0}", pObjException.ToString());
                }
                else
                {
                    Write("[ERROR] {0}", pObjException.Message);
                }
                ConsoleWriteLine(pObjException.ToString(), ConsoleColor.Red);
            }
        }

        private static void ConsoleWriteLine(string pStrFormat, ConsoleColor pEnmColor, object pObjArg)
        {
            ConsoleWriteLine(string.Format(pStrFormat, pObjArg), pEnmColor);
        }

        private static void ConsoleWriteLine(string pStrFormat, ConsoleColor pEnmColor, params object[] pArrObjArgs)
        {
            ConsoleWriteLine(string.Format(pStrFormat, pArrObjArgs), pEnmColor);
        }

        private static void ConsoleWriteLine(string pStrMessage, ConsoleColor pEnmColor)
        {
            if (ShowConsole)
            {
                Console.ForegroundColor = pEnmColor;
                Console.WriteLine(pStrMessage);
                Console.ForegroundColor = ConsoleColor.Gray;
            }
        }
    }
}