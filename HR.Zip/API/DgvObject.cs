using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HR.Zip.API
{
    class DgvObject<T>
        where T : Form
    {
        public DgvObject(T tform, DataGridView dgv, Control cl, string xlsType, string filenamePrefix, string filepath, bool autoOpen)
        {
            _dgv = dgv;
            _cl = cl;
            _tform = tform;
            _xlsType = xlsType;
            _filenamePrefix = filenamePrefix;
            _filepath = filepath;
            _autoOpen = autoOpen;


        }

        public DataGridView _dgv { get; set; }

        public string _xlsType { get; set; }

        public string _filenamePrefix { get; set; }

        public string _filepath { get; set; }

        public bool _autoOpen { get; set; }

        public Control _cl { get; set; }

        public T _tform { get; set; }
    }
}
