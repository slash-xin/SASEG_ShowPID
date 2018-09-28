using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using SAS.Tasks.Toolkit;
using SAS.Shared.AddIns;
using System.Windows.Forms;

namespace ShowPID
{
    [ClassId("6F1D3C3C-8E95-47BD-9EEA-0B36DAFC2E26")]
    [Version(6.1)]
    [InputRequired(InputResourceType.None)]
    [IconLocation("ShowPID.App.ico")]
    public class BasicStatus : SasTask
    {
        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        public static extern bool SetWindowText(IntPtr hwnd, string lpString);

        static string EGTitle = "SAS Enterprise Guide";
        static string WorkspaceID = string.Empty;
        static bool flag = true;

        private void InitializeComponent()
        {
            // 
            // BasicStatus
            // 
            this.GeneratesReportOutput = false;
            this.GeneratesSasCode = false;
            this.RequiresData = false;
            this.TaskCategory = "SASTasks";
            this.TaskDescription = "Display the PID of current EG process and background SAS process.";
            this.TaskName = "Show PID";

        }

        public BasicStatus()
        {
            InitializeComponent();
        }

        public override ShowResult Show(IWin32Window Owner)
        {            
            try
            {
                if(flag)
                {
                    EGTitle = System.Diagnostics.Process.GetCurrentProcess().MainWindowTitle;
                    flag = false;
                }

                IntPtr hwnd = System.Diagnostics.Process.GetCurrentProcess().MainWindowHandle;
                SasServer server = new SasServer(Consumer.AssignedServer);
                if (null != hwnd && WorkspaceID!=server.GetWorkspaceIdentifier())
                {
                    string sas_pid = server.GetSasMacroValue("SYSJOBID");

                    string title = string.Format("{0} (EG_PID={1}; SAS_PID={2})", EGTitle,
                        System.Diagnostics.Process.GetCurrentProcess().Id, sas_pid);

                    SetWindowText(hwnd, title);

                    WorkspaceID = server.GetWorkspaceIdentifier();
                }
            }
            catch { };

            return ShowResult.Canceled;
        }
    }
}
