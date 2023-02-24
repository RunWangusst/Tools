using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Report.Models
{
    public class TestModel
    {
        //表名称	
        public string TablePhysicalName { get; set; }
        //表中文名
        public string TableLogicalName { get; set; }
        //字段名称	
        public string PhysicalName { get; set; }
        //字段中文名
        public string LogicalName { get; set; }
        //主键	
        public string PK { get; set; }
        //非空	
        public string NotNull { get; set; }
        //数据类型	
        public string PhysicalDataType { get; set; }
        public string Description { get; set; }
    }
}
