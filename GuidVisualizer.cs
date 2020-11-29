using Microsoft.VisualStudio.DebuggerVisualizers; // Need to import Microsoft.VisualStudio.DebuggerVisualizers assembly.
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

[assembly: System.Diagnostics.DebuggerVisualizer(
typeof(GuidVisualizer.GuidVisualizer),
typeof(VisualizerObjectSource),
Target = typeof(Guid), // Tells VS which type to add to visualizer to.
Description = "Guid Visualizer")]
namespace GuidVisualizer
{
    public class GuidVisualizer : DialogDebuggerVisualizer
    {
        private readonly Dictionary<Guid, string> NameByGuid = new Dictionary<Guid, string>();

        public GuidVisualizer()
        {
            // Add Guid to Name (string) mapping here. Can retrieve the data from a DB, CSV file, etc.
            // Note: ensure duplicate keys aren't inserted into Dictionary, otherwise an exception will be thrown.
            NameByGuid = new Dictionary<Guid, string>
            {
                // Example in-memory data.
                {new Guid("{DBC4A89B-FB5A-4616-9DC3-211259C8F1F4}"), "Admin user"},
                {new Guid("{A1F9EA23-3A8D-4239-9DEB-A161941F0A83}"), "Local user"}
            };
        }

        // Method called by VS when the visualizer is opened.
        override protected void Show(IDialogVisualizerService windowService, IVisualizerObjectProvider objectProvider)
        {
            Guid guid = (Guid)objectProvider.GetObject();

            var form = new Form
            {
                Text = "Guid Visualizer",
                AutoScaleDimensions = new SizeF(6F, 13F),
                AutoScaleMode = AutoScaleMode.Font,
                ClientSize = new Size(500, 235),
                FormBorderStyle = FormBorderStyle.FixedToolWindow,
                TopMost = true
            };

            // 
            // guidLabel
            // 
            var guidLabel = new Label
            {
                AutoSize = false,
                Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0))),
                Location = new Point(24, 18),
                Name = "guidLabel",
                Size = new Size(55, 24),
                Text = "Guid:"
            };
            // 
            // nameLabel
            // 
            var nameLabel = new Label
            {
                AutoSize = false,
                Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0))),
                Location = new Point(24, 61),
                Name = "nameLabel",
                Size = new Size(66, 24),
                Text = "Name:"
            };
            // 
            // guidValueLabel
            // 
            var guidValueLabel = new Label
            {
                AutoSize = false,
                Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0))),
                Location = new Point(96, 18),
                Name = "guidValueLabel",
                Size = new Size(373, 24),
                Text = guid.ToString().ToUpper()
            };
            // 
            // nameValueLabel
            //
            var nameValueLabel = new Label
            {
                AutoSize = false,
                Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0))),
                Location = new Point(96, 61),
                Name = "nameValueLabel",
                Size = new Size(373, 24),
                Text = GetNameFromGuid(guid) ?? "Could not find associated name to GUID"
            };
            // 
            // infoLabel
            // 
            var infoLabel = new Label
            {
                AutoSize = false,
                Location = new Point(25, 125),
                Name = "infoLabel",
                Size = new Size(300, 65),
                Text = $"{NameByGuid.Count} Guids loaded\n"
            };

            // Add Controls
            form.Controls.Add(nameValueLabel);
            form.Controls.Add(infoLabel);
            form.Controls.Add(guidValueLabel);
            form.Controls.Add(nameLabel);
            form.Controls.Add(guidLabel);

            // Show form
            windowService.ShowDialog(form);
        }

        private string GetNameFromGuid(Guid key)
        {
            if (NameByGuid.TryGetValue(key, out var value))
                return value;

            return null;
        }
    }
}