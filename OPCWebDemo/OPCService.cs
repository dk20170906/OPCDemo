using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace OPCWebDemo
{
    public class OPCService
    {
        /// <summary>
        /// 与组态王建立连接
        /// 每次应用程序启动时，必须用该函数与组态王建立连接
        /// </summary>
        /// <param name="node">node为节点(IP)，如果是本机，其值为空</param>
        /// <returns>返回错误码，见附录。</returns>
        [DllImport("kingvewcliend.dll")]
        public static extern int StartCliend(string node);

        /// <summary> 
        /// 得到组态王SDK中列出的项目（包括变量及其域）总数 
        /// </summary> 
        [DllImport("kingvewcliend.dll")]
        public static extern int ReadItemNo();

        /// <summary> 
        /// 得到某个项目的名称 
        /// <param name="sName">将返回组态王的项目的名称</param> 
        /// <param name="wItemId">为用户写入的其要取的变量的索引号，其为ReadItemNo返回的范围内的某个数</param> 
        /// <returns>返回错误码，见附录</returns> 
        /// </summary> 
        [DllImport("kingvewcliend.dll")]
        //[SecurityPermission(SecurityAction.Assert, Unrestricted = true)]

        public static extern int GetItemNames(StringBuilder sName, int wItemId);


        /// <summary> 
        /// 将某个项目添加到采集列中 
        /// <param name="sRegName">是要加入采集的项目名</param> 
        /// <param name="TagId">TagId项目采集的标识号</param> 
        /// <param name="TagDataType">项目的数据类型</param>
        /// <returns>返回错误码，见附录</returns> 
        /// </summary> 
        [DllImport("kingvewcliend.dll")]
        public static extern int AddTag(string sRegName, ref int TagId, ref int TagDataType);

        /// <summary>
        /// 向某个项目中有应用程序向组态王方向写数据
        /// </summary>
        /// <param name="TagId">为要采集项目的标识号</param>
        /// <param name="bVal">bVal、lVal、fVal、sVal为设定的数值，用户将根据变量的类型设定数值</param>
        /// <param name="lVal">bVal、lVal、fVal、sVal为设定的数值，用户将根据变量的类型设定数值</param>
        /// <param name="fVal">bVal、lVal、fVal、sVal为设定的数值，用户将根据变量的类型设定数值</param>
        /// <param name="sVal">bVal、lVal、fVal、sVal为设定的数值，用户将根据变量的类型设定数值</param>
        /// <returns>返回错误码,见附录</returns>
        [DllImport("kingvewcliend.dll")]
        public static extern int WriteTag(ushort TagId, bool bVal, long lVal, float fVal, ref char sVal);


        /// <summary>
        /// 从组态王中读某个项目的数据
        /// </summary>
        /// <param name="TagId">要采集的变量的表示号</param>
        /// <param name="bVal">bVal、lVal、fVal、sVal为设定的数值，用户将根据变量的类型设定数值</param>
        /// <param name="lVal">bVal、lVal、fVal、sVal为设定的数值，用户将根据变量的类型设定数值</param>
        /// <param name="fVal">bVal、lVal、fVal、sVal为设定的数值，用户将根据变量的类型设定数值</param>
        /// <param name="sVal">bVal、lVal、fVal、sVal为设定的数值，用户将根据变量的类型设定数值</param>
        /// <returns>返回错误码,见附录</returns>
        [DllImport("kingvewcliend.dll")]
        public static extern int ReadTag(int TagId, ref bool bVal, ref long lVal, ref Single fVal, StringBuilder sVal);

        /// <summary>
        /// 断开与组态王OPC的连接
        /// </summary>
        /// <returns>返回错误码,见附录</returns>
        [DllImport("kingvewcliend.dll")]
        public static extern int StopCliend();

        //        错误码含义
        //0
        //连接成功
        //-1
        //OPC SERVER已经被非法关闭
        //-2
        //找不到OPC SERVER的PROGID
        //-3
        //连接OPC SERVER不成功
        //-4
        //枚举ITEMS错误
        //-5
        //OPC SERVER没有定义ITEMS
        //-6
        //内存分配错误
        //-7
        //在向GROUP中加入ITEMS时出现错误
        //-8
        //未使用
        //-9
        //读ITEMS时出现错误
        //-10
        //不能识别的数据类型
        //-11
        //读ITEMS的质量戳时出现错误
        //-12
        //向ITEMS中写入数据时出现错误
        //-13
        //用户添加变量的变量名错误
        //-14
        //用户读取的变量序号越界


        public Single[] button1_Click(string ip)
        {
            // Console.WriteLine("连接到本地服务器···");
            //  richTextBox_outtxt.AppendText(string.Format("{0}:{1}\r\n", DateTime.Now, "连接到本地服务器···"));
            int merror = StartCliend(ip);
            //Console.WriteLine("得到项的个数");
            // richTextBox_outtxt.AppendText(string.Format("{0}:{1}\r\n", DateTime.Now, "得到项的个数,连接返回码："+ merror));
            int itemCount = ReadItemNo() < 0 ? 0 : ReadItemNo();
            // Console.WriteLine("得到项的个数为：" + itemCount.ToString());
            // richTextBox_outtxt.AppendText(string.Format("{0}:{1}\r\n", DateTime.Now, "得到项的个数为:"+ itemCount.ToString()));
            StringBuilder regname = new StringBuilder(256);
            string[] name = new string[itemCount];
            // Console.WriteLine("得到所有的Item····");
            //  richTextBox_outtxt.AppendText(string.Format("{0}:{1}\r\n", DateTime.Now, "得到所有的Item····"));
            for (int i = 0; i < itemCount - 1; i++)
            {
                GetItemNames(regname, i);
                name[i] = regname.ToString();
            }
            // Console.WriteLine("输出所有的Item····");
            // richTextBox_outtxt.AppendText(string.Format("{0}:{1}\r\n", DateTime.Now, "输出所有的Item····"));
            for (int i = 0; i < itemCount - 1; i++)
            {
                // Console.WriteLine(name[i].ToString());
               // richTextBox_outtxt.AppendText(string.Format("项目名：{0}:{1}\r\n", DateTime.Now, name[i].ToString()));

            }

            int[] tagId = new int[itemCount];
            int[] tagType = new int[itemCount];
            // Console.WriteLine("开始将要监控的Item添加····");
            //  richTextBox_outtxt.AppendText(string.Format("{0}:{1}\r\n", DateTime.Now, "开始将要监控的Item添加····"));
            for (int i = 0; i < itemCount - 1; i++)
            {
                AddTag(name[i].ToString(), ref tagId[i], ref tagType[i]);
            }

            bool[] bVal = new bool[itemCount];
            long[] lVal = new long[itemCount];
            Single[] fVal = new Single[itemCount];
            StringBuilder sVal = new StringBuilder(255);
            string[] sValString = new string[itemCount];
            // Console.WriteLine("开始读取数据····");

            // richTextBox_outtxt.AppendText(string.Format("{0}:{1}\r\n", DateTime.Now, "开始读取数据····"));
            for (int x = 1; x < 5; x++)
            {
                // Console.WriteLine("第" + x.ToString() + "次读取数据：");
                //  richTextBox_outtxt.AppendText(string.Format("{0}:{1}\r\n", DateTime.Now, "第" + x.ToString() + "次读取数据："));
                for (int i = 0; i < itemCount - 1; i++)
                {
                    ReadTag(tagId[i], ref bVal[i], ref lVal[i], ref fVal[i], sVal);
                    sValString[i] = sVal.ToString();
                    // Console.WriteLine("item:" + name[i].ToString() + "值：" + sValString[i].ToString());
                    // richTextBox_outtxt.AppendText(string.Format("{0}:{1}\r\n", DateTime.Now, "item:" + name[i].ToString() + "值：" + bVal[i].ToString()));

                    // richTextBox_outtxt.AppendText(string.Format("{0}:{1}\r\n", DateTime.Now, "item:" + name[i].ToString() + "值：" + lVal[i].ToString()));

                  //  richTextBox_outtxt.AppendText(string.Format("项目值：{0}:{1}\r\n", DateTime.Now, "item:" + name[i].ToString() + "值：" + fVal[i].ToString()));

                    //richTextBox_outtxt.AppendText(string.Format("项目名取回：{0}:{1}\r\n", DateTime.Now, "item:" + name[i].ToString() + "值：" + sValString[i].ToString()));
                }
            }
            return fVal;
        }

    }
}
