using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace SampleDemo
{
    public partial class Service1 : ServiceBase
    {
        public Service1()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            Log("OnStart");
        }

        protected override void OnStop()
        {
            Log("OnStop");
        }

        private List<string> Log(string data)
        {
            List<string> lines = new List<string>();
            try
            {
                lines.AddRange(
                new[] {
                        data,
                        "In log test for continuous integration of 5 minutes."
                });

                File.AppendAllLines("c:\\SampleDemo.log.txt", lines);
            }
            catch (Exception ex)
            {
                lines.AddRange(
                    new[] {
                        "Exception:",
                        ex.Message,
                        ex.StackTrace
                    });
            }

            return lines;
        }
    }
}
