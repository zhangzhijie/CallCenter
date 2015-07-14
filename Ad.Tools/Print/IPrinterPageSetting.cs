using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ad.Print
{
    /// <summary>
    /// PrintDocument.PrintPage的委托定义
    /// </summary>
    public delegate void PrintPageDelegate(Object sender, PrintPageEventArgs ev);

    /// <summary>
    /// IPrinterPageSetting 的接口，显示打印纸张设置、打印机设置、打印预览对话框。
    /// </summary>
    public interface IPrinterPageSetting
    {

        /// <summary>
        /// 显示页面设置对话框，并返回PageSettings
        /// </summary>
        /// <returns></returns>
        PageSettings ShowPageSetupDialog();

        /// <summary>
        /// 显示打印机设置对话框，并返回PrinterSettings
        /// </summary>
        /// <returns></returns>
        PrinterSettings ShowPrintSetupDialog();

        /// <summary>
        /// 显示打印预览对话框
        /// </summary>
        void ShowPrintPreviewDialog();

        /// <summary>
        /// 获取或设置打印文档
        /// </summary>
        System.Drawing.Printing.PrintDocument PrintDocument
        {
            get;
            set;
        }

        /// <summary>
        /// 关联一个方法，目的是让具体的打印由实例化者来操作
        /// 如PrinterPageSetting1.PrintPage += new PrintPageDelegate(this.PrintPageEventHandler);
        /// </summary>
        PrintPageDelegate PrintPage
        {
            get;
            set;
        }
    }
}
