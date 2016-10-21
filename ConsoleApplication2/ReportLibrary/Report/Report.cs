using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportLibrary.Report
{
    public abstract class Report
    {
        public abstract void Load();
        public abstract void SetDataSource();
    }
}
