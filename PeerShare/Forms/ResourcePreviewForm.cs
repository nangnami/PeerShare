using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Microsoft.Web.WebView2.WinForms;

namespace PeerShare
{
    public class ResourcePreviewForm : Form
    {
        private readonly WebView2 viewer;
        private readonly string folder;
        private readonly string pdfPath;

        public ResourcePreviewForm(string fileName, byte[] bytes)
        {
            Text = "Preview - " + Path.GetFileName(fileName);
            StartPosition = FormStartPosition.CenterParent;
            Size = new Size(900, 700);
            MinimumSize = new Size(500, 400);
            BackColor = Color.FromArgb(255, 249, 240);
            folder = Path.Combine(Path.GetTempPath(), "PeerShare-" + Guid.NewGuid().ToString("N"));
            pdfPath = Path.Combine(folder, "preview.pdf");
            viewer = new WebView2 { Dock = DockStyle.Fill };
            Controls.Add(viewer);
            try
            {
                Directory.CreateDirectory(folder);
                string extension = Path.GetExtension(fileName).ToLowerInvariant();
                if (extension == ".pdf")
                {
                    File.WriteAllBytes(pdfPath, bytes);
                }
                else if (extension == ".doc" || extension == ".docx" ||
                         extension == ".ppt" || extension == ".pptx")
                {
                    string inputPath = Path.Combine(folder, "source" + extension);
                    File.WriteAllBytes(inputPath, bytes);
                    if (extension == ".doc" || extension == ".docx")
                    {
                        using (var document = new Spire.Doc.Document())
                        {
                            document.LoadFromFile(inputPath);
                            document.SaveToFile(pdfPath, Spire.Doc.FileFormat.PDF);
                        }
                    }
                    else
                    {
                        using (var presentation = new Spire.Presentation.Presentation())
                        {
                            presentation.LoadFromFile(inputPath);
                            presentation.SaveToFile(pdfPath, Spire.Presentation.FileFormat.PDF);
                        }
                    }
                }
                else
                {
                    throw new NotSupportedException("This file format is not supported for preview.");
                }
            }
            catch
            {
                Dispose();
                throw;
            }
            Shown += PreviewShown;
        }

        private async void PreviewShown(object sender, EventArgs e)
        {
            try
            {
                await viewer.EnsureCoreWebView2Async();
                if (IsDisposed || Disposing) return;
                viewer.CoreWebView2.Settings.IsScriptEnabled = false;
                viewer.CoreWebView2.Settings.AreDevToolsEnabled = false;
                viewer.CoreWebView2.Settings.AreDefaultContextMenusEnabled = false;
                string uri = new Uri(pdfPath).AbsoluteUri;
                viewer.CoreWebView2.NavigationStarting += (s, args) =>
                {
                    if (!string.Equals(args.Uri, uri, StringComparison.OrdinalIgnoreCase))
                        args.Cancel = true;
                };
                viewer.CoreWebView2.NewWindowRequested += (s, args) => args.Handled = true;
                viewer.CoreWebView2.DownloadStarting += (s, args) => args.Cancel = true;
                viewer.Source = new Uri(pdfPath);
            }
            catch (Exception ex)
            {
                if (IsDisposed || Disposing) return;
                MessageBox.Show(this, "Unable to open PDF preview. Check that WebView2 Runtime is installed.\n\n" + ex.Message,
                    "Preview Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && viewer != null) viewer.Dispose();
            base.Dispose(disposing);
            if (disposing && folder != null)
            {
                try { if (Directory.Exists(folder)) Directory.Delete(folder, true); }
                catch (IOException) { }
                catch (UnauthorizedAccessException) { }
            }
        }
    }
}