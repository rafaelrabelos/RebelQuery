using System;

namespace RebelQuery
{
    [AttributeUsage(AttributeTargets.All, Inherited = false, AllowMultiple = true)]
    public class SqlAttribute : Attribute
    {
        readonly string attributeName;
        
        public SqlAttribute(SQL attribute)
        {
            this.attributeName = attribute.ToString();
        }
        
        public string AttributeName
        {
            get { return attributeName; }
        }
        
    }
    /// <summary>
    /// A SQL colum Primary Key`s identifier.
    /// </summary>
    [AttributeUsage(AttributeTargets.All, Inherited = false, AllowMultiple = true)]
    public sealed class PrimaryKey : Attribute{}

}