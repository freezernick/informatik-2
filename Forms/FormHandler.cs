using Form = System.Windows.Forms.Form;

namespace GameMaster
{
    public static class FormHandler
    {
        private static MainForm _mainForm;
        private static ObjectListForm _objectListForm;
        private static EditorForm _editorForm;
        private static EditForm _editForm;
        private static DownloadForm _downloadForm;

        public static MainForm MainForm()
        {
            if (_mainForm == null) { _mainForm = new MainForm(); }
            return _mainForm;
        }

        public static ObjectListForm ObjectListForm()
        {
            if (_objectListForm == null) { _objectListForm = new ObjectListForm(); }
            return _objectListForm;
        }

        public static EditorForm EditorForm()
        {
            if (_editorForm == null) { _editorForm = new EditorForm(); }
            return _editorForm;
        }

        public static EditForm EditForm()
        {
            if (_editForm == null) { _editForm = new EditForm(); }
            return _editForm;
        }

        public static DownloadForm DownloadForm()
        {
            if (_downloadForm == null) { _downloadForm = new DownloadForm(); }
            return _downloadForm;
        }
    }
}