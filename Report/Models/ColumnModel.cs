using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Report.Models
{
    /// <summary>
    /// 数据字典项Model（数据库中导出的字段）
    /// </summary>
    public class ColumnModel
    {
        /// <summary>
        /// 表名称
        /// </summary>
        public string TablePhysicalName { get; set; }
        /// <summary>
        /// 表中备注（中文名）
        /// </summary>
        public string TableLogicalName { get; set; }
        /// <summary>
        /// 字段名称
        /// </summary>
        public string PhysicalName { get; set; }
        /// <summary>
        /// 字段备注（中文名）
        /// </summary>
        public string LogicalName { get; set; }
        /// <summary>
        /// 主键
        /// </summary>
        public string PK { get; set; }
        /// <summary>
        /// 非空
        /// </summary>
        public string NotNull { get; set; }
        /// <summary>
        /// 数据类型 eg: char(12)
        /// </summary>
        public string PhysicalDataType { get; set; }
        /// <summary>
        /// 字段描述
        /// </summary>
        public string Description { get; set; }
    }
}
