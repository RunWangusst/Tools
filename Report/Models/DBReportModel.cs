using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Report.Models
{
    /// <summary>
    /// 数据库设计文档导出Model
    /// </summary>
   public class DbReportModel
    {
        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; set; }
        //模型名称
        public string Name { get; set; }
        /// <summary>
        /// 数据库类型
        /// </summary>
        public string DBMSType { get; set; }
        /// <summary>
        /// 数据库版本
        /// </summary>
        public string DBMSVer { get; set; }
        /// <summary>
        /// 说明
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 模型简介
        /// </summary>
        public List<ReportSubjectArea> ReportSubjectAreas;

        /// <summary>
        /// 表数量
        /// </summary>
        public int TablesCount { get; set; }
        /// <summary>
        /// 属性数量
        /// </summary>
        public int AttributesCount { get; set; }
        /// <summary>
        /// 代码数量
        /// </summary>
        public int CodesCount { get; set; }
        /// <summary>
        /// 属性标准化数量
        /// </summary>
        public int StandarddAttributesCount { get; set; }
        /// <summary>
        /// 属性落标率
        /// </summary>
        public string StandardAttributesRate { get; set; }

    }
}
