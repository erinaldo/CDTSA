using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.IO;
using Security;
using ControlBancario.DAC;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraReports.UI;
using DevExpress.LookAndFeel;
using DevExpress.XtraReports.UserDesigner;

namespace ControlBancario
{
    public class SaveCommandHandler : DevExpress.XtraReports.UserDesigner.ICommandHandler
    {
        XRDesignPanel panel;

        public SaveCommandHandler(XRDesignPanel panel)
        {
            this.panel = panel;
        }

        public void HandleCommand(DevExpress.XtraReports.UserDesigner.ReportCommand command,
        object[] args)
        {
            // Save the report.
            Save();
        }

        public bool CanHandleCommand(DevExpress.XtraReports.UserDesigner.ReportCommand command,
        ref bool useNextHandler)
        {
            useNextHandler = !(command == ReportCommand.SaveFile ||
                command == ReportCommand.SaveFileAs);
            return !useNextHandler;
        }

        void Save()
        {
            // Write your custom saving here.
            // ...

            // For instance:
            panel.Report.SaveLayout("c:\\report1.repx");

            // Prevent the "Report has been changed" dialog from being shown.
            panel.ReportState = ReportState.Saved;
        }
    }
}
