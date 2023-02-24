namespace Report.Models
{
    public class ReportViewDetail
    {
        //序号
        public int Order { get; set; }
        //字段名称
        public string PhysicalName { get; set; }
        //源表名称
        public string OrginTableName { get; set; }
        //源字段名称
        public string OrginPhysicalName { get; set; }
        //源属性名称
        public string OrginLogicalName { get; set; }
        //说明
        public string Description { get; set; }
    }
}