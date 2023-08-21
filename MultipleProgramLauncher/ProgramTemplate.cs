using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultipleProgramLauncher
{
    internal class ProgramTemplate
    {
        static void Main(string[] args)
        {
            string[] paths = new string[]
            {
                "program"
            };

            int[] delays = new int[]
            {
                //Replace this line with your actual program delays
                1000
                
            };

            bool[] isAdmin = new bool[]
            {
                false
            };


            // Loop through the arrays and launch programs with delays
            for (int i = 0; i < paths.Length; i++)
            {
                if (isAdmin[i])
                {
                    ProcessStartInfo startInfo = new ProcessStartInfo(paths[i]);
                    startInfo.UseShellExecute = true;
                    startInfo.Verb = "runas";
                    Process.Start(startInfo);
                }
                else
                {
                    Process.Start(paths[i]);
                }

                if (i < delays.Length)
                {
                    System.Threading.Thread.Sleep(delays[i]);
                }
            }
        }
    }
}
