using System.Collections.Generic;
using System.Data;

namespace Report.Models
{
    public class ReportSubjectArea
    {
        //SubjectAreaID
        public string SubjectAreaID { get; set; }
        //序号
        public int Order { get; set; }
        //主题域
        public string Name { get; set; }

        //主题域定义
        public string Description { get; set; }
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
        //表详情
        public List<ReportTable> ReportTables { get; set; }
        //视图详情
        public List<ReportView> ReportViews { get; set; }

        //自定义属性
        //自定义字段属性
        public DataTable UdpAttributeSource { get; set; }
        //自定义表属性
        public DataTable UdpTableSource { get; set; }

        public int UdpAttributeCodesCount { get { return UdpAttributeSource.Rows.Count; } }

        public int UdpTableSourceCount { get { return UdpTableSource.Rows.Count; } }
    }
}