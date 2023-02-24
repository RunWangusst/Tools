using System.Collections.Generic;

namespace Report.Models
{
    public class ReportAttribute
    {
        //序号
        public int PhysicalOrder { get; set; }
        //字段名称	
        public string PhysicalName { get; set; }
        //字段中文名
        public string AlternativeName { get; set; }
        //数据类型	
        public string PhysicalDataType { get; set; }
        //主键	
        public string PK { get; set; }
        //非空	
        public string NotNull { get; set; }
        //默认值	
        public string DefaultValue { get; set; }
        //备注说明
        public string Description { get; set; }
    }
}