namespace Report.Models
{
    public class ReportERIndex
    {

        //序号
        public int Order { get; set; }
        //表名称
        public string TableName { get; set; }
        //索引名称
        public string IndexName { get; set; }
        //是否唯一
        public string IsUnique { get; set; }
        //字段名称
        public string ERIndexColumns { get; set; }
        //排序
        public string SortingOrder { get; set; }
    }
}