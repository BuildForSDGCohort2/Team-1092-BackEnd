using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace OlivetVehicleTracking.Handlers
{
    public class ErrorLog
    {
        private readonly ILogger _logger;

        public ErrorLog(ILogger<ErrorLog> logger)
        {
            _logger = logger;
        }

        public async static Task Log(string PageName,string FunctionName, string Message)
        {
            try
            {
                using (StreamWriter streamWriter = File.AppendText("ErrorLog.txt"))
                {
                    streamWriter.BaseStream.Seek((long)0, SeekOrigin.End);
                    await streamWriter.WriteLineAsync("\n**********************************************************************");
                    DateTime now = DateTime.Now;
                    await streamWriter.WriteLineAsync(string.Concat("Error Time    -------->   ", now.ToString()));
                    await streamWriter.WriteLineAsync(string.Concat("Page          -------->   ", PageName));
                    await streamWriter.WriteLineAsync(string.Concat("Function Name -------->   ", FunctionName));
                    await streamWriter.WriteLineAsync(string.Concat("Detail Error  -------->   ", Message));
                    await streamWriter.WriteLineAsync("**********************************************************************\n");
                    streamWriter.Close();
                }
            }
            catch (Exception ex)
            {
            }

        }

    }
}
