using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.OpenApi.Models;

namespace Blockfrost.Api.Generate.Contexts
{
    public class ModelContext
    {
        public override string ToString()
        {
            return ClassName;
        }

        private OpenApiDocument _doc;
        private readonly OpenApiSchema _schema;
        private string _baseName;

        public ModelContext(OpenApiDocument s_doc, KeyValuePair<string, OpenApiSchema> schema)
        {
            _doc = s_doc;
            _baseName = schema.Key;
            _schema = schema.Value;
            Properties = new List<PropertyContext>();

            IsMultiple = _schema.AnyOf.Count > 1;

            if (IsMultiple)
            {
                _schema = _schema.AnyOf.Single(s => s.Reference.Id != "empty_object");
                _schema.Required.Clear();
            }
            
            HasReference = _schema.Reference != null;

            var type = _schema.Type;
            if(type == null)
            {
                if(_schema.Items != null)
                {
                    _schema.Type = "array";
                }
                else if(_schema.Properties.Count > 0)
                {
                    _schema.Type = "object";
                } 
                else
                {
                    throw new NotSupportedException("Unknown schema type");
                }
            }

            IsArray = _schema.Type.Equals("array");
            IsObject = _schema.Type.Equals("object");
            IsClass = IsArray || IsObject;
            IsEnum = PropertySchema.Enum.Count > 0;

            if (HasReference)
            {
                ClassName = TemplateHelper.PascalCase(_schema.Reference.Id);
            }
            else
            {
                ClassName = TemplateHelper.PascalCase(_baseName);
            }

            ClassName = ClassName + "Response";
            
            if (!IsClass)
            {
                IsObject = false;
                IsArray = false;
                ClassName = schema.Value.Type;
            }
                        
            if (IsObject)
            {
                var properties = PropertySchema.Properties.Select(p => new PropertyContext(this, p)).ToList();
                if (properties.Any()) properties.Last().IsLast = true;
                Properties.AddRange(properties);
                BaseType = ClassName;
            }
            
            if (IsArray)
            {
                var itemReference = _baseName;
                if(_schema.Items.Reference != null)
                {
                    itemReference = _schema.Items.Reference.Id;
                } else if(_schema.Reference != null)
                {
                    itemReference = _schema.Reference.Id;
                }
                
                ItemContext = new ModelContext(_doc, new KeyValuePair<string, OpenApiSchema>(itemReference, _schema.Items));
                ItemName = ItemContext.ClassName;
                if (ItemContext.IsClass)
                {
                    ClassName = ItemName;
                }
                ClassName = CollectionName;
                BaseType = $"{TemplateHelper.PascalCase(ItemName)}Collection";
            }

        }

        public OpenApiSchema PropertySchema => _schema;
        public ModelContext ItemContext { get; set; }
        public string ItemName { get; set; }
        public bool HasItem => IsArray && !ReferenceEquals(this, ItemContext);
        public string CollectionName => $"{ClassName}Collection";
        public bool IsArray { get; set; }
        public bool IsObject { get; set; }
        public bool IsClass { get; set; }
        public bool IsEnum { get; set; }
        public IEnumerable<string> Required => PropertySchema.Required;
        public List<PropertyContext> Properties { get; set; }
        public bool HasDefaults => Properties.Any(p => p.Default != null);
        public string ClassName { get; set; }
        public bool IsMultiple { get; private set; }
        public bool HasReference { get; private set; }
        public string BaseType { get; internal set; }
    }
}