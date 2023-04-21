using Microsoft.AspNetCore.OData.Formatter;
using Microsoft.AspNetCore.OData.Formatter.Serialization;
using Microsoft.AspNetCore.OData.Formatter.Value;
using Microsoft.OData;
using Microsoft.OData.Edm;
using Microsoft.OData.UriParser;

namespace DataAccess.Api.OData;

/// <summary>
/// 
/// </summary>
public class OmitNullResourceSerializer : ODataResourceSerializer
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="serializerProvider"></param>
    public OmitNullResourceSerializer(IODataSerializerProvider serializerProvider) : base(serializerProvider)
    {
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="structuralProperty"></param>
    /// <param name="resourceContext"></param>
    /// <returns></returns>
    public override ODataProperty? CreateStructuralProperty(IEdmStructuralProperty structuralProperty, ResourceContext resourceContext)
    {
        bool isOmitNulls = resourceContext.Request.ShouldOmitNullValues();
        if (isOmitNulls)
        {
            object propertyValue = resourceContext.GetPropertyValue(structuralProperty.Name);
            if (propertyValue == null)
            {
                // it MUST specify the Preference-Applied response header with omit-values=nulls
                resourceContext.Request.SetPreferenceAppliedResponseHeader();
                return null;
            }
        }

        return base.CreateStructuralProperty(structuralProperty, resourceContext);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="complexProperty"></param>
    /// <param name="pathSelectItem"></param>
    /// <param name="resourceContext"></param>
    /// <returns></returns>
    public override ODataNestedResourceInfo? CreateComplexNestedResourceInfo(IEdmStructuralProperty complexProperty, PathSelectItem pathSelectItem, ResourceContext resourceContext)
    {
        bool isOmitNulls = resourceContext.Request.ShouldOmitNullValues();
        if (isOmitNulls)
        {
            object propertyValue = resourceContext.GetPropertyValue(complexProperty.Name);
            if (propertyValue == null || propertyValue is NullEdmComplexObject)
            {
                resourceContext.Request.SetPreferenceAppliedResponseHeader();
                return null;
            }
        }

        return base.CreateComplexNestedResourceInfo(complexProperty, pathSelectItem, resourceContext);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="navigationProperty"></param>
    /// <param name="resourceContext"></param>
    /// <returns></returns>
    public override ODataNestedResourceInfo? CreateNavigationLink(IEdmNavigationProperty navigationProperty, ResourceContext resourceContext)
    {
        bool isOmitNulls = resourceContext.Request.ShouldOmitNullValues();
        if (isOmitNulls)
        {
            object propertyValue = resourceContext.GetPropertyValue(navigationProperty.Name);
            if (propertyValue == null || propertyValue is NullEdmComplexObject)
            {
                resourceContext.Request.SetPreferenceAppliedResponseHeader();
                return null;
            }
        }

        return base.CreateNavigationLink(navigationProperty, resourceContext);
    }
}