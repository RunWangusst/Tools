namespace Report.Models
{
    public class ReportEntityRelation
    {
        //序号
        public int Order { get; set; }
        //关系名称  
        public string RelationName { get; set; }
        //关系类型 
        public string RelationType { get; set; }
        //父实体
        public string ParentEntity { get; set; }
        //父属性 
        public string ParentAttributes { get; set; }
        //子实体
        public string ChildEntity { get; set; }
        //子属性
        public string ChildAttributes { get; set; }
    }
}