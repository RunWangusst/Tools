using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Report.Models
{
   public class DBReportModel
    {
        //文章tiltle
        public string Title { get; set; }
        //模型名称
        public string Name { get; set; }
        //数据库类型
        public string DBMSType { get; set; }
        //数据库版本
        public string DBMSVer { get; set; }
        //说明
        public string Description { get; set; }

        //模型简介
        public List<ReportSubjectArea> ReportSubjectAreas;

        //表数量
        public int TbCount { get; set; }
        //属性数量
        public int AttributesCount { get; set; }
        //代码数量
        public int CodesCount { get; set; }
        //属性标准化数量
        public int SdAttrCount { get; set; }
        //属性落标率
        public string AttrFallRate { get; set; }

    }
}
