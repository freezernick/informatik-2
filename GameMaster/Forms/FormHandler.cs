using Form = System.Windows.Forms.Form;

namespace GameMaster
{
    public class GameMasterForm : Form {}

    public static class FormHandler
    {
        private static MainForm _mainForm;
        private static EditorForm _editorForm;
        private static EditForm _editForm;
        private static DownloadForm _downloadForm;

        public static T Get<T>() where T : GameMasterForm, new()
        {
            if (new T() is MainForm)
            {
                if (_mainForm == null) { _mainForm = new MainForm(); }
                return (T)(object)_mainForm;
            }
            else if (new T() is EditorForm)
            {
                if (_editorForm == null) { _editorForm = new EditorForm(); }
                return (T)(object)_editorForm;
            }
            else if (new T() is EditForm)
            {
                if (_editForm == null) { _editForm = new EditForm(); }
                return (T)(object)_editForm;
            }
            else if (new T() is DownloadForm)
            {
                if (_downloadForm == null) { _downloadForm = new DownloadForm(); }
                return (T)(object)_downloadForm;
            }
            else
            {
                return null;
            }
        }
    }
}