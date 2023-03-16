
using Chapter6.HttpModel;

namespace Chapter6.Template.ActivityTemp;

internal class ActivityTemplate : DataTemplateSelector
{
    public DataTemplate ComplateTemplate { get; set; }
    public DataTemplate InComplateTemplate { get;set; }
    protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
    {
        var Items = (ActivityDetail)item;

        if (Items.Completed == true)
        {
            return ComplateTemplate;

        }
        else
        {
            return InComplateTemplate;
        }
    }
}
