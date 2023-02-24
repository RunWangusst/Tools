using System.Collections.Generic;

namespace Report.Models
{
    public class ReportTable
    {
        //序号
        public int Order { get; set; }
        //表名称	
        public string PhysicalName { get; set; }
        //索引数量
        public int  IndexCount { get; set; }
        //字段数量
        public int AttributesCount { get; set; }
        //代码数量
        public int ErCodesCount { get; set; }
        //属性标准化数量
        public int SdAttrCount { get; set; }
        //属性落标率	
        public string AttributeFallingRate { get; set; }
        //表类型
        public string TableType { get; set; }
        //实体名称
        public string LogicalName { get; set; }
        //定义	
        public string Definition { get; set; }
        //说明
        public string Description { get; set; }
        //属性
        public List<ReportAttribute> ReportAttributes { get; set; }
        //关系
        public List<ReportEntityRelation> ReportEntityRelationsaltions { get; set; }
        //索引
        public List<ReportERIndex> ReportERIndexs { get; set; }
        //代码
        public List<ReportErCode> ReportErCodes { get; set; }
    }
}