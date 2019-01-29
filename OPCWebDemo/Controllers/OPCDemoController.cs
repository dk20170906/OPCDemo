using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace OPCWebDemo.Controllers
{
    public class OPCDemoController : Controller
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



        public IActionResult Index()
        {
            return View();
        }

        public JsonResult OPCWebTest(string opcIp)
        {
            OPCService oPCService = new OPCService();
            return Json(new {
                success = true,
                fVal = oPCService.button1_Click(opcIp)

            });

        }
    }
}