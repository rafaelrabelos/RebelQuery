using ClosedXML.Excel;

namespace RebelQuery.Core.Interfaces
{
    interface IExtension
    {
        IXLWorkbook ToExcell();
    }
}
