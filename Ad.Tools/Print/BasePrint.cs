using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ad.Print
{
    public abstract class BasePrint
    {
        public bool isPrint = true;
        public BasePrint()
        {
           
        }

        /// <summary>
        /// 打印
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="ev"></param>
        public virtual void PrintPageDelegate(object sender, System.Drawing.Printing.PrintPageEventArgs ev)
        {
            this.DrawPage(ev.Graphics, isPrint);
        }

        /// <summary>
        /// 获取页面高度
        /// </summary>
        /// <param name="g"></param>
        /// <returns>返回毫米</returns>
        public virtual double GetHeight(Graphics g)
        {

            return this.DrawPage(g, false);
        }


        /// <summary>
        /// 画页面
        /// </summary>
        /// <param name="g">画图对象</param>
        /// <param name="isPrint">是否打印</param>
        /// <returns>页面高度(毫米)</returns>
        protected abstract double DrawPage(Graphics g, bool isPrint);

        protected abstract float GetWidthMaxPx();


        protected DrawHelper drawHelper { get; set; }



    }
}
