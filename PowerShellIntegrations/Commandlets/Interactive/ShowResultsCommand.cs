﻿using System.Collections;
using System.Linq;
using System.Management.Automation;
using System.Text;
using Cognifide.PowerShell.PowerShellIntegrations.Commandlets.Interactive.Messages;
using Cognifide.PowerShell.PowerShellIntegrations.Host;
using Sitecore.Jobs.AsyncUI;
using Sitecore.Web;

namespace Cognifide.PowerShell.PowerShellIntegrations.Commandlets.Interactive
{
    [Cmdlet(VerbsCommon.Show, "Results")]
    public class ShowResultsCommand : BaseFormCommand
    {
        [Parameter(ParameterSetName = "Custom Viewer from Control Name", Mandatory = true)]
        public string Control { get; set; }

        [Parameter(ParameterSetName = "Custom Viewer from Url", Mandatory = true)]
        public string Url { get; set; }

        [Parameter(ParameterSetName = "Custom Viewer from Control Name")]
        public string[] Parameters { get; set; }

        [Parameter(ParameterSetName = "Text Results")]
        public SwitchParameter Text { get; set; }

        protected override void ProcessRecord()
        {
            LogErrors(() =>
                {
                    string response = null;

                    if (Text.IsPresent)
                    {
                        var rawHost = (Host.UI.RawUI as ScriptingHostRawUserInterface);
                        if (rawHost != null)
                        {
                            var output = new StringBuilder(10240);
                            foreach (OutputLine outputLine in rawHost.Output)
                            {
                                outputLine.GetHtmlLine(output);
                            }
                            var message = new ShowResultsMessage(output.ToString());
                            JobContext.MessageQueue.PutMessage(message);
                        }
                    } else if (Parameters != null)
                    {

                        var hashParams =
                            new Hashtable(Parameters.ToDictionary(p => p.ToString().Split('|')[0],
                                                                  p => WebUtil.SafeEncode(p.ToString().Split('|')[1])));
                        response = JobContext.ShowModalDialog(hashParams, Control, WidthString, HeightString);
                    }
                    else if (!string.IsNullOrEmpty(Url))
                    {
                        response = JobContext.ShowModalDialog(Url, WidthString, HeightString);
                    }
                    else if (!string.IsNullOrEmpty(Control))
                    {
                        response = JobContext.ShowModalDialog(Title ?? "Sitecore", Control, WidthString, HeightString);
                    }
                    WriteObject(response);
                });
        }
    }
}