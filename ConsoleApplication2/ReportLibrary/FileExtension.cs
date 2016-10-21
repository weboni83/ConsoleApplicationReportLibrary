using System.ComponentModel;

namespace ReportLibrary
{
    public enum FileExtension
    {
        [Description("Report File Extension")]
        rpt,
        [Description("Schema File Extension")]
        xsd,
        [Description("Query File Extension")]
        sql,
    }
}
