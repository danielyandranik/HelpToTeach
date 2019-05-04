﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Linq;

namespace HelpToTeach.Core.AI
{
    public static class PythonRunner
    {
        public static bool Run(string operationName, string optionalParameter)
        {
            var opScript = GetOperationScript(operationName);
            if (opScript == null) return false;

            ProcessStartInfo start = new ProcessStartInfo
            {
                FileName = "python",
                Arguments = $"{opScript.Script} {opScript.Mode} {opScript.GetUrl + optionalParameter} {opScript.PostUrl + optionalParameter}",
                UseShellExecute = false,// Do not use OS shell
                CreateNoWindow = true, // We don't need new window
                RedirectStandardOutput = true,// Any output, generated by application will be redirected back
                RedirectStandardError = true // Any error in standard output will be redirected back (for example exceptions)
            };
            using (Process process = Process.Start(start))
            {
                using (StreamReader reader = process.StandardOutput)
                {
                    string stderr = process.StandardError.ReadToEnd(); // Here are the exceptions from our Python script
                    string result = reader.ReadToEnd(); // Here is the result of StdOut(for example: print "test")
                    if (result != "0") return false;
                    return true;
                }
            }
        }

        private static OperationScript GetOperationScript(string operationName)
        {
            using (StreamReader r = new StreamReader(@"D:\HelpToTeach\HelpToTeach.Core\AI\mapper.json"))
            {
                string json = r.ReadToEnd();
                List<OperationScript> items = JsonConvert.DeserializeObject<List<OperationScript>>(json);
                return items.FirstOrDefault(o => o.Operation == operationName);
            }
        }
    }
}
