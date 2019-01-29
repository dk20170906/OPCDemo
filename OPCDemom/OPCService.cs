using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace OPCDemom
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="opcip">须传的服务ip地址，本地可为空</param>
        /// <param name="allitem">返回所有的项目名</param>
        /// <param name="bVal">bVal、lVal、fVal、sVal为设定的数值，用户将根据变量的类型设定数值</param>
        /// <param name="lVal">bVal、lVal、fVal、sVal为设定的数值，用户将根据变量的类型设定数值</param>
        /// <param name="fVal">bVal、lVal、fVal、sVal为设定的数值，用户将根据变量的类型设定数值</param>
        /// <param name="sVal">bVal、lVal、fVal、sVal为设定的数值，用户将根据变量的类型设定数值</param>
        public void OPCOperationByIp(string opcip, out string[] allitem, out bool[] bVal, out long[] lVal, out Single[] fVal, out string[] sVal)
        {
            int merror = StartCliend(opcip);
            int itemCount = ReadItemNo() < 0 ? 0 : ReadItemNo();
            StringBuilder regname = new StringBuilder(256);
            allitem = new string[itemCount];
            for (int i = 0; i < itemCount - 1; i++)
            {
                GetItemNames(regname, i);
                allitem[i] = regname.ToString();
            }
            int[] tagId = new int[itemCount];
            int[] tagType = new int[itemCount];
            for (int i = 0; i < itemCount - 1; i++)
            {
                AddTag(allitem[i].ToString(), ref tagId[i], ref tagType[i]);
            }

            bVal = new bool[itemCount];
            lVal = new long[itemCount];
            fVal = new Single[itemCount];
            sVal = new string[itemCount];
          var  sValA = new StringBuilder(255);
            string[] sValString = new string[itemCount];
            for (int x = 1; x < 5; x++)
            {
                for (int i = 0; i < itemCount - 1; i++)
                {
                    ReadTag(tagId[i], ref bVal[i], ref lVal[i], ref fVal[i], sValA);
                    sVal[i] = sValA.ToString();
                //    // Console.WriteLine("item:" + name[i].ToString() + "值：" + sValString[i].ToString());
                //    // richTextBox_outtxt.AppendText(string.Format("{0}:{1}\r\n", DateTime.Now, "item:" + name[i].ToString() + "值：" + bVal[i].ToString()));

                //    // richTextBox_outtxt.AppendText(string.Format("{0}:{1}\r\n", DateTime.Now, "item:" + name[i].ToString() + "值：" + lVal[i].ToString()));

                //    richTextBox_outtxt.AppendText(string.Format("项目值：{0}:{1}\r\n", DateTime.Now, "item:" + name[i].ToString() + "值：" + fVal[i].ToString()));

                //    richTextBox_outtxt.AppendText(string.Format("项目名取回：{0}:{1}\r\n", DateTime.Now, "item:" + name[i].ToString() + "值：" + sValString[i].ToString()));
                }
            }
        }


    }
}
